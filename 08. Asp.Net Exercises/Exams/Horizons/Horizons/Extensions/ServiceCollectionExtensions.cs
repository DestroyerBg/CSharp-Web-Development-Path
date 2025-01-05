using Horizons.Automapper;
using Horizons.Services;
using Horizons.Services.Interfaces;
namespace Horizons.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static  IServiceCollection RegisterUserDefinedServices(this IServiceCollection services)
        {
            services.AddScoped<ITerrainService, TerrainService>();
            services.AddScoped<IDestinationService, DestinationService>();
            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DestinationProfiles).Assembly));
            return services;
        }
    }
}
