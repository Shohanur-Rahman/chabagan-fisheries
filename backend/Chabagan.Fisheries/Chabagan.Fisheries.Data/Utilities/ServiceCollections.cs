using Chabagan.Chabagan.Fisheries.Repositories.Administration.Interfaces;
using Chabagan.Chabagan.Fisheries.Repositories.Administration;
using Microsoft.Extensions.DependencyInjection;
using Chabagan.Fisheries.Data.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.Data.Repositories.Administration;

namespace Chabagan.Fisheries.Data.Utilities
{
    public static class ServiceCollections
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IRoleRepo, RoleRepo>();
            return services;
        }
    }
}
