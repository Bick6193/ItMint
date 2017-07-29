using System.Linq;
using System.Reflection;
using Common;
using Common.Configuration;
using Configuration.IoC;
using DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Log = Common.Log;


namespace WebApplication1
{
    public class Startup
    {
        //todo remuve after loggin setup
        public IConfigurationRoot Configuration { get; }

        public ICustomConfigurationProvider ConfigurationProvider { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            ConfigurationProvider = new CustomConfigurationProvider(Configuration, env.ContentRootPath);

            LoggerConfig.Configure(ConfigurationProvider);
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            DependencyMapper.Configure(services, ConfigurationProvider);

            services.AddEntityFramework().AddDbContext<ApplicationContext>(options => options.UseSqlServer(""));
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            Log.Logger().Information("Application is starting...");

            Log.Logger().Information("Configuration:");

            ConfigurationProvider.GetType().GetProperties().ToList().ForEach(prop => { Log.Logger().Information("[{name}] = '{value}'", prop.Name, prop.GetValue(ConfigurationProvider)); });

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            //todo find out ????
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });
        }
    }
}
