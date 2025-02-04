﻿using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.WebApi.Services;

namespace Chabagan.Fisheries.WebApi.Controllers.Stock
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchasesController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IPurchaseRepo _purchaseRepo;
        #endregion

        #region Constructors
        public PurchasesController(ILogger<PurchasesController> logger, IPurchaseRepo purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
            _logger = logger;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all Brands data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<PurchaaseInfo>>>> GetAllPurchasesAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _purchaseRepo.GetAllPurchasesAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single Purchase data from database by brand id
        /// </summary>
        /// <param name="brandId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<ProcessPurchase>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<ProcessPurchase>>> GetPurchaseByPurchaseIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _purchaseRepo.GetPurchaseByPurchaseIdAsync(id)));
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
            var invoiceInfo = await _purchaseRepo.GetPurchaseByPurchaseIdAsync(id);
            string fileName = $"Invoice_{id}_{randomName}_.pdf";

            if (invoiceInfo is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            var pdfBytes = PdfService.GeneratePdf(PDFContents.GetInvoice(invoiceInfo));

            // Return the PDF as a file
            if(download)
                return File(pdfBytes, "application/pdf", fileName);

            return File(pdfBytes, "application/pdf");
        }

        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPurchase>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPurchase>>> SavePurchaseAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Items is null)
                        throw new ArgumentNullException(nameof(model.Items));

                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _purchaseRepo.SavePurchaseAsync(model)));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPurchase>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPurchase>>> UpdatePurchaseAsync([FromBody] ProcessPurchase model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _purchaseRepo.UpdatePurchaseAsync(model)));
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
        [ProducesResponseType(typeof(APIOperationResultGeneric<DbPurchase>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<DbPurchase>>> DeletePurchaseByPurchaseIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _purchaseRepo.DeletePurchaseByPurchaseIdAsync(id)));
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
