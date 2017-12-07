using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Authorization
{
  public class RefreshTokenDetails
  {
    public long UserId { get; set; }

    public string ClientId { get; set; }

    public string RefreshToken { get; set; }

    public string AccessToken { get; set; }

    public DateTime IssuedUtc { get; set; }

    [Required]
    public DateTime AccessTokenExpiresUtc { get; set; }

    [Required]
    public DateTime RefreshTokenExpiresUtc { get; set; }

    public bool TokenIsExpired => RefreshTokenExpiresUtc <= EntityCreatedDate;

    private DateTime EntityCreatedDate { get; } = DateTime.UtcNow;
  }
}
