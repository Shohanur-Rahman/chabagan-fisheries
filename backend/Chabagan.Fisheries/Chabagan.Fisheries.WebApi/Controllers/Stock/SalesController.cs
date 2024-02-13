using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock;
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
    public class SalesController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly ISalesRepo _salesRepo;
        #endregion

        #region Constructors
        public SalesController(ILogger<SalesController> logger, ISalesRepo salesRepo)
        {
            _salesRepo = salesRepo;
            _logger = logger;

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
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>>> GetAllSalesAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _salesRepo.GetAllSalesAsync()));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSales>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSales>>> GetSalesBySalesIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _salesRepo.GetSalesBySalesIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        [HttpGet("invoice")]
        [AllowAnonymous]
        public async Task<IActionResult> Invoice(long id, bool download = false)
        {
            string randomName = Guid.NewGuid().ToString();
            var invoiceInfo = await _salesRepo.GetSalesBySalesIdAsync(id);
            string fileName = $"Invoice_{id}_{randomName}_.pdf";

            if (invoiceInfo is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            var pdfBytes = PdfService.GeneratePdf(PDFContents.GetInvoice(invoiceInfo));

            // Return the PDF as a file
            if (download)
                return File(pdfBytes, "application/pdf", fileName);

            return File(pdfBytes, "application/pdf");
        }

        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSales>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSales>>> SaveSalesAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Items is null)
                        throw new ArgumentNullException(nameof(model.Items));

                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _salesRepo.SaveSalesAsync(model)));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSales>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSales>>> UpdateSalesAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _salesRepo.UpdateSalesAsync(model)));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbSales>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbSales>>> DeleteSalesBySalesIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _salesRepo.DeleteSalesBySalesIdAsync(id)));
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
