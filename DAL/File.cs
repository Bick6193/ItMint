using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;

namespace DAL.Model
{
    public class File : EntityBase
    {
        public int FileId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public int? RequestFormId { get; set; }
       
        public string RequestFormToken { get; set; }

        public int? FileIndex { get; set; }

        public int BinaryDataId { get; set; }

        public virtual BinaryData BinaryData { get; set; }
    }
}
