using DAL.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DAL.Context
{
    public  class ApplicationContext : DbContext
    {
        public ApplicationContext() : base()
        {
             
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ApiClient> ApiClients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
