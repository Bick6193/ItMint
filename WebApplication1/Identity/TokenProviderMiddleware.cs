using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Infrastructure;
using Common;
using Domain.Request;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Security;
using Domain;
using Domain.Authorization;
using Newtonsoft.Json.Serialization;

namespace Web.Identity
{
  public class TokenProviderMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly TokenProviderOptions _options;
    private HttpContext Context;

    private IApplicationUserService UserService { get; set; }
    private IAuthService AuthService { get; set; }

    public TokenProviderMiddleware(RequestDelegate next,
                                  IOptions<TokenProviderOptions> options)
    {
      _next = next;
      _options = options.Value;


    }
    public Task Invoke(HttpContext context,
      IApplicationUserService userService,
      IAuthService authService)
    {

      UserService = userService;
      AuthService = authService;

      if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
      {
        return _next(context);
      }
      if (!context.Request.Method.Equals("POST") || !context.Request.HasFormContentType)
      {
        context.Response.StatusCode = 400;
        return context.Response.WriteAsync("Bad Request");
      }

      Context = context;
      return Authenticate();
    }

    private async Task Authenticate()
    {
      var model = ChallangeModel.FronRequest(Context.Request);

      OperationResult<AuthenticationResult> result = null;

      switch (model.GrantType)
      {
        case "password":
          result = GenerateToken(model);
          break;
        case "refresh_token":
          result = RestoreToken(model);
          break;
        default:
          Log.Logger().Warning("Wrong grant type");
          Context.Response.StatusCode = 400;
          await Context.Response.WriteAsync("Wrong grant type");
          return;
      }
      if (!result.Success)
      {
        Context.Response.StatusCode = 401;
        await Context.Response.WriteAsync(result.Message);
        return;
      }

      Context.Response.ContentType = "application/json";
      await Context.Response.WriteAsync(JsonConvert.SerializeObject(result,
        new JsonSerializerSettings { Formatting = Formatting.Indented, ContractResolver = new CamelCasePropertyNamesContractResolver() }));
    }

    private OperationResult<AuthenticationResult> RestoreToken(ChallangeModel model)
    {
      try
      {
        Log.Logger().Information("Refresh token authentication is requested");

        if (string.IsNullOrEmpty(model.RefreshToken))
        {
          Log.Logger().Warning("Refresh token is empry.");

          return new OperationResult<AuthenticationResult>()
          {
            Success = false,
            Message = "Refresh token is empry."
          };
        }

        var token = AuthService.GetTokenByRefresh(model.RefreshToken);

        if (token == null)
        {
          Log.Logger().Warning("Refresh token {RefreshToken} was not found", model.RefreshToken);

          return new OperationResult<AuthenticationResult>()
          {
            Success = false,
            Message = "Refresh token was not found."
          };
        }

        if (!string.Equals(token.ClientId, model.ClientId, StringComparison.CurrentCultureIgnoreCase))
        {
          Log.Logger().Warning("Token {tok} is issued for the client {client} but requested for the clinet {client}",
            model.RefreshToken, token.ClientId, model.ClientId);

          return new OperationResult<AuthenticationResult>()
          {
            Success = false,
            Message = "Token is issued for different clinet"
          };
        }

        if (token.TokenIsExpired)
        {
          Log.Logger().Warning("Token {RefreshToken} is expired.", model.RefreshToken);

          return new OperationResult<AuthenticationResult>()
          {
            Success = false,
            Message = "Token is expired.",
          };
        }

        var user = UserService.FindById((int)token.UserId);

        if (user == null)
        {
          Log.Logger().Warning("User with id {id} is not found.", token.UserId);

          return new OperationResult<AuthenticationResult>()
          {
            Success = false,
            Message = "User is not found."
          };
        }

        var now = DateTime.UtcNow;
        var refreshTokenLifeTime = TimeSpan.FromMinutes(AuthService.GetClient(model.ClientId).RefreshTokenLifeTime);
        var accessTokenLifeTime = _options.AccessTokenExpiration;

        List<Claim> claims = CreateClaims(user);

        var jwt = new JwtSecurityToken(
          issuer: _options.Issuer,
          audience: _options.Audience,
          claims: claims,
          notBefore: now,
          expires: now.Add(accessTokenLifeTime),
          signingCredentials: _options.SigningCredentials);

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        token.RefreshToken = CreateRefreshToken();
        token.IssuedUtc = now;
        token.RefreshTokenExpiresUtc = now.Add(refreshTokenLifeTime);
        token.AccessToken = encodedJwt;

        AuthService.Upsert(token);
        Log.Logger().Information("Existing token is updated");

        var response = new AuthenticationResult()
        {
          AccessToken = token.AccessToken,
          RefreshToken = token.RefreshToken,
          ExpiresIn = (int)_options.AccessTokenExpiration.TotalSeconds,
         // User = user
        };

        return new OperationResult<AuthenticationResult>(response);
      }
      catch (Exception e)
      {
        Log.Logger().Error(e, "Ecxeption while Generating Token");
        return new OperationResult<AuthenticationResult>() { Success = false };
      }
    }
    private OperationResult<AuthenticationResult> GenerateToken(ChallangeModel model)
    {
      try
      {
        Log.Logger().Information("GenerateToken Start...");

        var result = UserService.LoginUser(model.UserName, model.Password);

        if (!result.Success)
        {
          Log.Logger().Warning("Password authentication is failed, message {message}", result.Message);
          return OperationResult.FromError<AuthenticationResult, UserDTO>(result);
        }

        var user = result.Object;
        var now = DateTime.UtcNow;
        var refreshTokenLifeTime = TimeSpan.FromMinutes(AuthService.GetClient(model.ClientId).RefreshTokenLifeTime);
        var accessTokenLifeTime = _options.AccessTokenExpiration;


        List<Claim> claims = CreateClaims(user);
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, model.UserName));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));

        //add user claims

        var jwt = new JwtSecurityToken(
          issuer: _options.Issuer,
          audience: _options.Audience,
          claims: claims,
          notBefore: now,
          expires: now.Add(_options.AccessTokenExpiration),
          signingCredentials: _options.SigningCredentials);

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var token = AuthService.GetTokenByUserAndClient(user.Id, model.ClientId);

        if (token != null)
        {
          token.RefreshToken = CreateRefreshToken();
          token.IssuedUtc = now;
          token.AccessTokenExpiresUtc = now.Add(accessTokenLifeTime);
          token.RefreshTokenExpiresUtc = now.Add(refreshTokenLifeTime);
          token.AccessToken = encodedJwt;

          Log.Logger().Information("Existing token is updated");
        }
        else
        {
          token = new RefreshTokenDetails
          {
            RefreshToken = CreateRefreshToken(),
            ClientId = model.ClientId,
            UserId = user.Id,
            IssuedUtc = now,
            AccessTokenExpiresUtc = now.Add(accessTokenLifeTime),
            RefreshTokenExpiresUtc = now.Add(refreshTokenLifeTime),
            AccessToken = encodedJwt
          };

          Log.Logger().Information("New token is created");
        }

        AuthService.Upsert(token);

        var response = new AuthenticationResult()
        {
          AccessToken = encodedJwt,
          RefreshToken = token.RefreshToken,
          ExpiresIn = (int)accessTokenLifeTime.TotalSeconds,
          Administrative = user.IsAdministrative
        };
        return new OperationResult<AuthenticationResult>(response);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return new OperationResult<AuthenticationResult>() { Success = false };
      }
    }

    private List<Claim> CreateClaims(UserDTO user)
    {
      var result = new List<Claim>
      {
        new Claim(IdentityUser.ClaimName, user.FullName, ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimNameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer64),
        new Claim(IdentityUser.ClaimEmail, user.Email ?? "", ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimLogin, user.Login, ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimForceToResetPassword, user.ForceToResetPassword.ToString(), ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimIsAdministrative, user.IsAdministrative.ToString(), ClaimValueTypes.Boolean)
      };
      return result;
    }

    private string CreateRefreshToken()
    {
      var guid = Encoding.ASCII.GetBytes(Guid.NewGuid().ToString("n"));

      var random = new byte[10];
      using (var generator = RandomNumberGenerator.Create())
      {
        generator.GetBytes(random);
      }

      var length = guid.Length + random.Length;

      var result = new byte[length];

      Buffer.BlockCopy(guid, 0, result, 0, guid.Length);
      Buffer.BlockCopy(random, 0, result, guid.Length, random.Length);

      return Convert.ToBase64String(result);
    }

    private List<Claim> CreateClaims(ApplicationUserLogin user)
    {
      var result = new List<Claim>
      {
        new Claim(IdentityUser.ClaimName, user.FullName, ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimNameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer64),
        new Claim(IdentityUser.ClaimEmail, user.Email ?? "", ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimLogin, user.Login, ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimType, user.UserType.ToString(), ClaimValueTypes.String),
        new Claim(IdentityUser.ClaimForceToResetPassword, user.ForceToResetPassword.ToString(),
          ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimIsAdministrative, user.IsAdministrative().ToString(), ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimCanEdit, user.CanEdit().ToString(), ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimPermissions, JsonConvert.SerializeObject(user.GetPermissionsMap()),
          ClaimValueTypes.String)
      };

      result.AddRange(user.Roles.Where(x => x.Active)
        .Select(role => new Claim(IdentityUser.ClaimRole, role.Name, ClaimValueTypes.String)));

      //jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
      result.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Login));
      result.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
      result.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
        ClaimValueTypes.Integer64));

      return result;
    }

  }
}
