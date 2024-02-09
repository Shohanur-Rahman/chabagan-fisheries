using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Chabagan.Fisheries.WebApi.Services;
using Chabagan.Fisheries.WebApi.Utilities.Interfaces;

namespace Chabagan.Fisheries.WebApi.Utilities
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddTransient<IHelperService, HelperService>();
            services.AddTransient<IConfigSettings, ConfigSettings>();
            return services;
        }
    }
}
