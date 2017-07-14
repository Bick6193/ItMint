using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Attributes;
using Domain;

namespace ScheduleModelLib.DB
{
    public class EmailSettings : EntityBase
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Encrypted]
        [Required]
        public string Password { get; set; }

        [Required]
        public string Host { get; set; }

        public int Port { get; set; }

        public bool EnableSsl { get; set; }

        public bool IsActive { get; set; }
    }
}
