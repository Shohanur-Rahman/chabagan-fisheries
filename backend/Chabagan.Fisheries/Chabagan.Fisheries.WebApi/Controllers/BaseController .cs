using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chabagan.Fisheries.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        #region public Methods

        /// <summary>
        /// Get logged in user id
        /// </summary>
        /// <returns></returns>
        protected long GetLoggedInUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(!string.IsNullOrEmpty(userId) )
                return Convert.ToInt64(userId);
            return 0;
        }

        /// <summary>
        /// Get logged in user 
        /// </summary>
        /// <returns></returns>
        protected string? GetLoggedInUserName()
        {
            return User.FindFirst(ClaimTypes.Name)?.Value;
        }

        protected string? GetLoggedInUserEmail()
        {
            return User.FindFirst(ClaimTypes.Email)?.Value;
        }

        protected string? GetLoggedInUserRole()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value;
        }
        #endregion
    }
}
