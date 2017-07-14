using System;

namespace Domain.Authorization
{
    public class RefreshTokenDetails
    {
        public string Id { get; set; }

        public long UserId { get; set; }

        public string ClientId { get; set; }

        public DateTime IssuedUtc { get; set; }

        public DateTime ExpiresUtc { get; set; }

        public string ProtectedTicket { get; set; }
    }
}
