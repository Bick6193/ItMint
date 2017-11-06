using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Web.Identity
{
    public static class JwtBearerExtension
    {
      private static string SecretKey => "SADger[.[pcytesdf8w66fhgqe9q87rqwj .[kxwkg owyu979rouq9e";

      private static string Issure => "innerIssure";

      private static string Audience => "apiResources";


    public static void ConfigJwtBearerAuthentication(this IApplicationBuilder app)
      {
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        
        var jwtOptions = new TokenProviderOptions
        {
          Audience = Audience,
          Issuer = Issure,
          SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
        };

        app.UseMiddleware<TokenProviderMiddleware>(Options.Create(jwtOptions));
      
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

        app.UseJwtBearerAuthentication(new JwtBearerOptions
        {
          AutomaticAuthenticate = true,
          AutomaticChallenge = true,
          TokenValidationParameters = tokenValidationParameters,
          AuthenticationScheme = "Bearer"
        });
    }
  }
}
