﻿using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Mapping.Visualization;
using Chabagan.Fisheries.Entities.Models.Setup;
using Chabagan.Fisheries.Mapping;
using Chabagan.Fisheries.SPMecanism;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Chabagan.Fisheries.Data.Repositories.Setup
{
    public class ProductRepo : IProductRepo
    {
        #region Properties and Variables
        /// <summary>
        /// Database instance in this project
        /// </summary>
        private readonly FisheriesDbContext _dbContext;
        /// <summary>
        /// Intilize mapping profile
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Stored procedure
        /// </summary>
        protected readonly IStoredProcedure _storedProcedure;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that run the first time when calling this class
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public ProductRepo(FisheriesDbContext dbContext, IMapper mapper, IStoredProcedure storedProcedure)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _storedProcedure = storedProcedure;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get product stock
        /// </summary>
        /// <param name="productId">optional product id</param>
        /// <param name="brandId">optional brand id</param>
        /// <returns></returns>
        public List<ProductStock> GetProductStocks(long? productId, long? brandId)
        {
            List<ProductStock> stocks = new List<ProductStock>();

            _storedProcedure.ProcedureName = ("[dbo].[sp_GetProductNameWithStock]");
            _storedProcedure.AddInputParameter("productId", productId, SqlDbType.BigInt);
            _storedProcedure.AddInputParameter("brandId", brandId, SqlDbType.BigInt);
            DataTable dataTable = _storedProcedure.ExecuteQueryToDataTable();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                stocks.Add(new ProductStock(dataRow));
            }
            return stocks.OrderBy(x => x.Stock).ToList();
        }

        /// <summary>
        /// Get all products data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwProduct>> GetAllProductsAsync()
        {
            return _mapper.Map<IEnumerable<VwProduct>>(await _dbContext.Products.Where(x => !x.IsDeleted).Include(x => x.Category).AsNoTracking().OrderByDescending(x => x.Id).ToListAsync());
        }

        /// <summary>
        /// Get product auto complete data
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AutoCompleteModel>> GetProductAutocompleteAsync()
        {
            return await _dbContext.Products.Where(x => !x.IsDeleted)
                .AsNoTracking()
                .Select(x => new AutoCompleteModel { Label = x.Name, Value=x.Id.ToString()})
                .OrderBy(x => x.Label)
                .ToListAsync();
        }

        /// <summary>
        /// Get product dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DropdownModel>> GetProductDropdownAsync()
        {
            return _mapper.Map<IEnumerable<DropdownModel>>(await _dbContext.Products.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get a single product data from database by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<VwProduct> GetProductByProductIdAsync(long productId)
        {
            return _mapper.Map<VwProduct>(await _dbContext.Products.Where(x => x.Id == productId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save Product information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwProduct> SaveProductAsync(VwProduct model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            //bool isExist = await _dbContext.Products.AnyAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower());

            //if (isExist)
            //    throw new DuplicateNameException(ResponseMessage.ExistingData);

            DbProduct dbProduct = _mapper.Map<DbProduct>(model);
            await _dbContext.Products.AddAsync(dbProduct);
            await _dbContext.SaveChangesAsync();
            return await GetProductByProductIdAsync(dbProduct.Id);
        }


        /// <summary>
        /// Update Product information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwProduct> UpdateProductAsync(VwProduct model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            //bool isExist = await _dbContext.Products.AnyAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower() && x.Id != model.Id);

            //if (isExist)
            //    throw new DuplicateNameException(ResponseMessage.ExistingData);

            DbProduct? dbProduct = await _dbContext.Products.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbProduct is null)
                throw new Exception(ResponseMessage.FailRetrieve);
            dbProduct = _mapper.Map<DbProduct>(model);
            _dbContext.Products.Update(dbProduct);
            await _dbContext.SaveChangesAsync();
            return await GetProductByProductIdAsync(dbProduct.Id);
        }


        /// <summary>
        /// Delete a Product data by User id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwProduct> DeleteProductByProductIdAsync(long productId)
        {
            if (productId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbProduct? dbProduct = await _dbContext.Products.Where(x => x.Id == productId).AsNoTracking().SingleOrDefaultAsync();

            if (dbProduct is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbProduct.IsDeleted = true;
            _dbContext.Products.Update(dbProduct);
            await _dbContext.SaveChangesAsync();
            return await GetProductByProductIdAsync(dbProduct.Id);
        }

        #endregion
    }
}
