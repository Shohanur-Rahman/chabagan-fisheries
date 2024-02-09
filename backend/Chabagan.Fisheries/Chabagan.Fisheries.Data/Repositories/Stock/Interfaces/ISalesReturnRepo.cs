using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface ISalesReturnRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all Sales returns data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PurchaaseInfo>> GetAllSalesReturnsAsync();

        /// <summary>
        /// Get a single Sales Returns data from database by Sales Returns id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbSalesReturn?> GetSalesReturnsBySalesReturnsIdAsync(long purchaseId);

        /// <summary>
        /// Save Sales Returns information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbSalesReturn?> SaveSalesReturnsAsync(ProcessPurchase model);

        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbSalesReturn?> UpdateSalesReturnAsync(ProcessPurchase model);


        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbSalesReturn?> DeleteSalesReturnBySalesReturnIdAsync(long purchaseId);

        #endregion
    }
}
