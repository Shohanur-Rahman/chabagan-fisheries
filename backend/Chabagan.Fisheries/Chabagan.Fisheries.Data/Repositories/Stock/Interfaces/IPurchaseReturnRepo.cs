using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IPurchaseReturnRepo
    {
        #region Public Methods

        /// <summary>
        /// Get all purchase returns data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PurchaaseInfo>> GetAllPurchaseReturnsAsync();

        /// <summary>
        /// Get a single purchase returns data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbPurchaseReturn?> GetPurchaseReturnByPurchaseIdAsync(long purchaseId);

        /// <summary>
        /// Save purchase returns information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbPurchaseReturn?> SavePurchaseReturnAsync(ProcessPurchase model);

        /// <summary>
        /// Update purchase returns information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbPurchaseReturn?> UpdatePurchaseReturnAsync(ProcessPurchase model);

        /// <summary>
        /// Delete a purchase returns data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        Task<DbPurchaseReturn?> DeletePurchaseReturnByPurchaseIdAsync(long purchaseId);

        #endregion
    }
}
