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
    public class StockCategoriesController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IStockCategoryRepo _stockCategoryRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion


        #region Constructors
        public StockCategoriesController(ILogger<StockCategoriesController> logger, IStockCategoryRepo stockRepo, IHelperService helperService)
        {
            _stockCategoryRepo = stockRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all category data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwStockCategory>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwStockCategory>>>> GetAllBrandsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _stockCategoryRepo.GetAllStockCategoriesAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single category data from database by brand id
        /// </summary>
        /// <param name="brandId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwStockCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwStockCategory>>> GetStockCategoryByIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _stockCategoryRepo.GetStockCategoryByIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save category information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwStockCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwStockCategory>>> SaveStockCategoryAsync([FromBody] VwStockCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _stockCategoryRepo.SaveStockCategoryAsync(model)));
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
        /// Update category information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwStockCategory>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwStockCategory>>> UpdateStockCategoryAsync([FromBody] VwStockCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _stockCategoryRepo.UpdateStockCategoryAsync(model)));
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
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeleteStockCategoryByIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _stockCategoryRepo.DeleteStockCategoryByIdAsync(id)));
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
