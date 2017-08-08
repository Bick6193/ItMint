using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Web.Filters;
using Web.Identity;
using Log = Common.Log;


namespace WebApplication1
{
    public class Startup
    {
      private static readonly string secretKey = "mysupersecret_secretkey!123";
      private static readonly string issure = "AltairCA";
      private static readonly string audience = "AltairCAAudience";

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

          //start jwt token config
          var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
          //generate token

          var jwtOptions = new TokenProviderOptions
          {
            Audience = audience,
            Issuer = issure,
            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
          };

          app.UseMiddleware<TokenProviderMiddleware>(Options.Create(jwtOptions));

          //validation key


          var tokenValidationParameters = new TokenValidationParameters
          {
            //The signing key must match !
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            //Validate the JWT Issuer (iss) claim
            ValidateIssuer = true,
            ValidIssuer = issure,

            //validate the JWT Audience (aud) claim

            ValidateAudience = true,
            ValidAudience = audience,

            //validate the token expiry
            ValidateLifetime = true,

            // If you  want to allow a certain amout of clock drift
            ClockSkew = TimeSpan.Zero
          };

          app.UseJwtBearerAuthentication(new JwtBearerOptions
          {
            AutomaticAuthenticate = false,
            AutomaticChallenge = true,
            TokenValidationParameters = tokenValidationParameters,
            AuthenticationScheme = "Bearer"
          });

          //end jwt token config
          app.UseApplicationInsightsRequestTelemetry();


          app.UseDefaultFiles();
          app.UseStaticFiles();

          app.UseMvcWithDefaultRoute();

          //app.UseMvc(routes =>
          //{
          //    routes.MapRoute(
          //        name: "default",
          //        template: "{controller=Default}/{action=Index}/{id?}");
          //});

          app.UseMvc();

          app.Use(async (context, next) =>
          {
            await next();
            if (context.Response.StatusCode == 404 &&
                !Path.HasExtension(context.Request.Path.Value) &&
                !context.Request.Path.Value.StartsWith("/api/"))
            {
              context.Request.Path = "/index.html";
              await next();
            }
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
