using Chabagan.Fisheries.Entities.Mapping.Stock;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IPurchaseItemRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all purchase items data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProcessPurchaseItem>> GetAllPurchaseItemsByPurchaseIdAsync(long purchaseId);

        /// <summary>
        /// Get a single purchase item data from database by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<ProcessPurchaseItem> GetPurchaseItemByItemIdAsync(long itemId);
        /// <summary>
        /// Save Purchase item information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProcessPurchaseItem> SavePurchaseItemAsync(ProcessPurchaseItem model);
        /// <summary>
        /// Update Purchase Item information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProcessPurchaseItem> UpdatePurchaseItemAsync(ProcessPurchaseItem model);
        /// <summary>
        /// Delete a Purchase Item data by item id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<ProcessPurchase> DeletePurchaseItemByItemIdAsync(long purchaseId);

        #endregion
    }
}
