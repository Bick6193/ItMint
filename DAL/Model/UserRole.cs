using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace DAL.Model
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public class UserRole : EntityBase, IManyToManyTable
    {
        [ForeignKey(nameof(Role))]
        public long? RoleId { get; set; }

        public virtual Role Role { get; set; }

        [ForeignKey(nameof(User))]
        public long? UserId { get; set; }

        public virtual User User { get; set; }

        [NotMapped]
        public long? LinkedDataId
        {
            get => RoleId;
            set => RoleId = value;
        }
    }
}
