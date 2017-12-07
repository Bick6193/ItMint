using BLL;
using BLL.Infrastructure;
using BLL.Infrastructure.RequestSignature;
using BLL.Request;
using Microsoft.Extensions.DependencyInjection;
using Common.Configuration;
using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Infrastructure;
using DAL.Repositories.RepositoriesAbstract;
using DAL.Seed;
using DAL.SeedMamagers;
using Domain.RegistrationMailData;
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
      services.AddScoped<IRequestRepository, RequestRepository>();
      services.AddScoped<IRequestGetService, RequestGetService>();
      services.AddScoped<IFileService, FileService>();
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IAuthRepository, AuthRepository>();
      services.AddScoped<IFileRepository, FileRepository>();
      services.AddScoped<ISetPasswordIdentity, SetPasswordIdentity>();
      services.AddScoped<IRequestTypesService, RequestTypesService>();
      services.AddScoped<IRequestTypesRepository, RequestTypesRepository>();
      services.AddScoped<IProjectService, ProjectService>();
      services.AddScoped<IProjectRepository, ProjectRepository>();
      services.AddScoped<ApplicationContext>();
      services.AddScoped<MigrationManager>();
      services.AddScoped<BasicSeedManager>();
      services.AddScoped<ITransactionManager, TransactionManager>();
    }
  }
}
