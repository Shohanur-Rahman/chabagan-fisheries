using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chabagan.Fisheries.Mapping;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Mapping;
using Chabagan.Fisheries.Entities.Mapping.Visualization;

namespace Chabagan.Fisheries.WebApi.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuppliersController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly ISupplierRepo _supplierRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion

        #region Constructors
        public SuppliersController(ILogger<SuppliersController> logger, ISupplierRepo supplierRepo, IHelperService helperService)
        {
            _supplierRepo = supplierRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all supplier data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwSupplier>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwSupplier>>>> GetAllSupplierAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _supplierRepo.GetAllSupplierAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        /// <summary>
        /// Get supplier auto complete
        /// </summary>
        /// <returns></returns>
        [Route("transections")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<List<TransectionSummary>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIOperationResultGeneric<List<TransectionSummary>>> GetSupplierTransectionSummary()
        {
            try
            {
                return Ok(APIOperationResult.Success(_supplierRepo.GetSupplierTransectionSummary(null)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        [Route("transection/{supplierId}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<List<TransectionSummary>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIOperationResultGeneric<List<TransectionSummary>>> GetSupplierTransectionSummaryBySupplierId(long supplierId)
        {
            try
            {
                return Ok(APIOperationResult.Success(_supplierRepo.GetSupplierTransectionSummary(supplierId).FirstOrDefault()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get supplier auto complete
        /// </summary>
        /// <returns></returns>
        [Route("autocomplete")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<AutoCompleteModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<AutoCompleteModel>>>> GetSupplierAutocompleteAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _supplierRepo.GetSupplierAutocompleteAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get all supplier dropdown
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("dropdown")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<DropdownModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<DropdownModel>>>> GetSupplierDropdownAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _supplierRepo.GetSupplierDropdownAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single Supplier data from database by Supplier id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwSupplier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwSupplier>>> GetSupplierBySupplierIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _supplierRepo.GetSupplierBySupplierIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save Supplier information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwSupplier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwSupplier>>> SaveSupplierAsync([FromBody] VwSupplier model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _supplierRepo.SaveSupplierAsync(model)));
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
        /// Update Supplier information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwSupplier>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwSupplier>>> UpdateSupplierAsync([FromBody] VwSupplier model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _supplierRepo.UpdateSupplierAsync(model)));
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
        /// Delete a Supplier data by User id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeleteSupplierBySupplierIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _supplierRepo.DeleteSupplierBySupplierIdAsync(id)));
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
