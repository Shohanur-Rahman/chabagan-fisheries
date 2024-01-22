using Chabagan.Fisheries.Entities.Mapping.User;
using Chabagan.Fisheries.Mapping.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chabagan.Chabagan.Fisheries.Repositories.Administration.Interfaces
{
    public interface IUserRepo
    {
        #region Public Methods
        /// <summary>
        /// Get all User data from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VwUserResponse>> GetAllUsersAsync();

        /// <summary>
        /// Get a single User data from database by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<VwUserResponse> GetUserByUserIdAsync(long UserId);

        /// <summary>
        /// Get user by registered email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<VwUserResponse> GetUserByEmailAsync(string email);

        /// <summary>
        /// Save User information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwUserResponse> SaveUserAsync(VwUser model);

        /// <summary>
        /// Update User information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwUserResponse> UpdateUserAsync(VwUser model);

        /// <summary>
        /// Delete a User data by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<VwUserResponse> DeleteUserByUserIdAsync(long userId);
        /// <summary>
        /// Get authenticate user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VwUserResponse> GetAutheticateUser(VwLogin model);

        #endregion
    }
}
