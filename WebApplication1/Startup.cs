using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Common;
using Common.Configuration;
using Configuration.IoC;
using Configuration.Mapping;
using CreditorGuard.Common;
using DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Web.Filters;
using Log = Common.Log;


namespace WebApplication1
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

                services.AddEntityFramework().AddDbContext<ApplicationContext>(options => options.UseSqlServer(""));
            
                var builder = services.AddMvc();

                builder.AddMvcOptions(x => x.Filters.Add(new GlobalExceptionHandler()));
            }
            catch (Exception e)
            {
                Log.Logger().Error(e, "Application failed to start");
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
                
                //todo find out ????
                if (env.IsDevelopment())
                {
                   // app.UseDeveloperExceptionPage();
                   // app.UseBrowserLink();
                }

                app.UseStaticFiles();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Default}/{action=Index}/{id?}");
                });

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
    }
}
