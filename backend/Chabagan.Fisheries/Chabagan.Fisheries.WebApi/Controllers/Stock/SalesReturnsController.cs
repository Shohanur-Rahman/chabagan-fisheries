using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chabagan.Fisheries.WebApi.Controllers.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesReturnsController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly ISalesReturnRepo _salesReturnRepo;

        private readonly PdfService _pdfService;
        #endregion

        #region Constructors
        public SalesReturnsController(ILogger<SalesReturnsController> logger, ISalesReturnRepo salesReturnRepo, PdfService pdfService)
        {
            _salesReturnRepo = salesReturnRepo;
            _logger = logger;
            _pdfService = pdfService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all sales data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>>> GetAllSalesReturnsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _salesReturnRepo.GetAllSalesReturnsAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single sales data from database by sales id
        /// </summary>
        /// <param name="brandId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSalesReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSalesReturn>>> GetSalesReturnsBySalesReturnsIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _salesReturnRepo.GetSalesReturnsBySalesReturnsIdAsync(id)));
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
            var invoiceInfo = await _salesReturnRepo.GetSalesReturnsBySalesReturnsIdAsync(id);
            //string fileName = $"Invoice_{id}_{randomName}_.pdf";

            if (invoiceInfo is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            //var pdfBytes = new byte[];// _pdfService.GeneratePdf(PDFContents.GetPurchaseInvoice(invoiceInfo));

            // Return the PDF as a file
            return File("", "application/pdf");
        }

        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSalesReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSalesReturn>>> SaveSalesReturnsAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Items is null)
                        throw new ArgumentNullException(nameof(model.Items));

                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _salesReturnRepo.SaveSalesReturnsAsync(model)));
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
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSalesReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSalesReturn>>> UpdateSalesReturnAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _salesReturnRepo.UpdateSalesReturnAsync(model)));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSalesReturn>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSalesReturn>>> DeleteSalesReturnBySalesReturnIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _salesReturnRepo.DeleteSalesReturnBySalesReturnIdAsync(id)));
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
