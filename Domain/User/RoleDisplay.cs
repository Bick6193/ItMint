using System.Collections.Generic;
using Common.Serialization;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Domain.User
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class RoleDisplay : DomainBase, IChangeType
    {
        public bool Active { get; set; }

        [JsonConverter(typeof(JsonStringTrimConverter))]
        public string Name { get; set; }

        public bool IsAdministrative { get; set; }

        public bool CanEdit { get; set; }

        public bool Editable { get; set; }

        public bool IsBuiltIn { get; set; }

        public ChangeType ChangeType { get; set; }

        public List<ChangesDetails> Changes { get; set; }
    }
}