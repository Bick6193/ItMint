using Microsoft.Extensions.DependencyInjection;
using Common.Configuration;

namespace Configuration.IoC
{
    public class DependencyMapper
    {
        public static void Configure(IServiceCollection services, ICustomConfigurationProvider ConfigurationProvider)
        {
            //services.AddScoped<ICharacterRepository, CharacterRepository>();
        }
    }
}
