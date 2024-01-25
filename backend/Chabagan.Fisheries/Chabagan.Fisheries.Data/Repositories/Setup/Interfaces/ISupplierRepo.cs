using Chabagan.Fisheries.Entities.Mapping;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Mapping;

namespace Chabagan.Fisheries.Data.Repositories.Setup.Interfaces
{
    public interface ISupplierRepo
    {
        #region Public Methods

        /// <summary>
        /// Get all supplier data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwSupplier>> GetAllSupplierAsync();

        /// <summary>
        /// Get supplier auto complete
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AutoCompleteModel>> GetSupplierAutocompleteAsync();

        /// <summary>
        /// Get all supplier dropdown
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DropdownModel>> GetSupplierDropdownAsync();

        /// <summary>
        /// Get a single Supplier data from database by Supplier id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        Task<VwSupplier> GetSupplierBySupplierIdAsync(long supplierId);

        /// <summary>
        /// Save Supplier information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwSupplier> SaveSupplierAsync(VwSupplier model);

        /// <summary>
        /// Update Supplier information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwSupplier> UpdateSupplierAsync(VwSupplier model);

        /// <summary>
        /// Delete a Supplier data by User id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        Task<VwSupplier> DeleteSupplierBySupplierIdAsync(long supplierId);

        #endregion
    }
}
