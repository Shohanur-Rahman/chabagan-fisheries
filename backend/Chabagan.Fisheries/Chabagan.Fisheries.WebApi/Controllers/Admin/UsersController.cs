using Chabagan.Chabagan.Fisheries.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Mapping.User;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Common.Enums;
using Chabagan.Fisheries.Common.Models;
using Chabagan.Fisheries.Entities.Mapping.User;
using Microsoft.AspNetCore.Authorization;

namespace Chabagan.Fisheries.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IUserRepo _userRepo;
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
        /// <param name="UserRepo">Inject User</param>
        /// <param name="helperService">Inject helpers</param>
        public UsersController(ILogger<UsersController> logger, IUserRepo UserRepo, IHelperService helperService)
        {
            _userRepo = UserRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion

        #region Public Methods and Endpoints
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwUserResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwUserResponse>>>> GetAllUserAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _userRepo.GetAllUsersAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwUserResponse>>> GetUserByUserIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _userRepo.GetUserByUserIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwUserResponse>>> SaveUserAsync([FromForm] VwUser model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Users.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }

                    return Ok(APIOperationResult.Success(await _userRepo.SaveUserAsync(model)));
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
        /// Update user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwUserResponse>>> UpdateUserAsync([FromForm] VwUser model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Users.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }
                    return Ok(APIOperationResult.Success(await _userRepo.UpdateUserAsync(model)));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwUserResponse>>> DeleteUserByUserIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _userRepo.DeleteUserByUserIdAsync(id)));
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
