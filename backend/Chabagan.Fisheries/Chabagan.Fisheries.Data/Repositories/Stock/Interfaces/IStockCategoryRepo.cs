using Chabagan.Fisheries.Entities.Mapping.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IStockCategoryRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all category data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwStockCategory>> GetAllStockCategoriesAsync();
        /// <summary>
        /// Get a single stock category data from database by category id
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        Task<VwStockCategory> GetStockCategoryByIdAsync(long catId);
        /// <summary>
        /// Save category information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwStockCategory> SaveStockCategoryAsync(VwStockCategory model);
        /// <summary>
        /// Update category information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwStockCategory> UpdateStockCategoryAsync(VwStockCategory model);
        /// <summary>
        /// Delete a category data by User id
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        Task<VwStockCategory> DeleteStockCategoryByIdAsync(long catId);
        #endregion
    }
}
