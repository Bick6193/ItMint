using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
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

        public DateTime? DeletedDate { get; set; }

        [Required]
        public virtual bool IsDeleted { get; set; }

        public byte[] RowVersion { get; set; }
    }
}