using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using BLL.Infrastructure.RequestSignature;
using BLL.Request;
using Common;
using Common.Configuration;
using Configuration.IoC;
using Configuration.Mapping;
using CreditorGuard.Common;
using DAL.Context;
using DAL.Repositories.Infrastructure;
using DAL.Repositories.RepositoriesAbstract;
using DAL.Seed;
using DAL.SeedMamagers;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Web.Filters;
using Web.Identity;
using Log = Common.Log;


namespace Web
{
  public class Startup
  {
    public ICustomConfigurationProvider ConfigurationProvider { get; }

    public Startup(IHostingEnvironment env)
    {
      try
      {
        var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
        var configuration = builder.Build();

        ConfigurationProvider = new CustomConfigurationProvider(configuration, env.ContentRootPath);

        LoggerConfig.Configure(ConfigurationProvider);
      }
      catch (Exception e)
      {
        Log.Logger().Error(e, "Application failed to start");
        throw;
      }
    }

    public void ConfigureServices(IServiceCollection services)
    {
      try
      {
        Log.Logger().Information("Configure Dependency Injection...");
        DependencyMapper.Configure(services, ConfigurationProvider);

        services.Configure<FormOptions>(x => x.ValueCountLimit = int.MaxValue);

        Log.Logger().Information("Configure ApplicationContext...");
        services
          .AddDbContext<ApplicationContext>(options => options.UseSqlServer(ConfigurationProvider.ConnectionString));

        Log.Logger().Information("Configure MVC services...");
        var builder = services.AddMvc();
        builder.AddMvcOptions(x => x.Filters.Add(new GlobalExceptionHandler()));
        services.AddJwtBearerAuthentication();

      }
      catch (Exception e)
      {
        Log.Logger().Error(e, "Application failed to start");
        throw;
      }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, BasicSeedManager seedManager, MigrationManager migrationManager)
    {
      var stopwatch = Stopwatch.StartNew();
      try
      {
        loggerFactory.AddSerilog();

        Log.Logger().Information("Application is starting...");
        Log.Logger().Information("Configuration:");

        ConfigurationProvider.GetType().GetProperties().ToList().ForEach(prop =>
        {
          Log.Logger().Information("[{name}] = '{value}'", prop.Name,
            prop.GetValue(ConfigurationProvider));
        });

        DateTimeContext.Initialize(ConfigurationProvider.TimeZone);

        Log.Logger().Information("Configure EF Mappings...");
        MappingConfig.RegisterMappings();


        Log.Logger().Information("Configure Jwt Bearer Authentication...");
        app.ConfigJwtBearerMiddleware();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseMvc(routes =>
        {
          routes.MapRoute(
            name: "default",
            template: "{controller=Default}/{action=Index}/{id?}");

          routes.MapRoute(
            name: "admin",
            template: "{*url}",
            defaults: new { controller = "Default", action = "Index" }
          );
        });



        //app.Use(async (context, next) =>
        //{
        //  await next();
        //  if (context.Response.StatusCode == 404 &&
        //      !Path.HasExtension(context.Request.Path.Value) &&
        //      !context.Request.Path.Value.StartsWith("/api/"))
        //  {
        //    context.Request.Path = "/index.html";
        //    await next();
        //  }
        //});

        if (env.IsDevelopment())
        {
          app.UseDeveloperExceptionPage();

          migrationManager.ApplyMigrations(ConfigurationProvider);

          //seedManager.Seed();

        }
        else
        {
          app.UseExceptionHandler("/error");
        }
      }
      catch (Exception e)
      {
        Log.Logger().Error(e, "Application failed to start");
        throw;
      }
      finally
      {
        stopwatch.Stop();
        Log.Logger().Information("Startup time: {Seconds}s", stopwatch.Elapsed.Seconds);
      }
    }
    private void ConfigureRoute(IRouteBuilder routeBuilder)
    {
      routeBuilder.MapRoute("Default", "{controller = Default}/{action = Index}/{id?}");
      routeBuilder.MapRoute("Admin", "{*url}", new { controller = "Default", action = "Index" });
    }
  }
}
