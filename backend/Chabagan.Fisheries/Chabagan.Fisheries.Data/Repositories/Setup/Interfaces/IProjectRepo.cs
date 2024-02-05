using Chabagan.Fisheries.Entities.Mapping;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Mapping;

namespace Chabagan.Fisheries.Data.Repositories.Setup.Interfaces
{
    public interface IProjectRepo
    {

        #region Public Methods
        /// <summary>
        /// Get all projects data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwProject>> GetAllProjectsAsync();

        /// <summary>
        /// Get project auto complete
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AutoCompleteModel>> GetProjectAutocompleteAsync();
        /// <summary>
        /// Get project dropdowns
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DropdownModel>> GetProjectsDropdownAsync();

        /// <summary>
        /// Get a single Project data from database by Project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<VwProject> GetProjectByProjectIdAsync(long projectId);

        /// <summary>
        /// Save project information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwProject> SaveProjectAsync(VwProject model);

        /// <summary>
        /// Update Project information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwProject> UpdateProjectAsync(VwProject model);

        /// <summary>
        /// Delete a Project data by User id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<VwProject> DeleteProjectByProjectIdAsync(long projectId);
        #endregion
    }
}
