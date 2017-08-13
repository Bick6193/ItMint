using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Infrastructure;
using Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Security;


namespace Web.Identity
{
  public class TokenProviderMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly TokenProviderOptions _options;
    
    private IApplicationUserService UserService { get; }

    public TokenProviderMiddleware(RequestDelegate next,
                                  IOptions<TokenProviderOptions> options, 
                                  IApplicationUserService userService)
    {
      _next = next;
      _options = options.Value;
      UserService = userService;
    }
    public Task Invoke(HttpContext context)
    {
      if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
      {
        return _next(context);
      }
      if (!context.Request.Method.Equals("POST") || !context.Request.HasFormContentType)
      {
        context.Response.StatusCode = 400;
        return context.Response.WriteAsync("Bad Request");
      }
      return GenerateToken(context);
    }

    private async Task GenerateToken(HttpContext context)
    {
      var login = context.Request.Form["username"];
      var password = context.Request.Form["password"];

      var result = UserService.LoginUser(login, password);

      if (!result.Success)
      {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(string.Join(" ,", result.Messages));
        return;
      }

      var user = result.Object;
      var now = DateTime.UtcNow;

      //jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
      List<Claim> claims = CreateClaims(user);
      claims.Add(new Claim(JwtRegisteredClaimNames.Sub, login));
      claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
      claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));
      
      //add user claims

      var jwt = new JwtSecurityToken(
        issuer: _options.Issuer,
        audience: _options.Audience,
        claims: claims,
        notBefore: now,
        expires: now.Add(_options.Expiration),
        signingCredentials: _options.SigningCredentials);

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

      var response = new
      {
        access_token = encodedJwt,
        expires_in = (int)_options.Expiration.TotalSeconds
      };

      context.Response.ContentType = "application/json";
      await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
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
        new Claim(IdentityUser.ClaimForceToResetPassword, user.ForceToResetPassword.ToString(), ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimIsAdministrative, user.IsAdministrative().ToString(), ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimCanEdit, user.CanEdit().ToString(), ClaimValueTypes.Boolean),
        new Claim(IdentityUser.ClaimPermissions, JsonConvert.SerializeObject(user.GetPermissionsMap()), ClaimValueTypes.String)
      };

      result.AddRange(user.Roles.Select(role => new Claim(IdentityUser.ClaimRole, role.Name, ClaimValueTypes.String)));

      return result;
    }

  }
}
