using Chabagan.Fisheries.Entities.Mapping.Stock;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IPurchaseRepo
    {

        #region Public Methods
        /// <summary>
        /// Get all purchase data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwPurchase>> GetAllPurchasesAsync();
        /// <summary>
        /// Get a single Purchase data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<VwPurchase> GetPurchaseByPurchaseIdAsync(long purchaseId);
        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwPurchase> SavePurchaseAsync(VwPurchase model);
        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwPurchase> UpdatePurchaseAsync(VwPurchase model);
        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<VwPurchase> DeletePurchaseByPurchaseIdAsync(long purchaseId);
        #endregion
    }
}
