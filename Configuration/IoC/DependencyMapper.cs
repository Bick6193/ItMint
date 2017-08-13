using BLL;
using BLL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Common.Configuration;
using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Infrastructure;
using DAL.Repositories.RepositoriesAbstract;
using DAL.SeedMamagers;
using JetBrains.Annotations;

namespace Configuration.IoC
{
  [UsedImplicitly]
  public class DependencyMapper
    {
        public static void Configure(IServiceCollection services, ICustomConfigurationProvider ConfigurationProvider)
        {
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            services.AddScoped<ApplicationContext>();
            services.AddScoped<BasicSeedManager>();
            services.AddScoped<ITransactionManager, TransactionManager>();   
        }
    }
}
