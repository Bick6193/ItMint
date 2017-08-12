using DAL.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public  class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options) { }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApiClient> ApiClients { get; set; }
        public DbSet<ApplicationUser> IdentityUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           base.OnConfiguring(optionsBuilder);
        }
    }
}
