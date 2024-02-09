using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chabagan.Fisheries.WebApi.Controllers.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseReturnsController : BaseController
    {

        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IPurchaseReturnRepo _purchaseRepo;
        #endregion

        #region Constructors
        public PurchaseReturnsController(ILogger<PurchaseReturnsController> logger, IPurchaseReturnRepo purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
            _logger = logger;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all purchase returns data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>>> GetAllPurchaseReturnsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _purchaseRepo.GetAllPurchaseReturnsAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single Purchase return data from database by id
        /// </summary>
        /// <param name="brandId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<ProcessPurchase>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<ProcessPurchase>>> GetPurchaseReturnByPurchaseIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _purchaseRepo.GetPurchaseReturnByPurchaseIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        [HttpGet("invoice")]
        [AllowAnonymous]
        public async Task<IActionResult> Invoice(long id)
        {
            //string randomName = Guid.NewGuid().ToString();
            var invoiceInfo = await _purchaseRepo.GetPurchaseReturnByPurchaseIdAsync(id);
            //string fileName = $"Invoice_{id}_{randomName}_.pdf";

            if (invoiceInfo is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            var pdfBytes = PdfService.GeneratePdf(PDFContents.GetPurchaseReturnInvoice(invoiceInfo));

            // Return the PDF as a file
            return File(pdfBytes, "application/pdf");
        }

        /// <summary>
        /// Save Purchase return information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPurchaseReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPurchaseReturn>>> SavePurchaseReturnAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Items is null)
                        throw new ArgumentNullException(nameof(model.Items));

                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _purchaseRepo.SavePurchaseReturnAsync(model)));
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
        /// Update Purchase return information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPurchaseReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPurchaseReturn>>> UpdatePurchaseReturnAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _purchaseRepo.UpdatePurchaseReturnAsync(model)));
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
        /// Delete Purchase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPurchaseReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPurchaseReturn>>> DeletePurchaseReturnByPurchaseIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _purchaseRepo.DeletePurchaseReturnByPurchaseIdAsync(id)));
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
