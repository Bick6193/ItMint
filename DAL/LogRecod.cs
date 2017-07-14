using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    [Table("Serilog")]
    public class LogRecod
    {
        public int Id { get; set; }

        public string MessageTemplate { get; set; }

        public string Message { get; set; }

        public string Level { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }
    }
}
