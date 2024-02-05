using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Mapping;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Chabagan.Fisheries.Common.Enums;
using Chabagan.Fisheries.Common.Models;
using Chabagan.Fisheries.Entities.Mapping;

namespace Chabagan.Fisheries.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IProjectRepo _projectRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion


        #region Constructors
        public ProjectsController(ILogger<ProjectsController> logger, IProjectRepo projectRepo, IHelperService helperService)
        {
            _projectRepo = projectRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all project data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwProject>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwProject>>>> GetAllProjectsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _projectRepo.GetAllProjectsAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        /// <summary>
        /// Get project auto complete
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("autoComplete")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<AutoCompleteModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<AutoCompleteModel>>>> GetProjectAutocompleteAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _projectRepo.GetProjectAutocompleteAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        /// <summary>
        /// Get all project dropdown
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("dropdown")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<DropdownModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<DropdownModel>>>> GetProjectsDropdownAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _projectRepo.GetProjectsDropdownAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single project data from database by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwProject>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwProject>>> GetProjectByProjectIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _projectRepo.GetProjectByProjectIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save project information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwProject>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwProject>>> SaveProjectAsync([FromForm] VwProject model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Projects.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }
                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _projectRepo.SaveProjectAsync(model)));
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
        /// Update project information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwProject>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwProject>>> UpdateProjectAsync([FromForm] VwProject model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Projects.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _projectRepo.UpdateProjectAsync(model)));
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
        /// Delete a project data by User id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeleteProjectByProjectIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _projectRepo.DeleteProjectByProjectIdAsync(id)));
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
