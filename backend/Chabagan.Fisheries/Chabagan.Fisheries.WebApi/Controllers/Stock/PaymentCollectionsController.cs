using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Chabagan.Fisheries.Common.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chabagan.Fisheries.WebApi.Controllers.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PaymentCollectionsController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IPaymentCollectionRepo _paymentCollectionRepo;
        #endregion


        #region Constructors
        public PaymentCollectionsController(ILogger<PaymentCollectionsController> logger, IPaymentCollectionRepo paymentCollectionRepo)
        {
            _paymentCollectionRepo = paymentCollectionRepo;
            _logger = logger;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all payments data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet("payments")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<PaymentCollectionGrid>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<PaymentCollectionGrid>>>> GetAllPaymentsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _paymentCollectionRepo.GetAllPaymentCollectionsAsync((int) TransectionTypeEnum.Payment)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        [HttpGet("collections")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<PaymentCollectionGrid>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<PaymentCollectionGrid>>>> GetAllCollectionsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _paymentCollectionRepo.GetAllPaymentCollectionsAsync((int)TransectionTypeEnum.Collection)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single payment data from database by id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPaymentCollection>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPaymentCollection>>> GetPaymentCollectionByIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _paymentCollectionRepo.GetPaymentCollectionByIdAsync(id)));
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
            var invoiceInfo = await _paymentCollectionRepo.GetPaymentCollectionByIdAsync(id);
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
        /// Save payment information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPaymentCollection>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPaymentCollection>>> SavePaymentCollectionAsync([FromBody] ProcessPaymentCollection model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model is null)
                        throw new ArgumentNullException(nameof(model));

                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _paymentCollectionRepo.SavePaymentCollectionAsync(model)));
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
        /// Update payment information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPaymentCollection>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPaymentCollection>>> UpdatePaymentCollectionAsync([FromBody] ProcessPaymentCollection model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _paymentCollectionRepo.UpdatePaymentCollectionAsync(model)));
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
        /// Delete payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPaymentCollection>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPaymentCollection>>> DeletePaymentCollectionByIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _paymentCollectionRepo.DeletePaymentCollectionByIdAsync(id)));
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
