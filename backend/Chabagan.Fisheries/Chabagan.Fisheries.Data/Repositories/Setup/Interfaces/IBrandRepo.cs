using Chabagan.Fisheries.Entities.Mapping.Setup;

namespace Chabagan.Fisheries.Data.Repositories.Setup.Interfaces
{
    public interface IBrandRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all Brands data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwBrand>> GetAllBrandsAsync();

        /// <summary>
        /// Get a single Brand data from database by brand id
        /// </summary>
        /// <param name="brandId"></param>
        Task<VwBrand> GetBrandByBrandIdAsync(long brandId);

        /// <summary>
        /// Save Brand information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwBrand> SaveBrandAsync(VwBrand model);

        /// <summary>
        /// Update Brand information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwBrand> UpdateBrandAsync(VwBrand model);

        /// <summary>
        /// Delete a Brand data by User id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        Task<VwBrand> DeleteBrandByBrandIdAsync(long brandId);

        #endregion
    }
}
