using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;

namespace Chabagan.Fisheries.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IBrandRepo _brandRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion

        #region Constructors
        public BrandsController(ILogger<BrandsController> logger, IBrandRepo brandRepo, IHelperService helperService)
        {
            _brandRepo = brandRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all Brands data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwBrand>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwBrand>>>> GetAllBrandsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _brandRepo.GetAllBrandsAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single Brand data from database by brand id
        /// </summary>
        /// <param name="brandId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwBrand>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwBrand>>> GetBrandByBrandIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _brandRepo.GetBrandByBrandIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save Brand information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwBrand>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwBrand>>> SaveBrandAsync([FromBody] VwBrand model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _brandRepo.SaveBrandAsync(model)));
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
        /// Update Brand information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwBrand>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwBrand>>> UpdateBrandAsync([FromBody] VwBrand model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _brandRepo.UpdateBrandAsync(model)));
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
        /// Delete category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeleteBrandByBrandIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _brandRepo.DeleteBrandByBrandIdAsync(id)));
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
