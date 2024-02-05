using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IPurchaseRepo
    {

        #region Public Methods
        /// <summary>
        /// Get all purchase data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PurchaaseInfo>> GetAllPurchasesAsync();
        /// <summary>
        /// Get a single Purchase data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbPurchase?> GetPurchaseByPurchaseIdAsync(long purchaseId);
        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbPurchase?> SavePurchaseAsync(ProcessPurchase model);
        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbPurchase?> UpdatePurchaseAsync(ProcessPurchase model);
        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbPurchase?> DeletePurchaseByPurchaseIdAsync(long purchaseId);
        #endregion
    }
}
