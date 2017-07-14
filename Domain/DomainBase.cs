using System;
using Newtonsoft.Json;

namespace Domain
{
    public class DomainBase
    {
        public long Id { get; set; }

        [JsonIgnore]
        public bool IsNew => Id == 0;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public byte[] RowVersion { get; set; }
    }
}