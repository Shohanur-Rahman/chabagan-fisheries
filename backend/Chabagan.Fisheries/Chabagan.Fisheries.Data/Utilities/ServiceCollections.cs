using Chabagan.Chabagan.Fisheries.Repositories.Administration.Interfaces;
using Chabagan.Chabagan.Fisheries.Repositories.Administration;
using Microsoft.Extensions.DependencyInjection;
using Chabagan.Fisheries.Data.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.Data.Repositories.Administration;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Data.Repositories.Stock;
using Chabagan.Fisheries.Data.Repositories.Setup;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;

namespace Chabagan.Fisheries.Data.Utilities
{
    public static class ServiceCollections
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IRoleRepo, RoleRepo>();


            services.AddTransient<IBrandRepo, BrandRepo>();
            services.AddTransient<IStockCategoryRepo, StockCategoryRepo>();
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<ISupplierRepo, SupplierRepo>();
            services.AddTransient<IProjectRepo, ProjectRepo>();
            services.AddTransient<IPondRepo, PondRepo>();


            services.AddTransient<IPurchaseRepo, PurchaseRepo>();
            services.AddTransient<IPurchaseItemRepo, PurchaseItemRepo>();
            services.AddTransient<IPurchaseReturnRepo, PurchaseReturnRepo>();
            services.AddTransient<ISalesRepo, SalesRepo>();

            return services;
        }
    }
}
