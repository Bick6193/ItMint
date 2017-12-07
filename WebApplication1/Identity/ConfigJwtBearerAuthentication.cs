using System;
using System.Text;
using Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Web.Identity
{
  public static class JwtBearerExtension
  {
    private static string SecretKey => "SADger[.[pcytesdf8w66fhgqe9q87rqwj .[kxwkg owyu979rouq9e";

    private static string Issure => "innerIssure";

    private static string Audience => "apiResources";

    public static void AddJwtBearerAuthentication(this IServiceCollection services)
    {
      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

      var tokenValidationParameters = new TokenValidationParameters
      {
        //The signing key must match !
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,

        //Validate the JWT Issuer (iss) claim
        ValidateIssuer = true,
        ValidIssuer = Issure,

        //validate the JWT Audience (aud) claim
        ValidateAudience = true,
        ValidAudience = Audience,

        //validate the token expiry
        ValidateLifetime = true,

        // If you  want to allow a certain amout of clock drift
        ClockSkew = TimeSpan.Zero
      };

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = tokenValidationParameters;
        });
    }

    public static void ConfigJwtBearerMiddleware(this IApplicationBuilder app)
    {
      Log.Logger().Information("Configure Jwt Bearer Middleware...");

      var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

      var jwtOptions = new TokenProviderOptions
      {
        Audience = Audience,
        Issuer = Issure,
        SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
      };

      app.UseMiddleware<TokenProviderMiddleware>(Options.Create(jwtOptions));

      app.UseAuthentication();
    }
  }
}
