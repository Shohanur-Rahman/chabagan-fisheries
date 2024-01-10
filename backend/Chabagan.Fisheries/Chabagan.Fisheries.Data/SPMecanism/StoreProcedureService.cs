using Microsoft.Extensions.DependencyInjection;

namespace Chabagan.Fisheries.SPMecanism
{
    public static class StoreProcedureService
    {
        public static IServiceCollection AddStoredProcedure(this IServiceCollection services)
        {
            services.AddTransient<ISPConnection, SPConnection>();
            services.AddTransient<ISPCommand, SPCommand>();
            services.AddTransient<IStoredProcedure, StoredProcedure>();

            return services;
        }
    }
}
