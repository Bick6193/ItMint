  using System.Collections.Generic;
using Domain.Audit;

namespace Domain.SafeDelete
{
    public class EntityExternalReference
    {
        public AuditObject Type { get; set; }

        public int Count { get; set; }
    }

    public class SafeDeleteResult
    {
        public List<EntityExternalReference> References { get; set; } = new List<EntityExternalReference>();

        public bool IsDeleteAllowed => References.Count == 0;
    }
}
