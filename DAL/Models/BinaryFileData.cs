using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models

{
    public class BinaryFileData
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public virtual File File { get; set; }
    }
}
