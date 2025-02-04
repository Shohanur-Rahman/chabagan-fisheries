﻿using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chabagan.Fisheries.Common.Enums;
using Chabagan.Fisheries.Common.Models;
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
    public class ProductsController : BaseController
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IProductRepo _productRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        #endregion


        #region Constructors
        public ProductsController(ILogger<ProductsController> logger, IProductRepo productRepo, IHelperService helperService)
        {
            _productRepo = productRepo;
            _logger = logger;
            _helperService = helperService;

        }
        #endregion


        #region Public Methods and Endpoints
        /// <summary>
        /// Get all Products data from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<VwProduct>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<VwProduct>>>> GetAllProductsAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _productRepo.GetAllProductsAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        [Route("stocks")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<ProductStock>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIOperationResultGeneric<IEnumerable<ProductStock>>> GetProductStocks(long? productId, long? brandId)
        {
            try
            {
                return Ok(APIOperationResult.Success(_productRepo.GetProductStocks(productId, brandId)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        [Route("stock/{productId}")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<ProductStock>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<APIOperationResultGeneric<ProductStock>> GetProductStockByProductId(long productId, long? brandId)
        {
            try
            {
                if(productId <=0)
                    throw new ArgumentNullException(ResponseMessage.BadRequest);

                return Ok(APIOperationResult.Success(_productRepo.GetProductStocks(productId, brandId).FirstOrDefault()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }


        [Route("autoComplete")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<AutoCompleteModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<AutoCompleteModel>>>> GetProductAutocompleteAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _productRepo.GetProductAutocompleteAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get product dropdown
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("dropdown")]
        [HttpGet]
        [ProducesResponseType(typeof(APIOperationResultGeneric<IEnumerable<DropdownModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<IEnumerable<DropdownModel>>>> GetProductDropdownAsync()
        {
            try
            {
                return Ok(APIOperationResult.Success(await _productRepo.GetProductDropdownAsync()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Get a single Product data from database by Product id
        /// </summary>
        /// <param name="ProductId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwProduct>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwProduct>>> GetProductByProductIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _productRepo.GetProductByProductIdAsync(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }

        /// <summary>
        /// Save Product information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwProduct>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwProduct>>> SaveProductAsync([FromForm] VwProduct model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Products.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }
                    model.CreatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _productRepo.SaveProductAsync(model)));
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
        /// Update Product information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(APIOperationResultGeneric<VwProduct>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<VwProduct>>> UpdateProductAsync([FromForm] VwProduct model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Attachment is not null)
                    {
                        FileResponse? fileResponse = await _helperService.UploadFileLocalyAndGetUrl(model.Attachment, LocalStorageFolders.Products.ToString());

                        model.Avatar = fileResponse?.FilePath;
                    }
                    model.UpdatedBy = GetLoggedInUserId();
                    return Ok(APIOperationResult.Success(await _productRepo.UpdateProductAsync(model)));
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
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(APIOperationResultGeneric<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIOperationResultGeneric<bool>>> DeleteProductByProductIdAsync(long id)
        {
            try
            {
                return Ok(APIOperationResult.Success(await _productRepo.DeleteProductByProductIdAsync(id)));
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
