using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Attributes;
using Domain.Authorization;

namespace DAL.Model
{
    [SoftDelete(false)]
    public class ApiClient
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
        public int RefreshTokenLifeTime { get; set; }

        [Required]
        public ApplicationType ApplicationType { get; set; }
    }
}
