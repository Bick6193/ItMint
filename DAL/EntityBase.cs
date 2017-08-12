using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace DAL
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Key]
        public long Id { get; set; }

        public bool IsNew => Id == 0;

        [Required]
        public DateTime CreatedDate { get; set; }

        [IgnoreMap]
        public DateTime? DeletedDate { get; set; }

        [IgnoreMap]
        [Required]
        public virtual bool IsDeleted { get; set; }

        public byte[] RowVersion { get; set; }
    }
}