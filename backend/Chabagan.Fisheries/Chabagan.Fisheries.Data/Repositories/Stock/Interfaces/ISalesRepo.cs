using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface ISalesRepo
    {

        #region Public Methods

        /// <summary>
        /// Get all Sales data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PurchaaseInfo>> GetAllSalesAsync();

        /// <summary>
        /// Get a single Sales data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbSales?> GetSalesBySalesIdAsync(long purchaseId);

        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbSales?> SaveSalesAsync(ProcessPurchase model);

        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbSales?> UpdateSalesAsync(ProcessPurchase model);

        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbSales?> DeleteSalesBySalesIdAsync(long purchaseId);

        #endregion
    }
}
