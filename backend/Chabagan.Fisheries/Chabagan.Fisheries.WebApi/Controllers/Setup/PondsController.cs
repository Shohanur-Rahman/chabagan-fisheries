using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Mapping;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chabagan.Fisheries.Common.Models;
using Chabagan.Fisheries.Common.Enums;

namespace Chabagan.Fisheries.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class PondsController : BaseController
    {

        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IPondRepo _pondRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion


        #region Constructors
        public PondsController(ILogger<PondsController> logger, IPondRepo pondRepo, IHelperService helperService)
        {
            _pondRepo = pondRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all pond data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwPond>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwPond>>>> GetAllPondsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _pondRepo.GetAllPondsAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        /// <summary>
        /// Get all ponds by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        /// 
        [Route("by-project/{projectId}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwPond>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwPond>>>> GetAllPondsByProjectIdAsync(long projectId)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _pondRepo.GetAllPondsByProjectIdAsync(projectId)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get all pond dropdown
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("dropdown")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<DropdownModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<DropdownModel>>>> GetPondsDropdownAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _pondRepo.GetPondsDropdownAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single pond data from database by pond id
        /// </summary>
        /// <param name="pondId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwPond>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwPond>>> GetPondByPondIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _pondRepo.GetPondByPondIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save pond information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwPond>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwPond>>> SavePondAsync([FromForm] VwPond model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Ponds.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }

                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _pondRepo.SavePondAsync(model)));
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
        /// Update pond information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwPond>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwPond>>> UpdatePondAsync([FromForm] VwPond model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Ponds.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _pondRepo.UpdatePondAsync(model)));
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
        /// Delete a pond data by User id
        /// </summary>
        /// <param name="pondId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeletePondByPondIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _pondRepo.DeletePondByPondIdAsync(id)));
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
