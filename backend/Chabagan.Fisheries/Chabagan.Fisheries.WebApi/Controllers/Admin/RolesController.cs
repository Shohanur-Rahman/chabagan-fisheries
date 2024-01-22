using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chabagan.Fisheries.Entities.Models.User;
using Microsoft.AspNetCore.Authorization;

namespace Chabagan.Fisheries.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IRoleRepo _roleRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion

        #region Constructors

        /// <summary>
        /// Call instantly
        /// </summary>
        /// <param name="logger">Inject Logger</param>
        /// <param name="roleRepo">Inject User</param>
        /// <param name="helperService">Inject helpers</param>
        public RolesController(ILogger<RolesController> logger, IRoleRepo roleRepo, IHelperService helperService)
        {
            _roleRepo = roleRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion

        #region Public Methods and Endpoints
        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<DbRole>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<DbRole>>>> GetAllRolesAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _roleRepo.GetAllRolesAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbRole>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbRole>>> GetRoleByRoleIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _roleRepo.GetRoleByRoleIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbRole>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbRole>>> SaveUserAsync([FromBody] DbRole model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(APIOperationResult.Success(await _roleRepo.SaveRoleAsync(model)));
                }

                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ResponseMessage.BadRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbRole>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbRole>>> UpdateRoleAsync([FromBody] DbRole model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(APIOperationResult.Success(await _roleRepo.UpdateRoleAsync(model)));
                }

                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ResponseMessage.BadRequest));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeleteRoleByRoleIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _roleRepo.DeleteRoleByRoleIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        #endregion
    }
}
