using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Attributes;

namespace DAL.Model
{
    [SoftDelete(false)]
    public class RefreshToken
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        [MaxLength(128)]
        public string ClientId { get; set; }

        [Required]
        public DateTime IssuedUtc { get; set; }

        [Required]
        public DateTime ExpiresUtc { get; set; }

        [Required]
        public string ProtectedTicket { get; set; }
    }
}
