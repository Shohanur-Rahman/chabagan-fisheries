using Chabagan.Fisheries.Entities.Models.User;
using Chabagan.Fisheries.Mapping.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Fisheries.Data.Repositories.Administration.Interfaces
{
    public interface IRoleRepo
    {
        /// <summary>
        /// Get all roles data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DbRole>> GetAllRolesAsync();

        /// <summary>
        /// Get a single Roles data from database by Roles id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<DbRole?> GetRoleByRoleIdAsync(long roleId);
        /// <summary>
        /// Save Role information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbRole?> SaveRoleAsync(DbRole model);

        /// <summary>
        /// Update Role information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<DbRole?> UpdateRoleAsync(DbRole model);
        /// <summary>
        /// Delete a User data by User id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> DeleteRoleByRoleIdAsync(long roleId);
    }
}
