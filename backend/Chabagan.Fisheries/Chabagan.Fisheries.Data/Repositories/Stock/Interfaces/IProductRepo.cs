using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Mapping;

namespace Chabagan.Fisheries.Data.Repositories.Stock.Interfaces
{
    public interface IProductRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all products data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwProduct>> GetAllProductsAsync();

        /// <summary>
        /// Get product dropdown
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DropdownModel>> GetProductDropdownAsync();

        /// <summary>
        /// Get a single product data from database by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<VwProduct> GetProductByProductIdAsync(long productId);
        /// <summary>
        /// Save Product information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwProduct> SaveProductAsync(VwProduct model);

        /// <summary>
        /// Update Product information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwProduct> UpdateProductAsync(VwProduct model);
        /// <summary>
        /// Delete a Product data by User id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<VwProduct> DeleteProductByProductIdAsync(long productId);
        #endregion
    }
}
