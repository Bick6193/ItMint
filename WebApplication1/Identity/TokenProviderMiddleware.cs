using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace Web.Identity
{
  public class TokenProviderMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly TokenProviderOptions _options;
    //todo inject users service
    
    public TokenProviderMiddleware(RequestDelegate next,
                                  IOptions<TokenProviderOptions> options)
    {
      _next = next;
      _options = options.Value;
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
      var username = context.Request.Form["username"];
      var password = context.Request.Form["password"];

      var identity = await GetIdentity(username, password);
      if (identity == null)
      {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid username or password");
        return;
      }
      var now = DateTime.UtcNow;

      //jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
      List<Claim> claims = new List<Claim>();
      claims.Add(new Claim(JwtRegisteredClaimNames.Sub, username));
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

    private Task<ClaimsIdentity> GetIdentity(string username, string password)
    {
      // DON'T do this in production, obviously!
      if (username == "TEST" && password == "TEST")
      {
        return Task.FromResult(new ClaimsIdentity(new System.Security.Principal.GenericIdentity(username, "Token"), new Claim[] { }));
      }

      // Credentials are invalid, or account doesn't exist
      return Task.FromResult<ClaimsIdentity>(null);
    }

  }
}
