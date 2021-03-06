using System;
using Microsoft.IdentityModel.Tokens;

namespace Web.Identity
{
  public class TokenProviderOptions
  {
    public string Path { get; set; } = "/api/token";

    public string Issuer { get; set; }

    public string Audience { get; set; }

    public TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromMinutes(5);

    public SigningCredentials SigningCredentials { get; set; }
  }
}
