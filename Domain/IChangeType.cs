using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CreditorGuard.Domain;
using JetBrains.Annotations;

namespace Domain
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public interface IChangeType
    {
        long Id { get; set; }

        [Required]
        [EnumDataType(typeof(ChangeType))]
        ChangeType ChangeType { get; set; }

        List<ChangesDetails> Changes { get; set; }
    }
}