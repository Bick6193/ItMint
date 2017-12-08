using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
  public class Token: EntityBase
  {
    [Required]
    public long UserId { get; set; }

    [Required]
    [MaxLength(128)]
    public string ClientId { get; set; }

    [Required]
    public string RefreshToken { get; set; }

    [Required]
    public string AccessToken { get; set; }

    [Required]
    public DateTime IssuedUtc { get; set; }

    [Required]
    public DateTime AccessTokenExpiresUtc { get; set; }

    [Required]
    public DateTime RefreshTokenExpiresUtc { get; set; }

    public bool TokenIsExpired => RefreshTokenExpiresUtc <= EntityCreatedDate;

    private DateTime EntityCreatedDate { get; } = DateTime.UtcNow;
  }
}
