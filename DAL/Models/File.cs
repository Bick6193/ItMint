using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class File
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public int? RequestFormId { get; set; }

        public virtual Request Request { get; set; }

        public string RequestFormToken { get; set; }

        public int? FileIndex { get; set; }

        public int BinaryDataId { get; set; }

        public virtual BinaryFileData BinaryData { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
