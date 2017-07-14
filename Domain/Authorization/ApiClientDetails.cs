namespace Domain.Authorization
{
    
    public class ApiClientDetails
    {
        public bool Active { get; set; }

        public string Name { get; set; }

        public string Secret { get; set; }

        public string ClientId { get; set; }

        public int RefreshTokenLifeTime { get; set; }

        public ApplicationType ApplicationType { get; set; }
    }
}
