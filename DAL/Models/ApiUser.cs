using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Authorization;

namespace DAL.Models
{
    public class ApiUser
    {
      [Key]
      public string ClientId { get; set; }

      [Required]
      public bool Active { get; set; }

      [Required]
      public string Secret { get; set; }

      [Required]
      public string Name { get; set; }

      [Required]
      public long RefreshTokenLifeTime { get; set; }

      [Required]
      public ApplicationType ApplicationType { get; set; }
  }
}
