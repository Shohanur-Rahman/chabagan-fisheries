using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Fisheries.Data.Repositories.Setup.Interfaces
{
    public interface IPondRepo
    {

        #region Public Methods
        /// <summary>
        /// Get all Ponds data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwPond>> GetAllPondsAsync();

        /// <summary>
        /// Get all ponds by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<VwPond>> GetAllPondsByProjectIdAsync(long projectId);

        /// <summary>
        /// Get Pond dropdowns
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DropdownModel>> GetPondsDropdownAsync();

        /// <summary>
        /// Get a single Pond data from database by Pond id
        /// </summary>
        /// <param name="pondId"></param>
        /// <returns></returns>
        Task<VwPond> GetPondByPondIdAsync(long pondId);

        /// <summary>
        /// Save Pond information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwPond> SavePondAsync(VwPond model);
        /// <summary>
        /// Update Pond information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwPond> UpdatePondAsync(VwPond model);

        /// <summary>
        /// Delete a Pond data by User id
        /// </summary>
        /// <param name="PondId"></param>
        /// <returns></returns>
        Task<VwPond> DeletePondByPondIdAsync(long PondId);

        #endregion
    }
}
