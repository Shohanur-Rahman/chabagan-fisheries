﻿using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Fisheries.Data.Repositories.Stock
{
    public class PurchaseRepo: IPurchaseRepo
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
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that run the first time when calling this class
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public PurchaseRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all purchase data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaaseInfo>> GetAllPurchasesAsync()
        {
            return _mapper.Map<IEnumerable<PurchaaseInfo>>(await _dbContext.Purchases.Where(x => !x.IsDeleted)
                .Include(x => x.Supplier)
                .Include(x => x.Project)
                .AsNoTracking()
                .ToListAsync());
        }

        /// <summary>
        /// Get a single Purchase data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public async Task<DbPurchase?> GetPurchaseByPurchaseIdAsync(long purchaseId)
        {
            return await _dbContext.Purchases.Where(x => x.Id == purchaseId)
                .Include(x => x.Supplier)
                .Include(x => x.Project)
                .Include(x => x.Items)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Save Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPurchase?> SavePurchaseAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPurchase dbPurchase = _mapper.Map<DbPurchase>(model);
            await _dbContext.Purchases.AddAsync(dbPurchase);
            await _dbContext.SaveChangesAsync();
            return await GetPurchaseByPurchaseIdAsync(dbPurchase.Id);
        }


        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPurchase?> UpdatePurchaseAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPurchase? dbPurchase = await _dbContext.Purchases.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchase is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPurchase = _mapper.Map<DbPurchase>(model);
            _dbContext.Purchases.Update(dbPurchase);
            await _dbContext.SaveChangesAsync();
            return await GetPurchaseByPurchaseIdAsync(dbPurchase.Id);
        }


        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPurchase?> DeletePurchaseByPurchaseIdAsync(long purchaseId)
        {
            if (purchaseId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbPurchase? dbPurchase = await _dbContext.Purchases.Where(x => x.Id == purchaseId).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchase is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPurchase.IsDeleted = true;
            _dbContext.Purchases.Update(dbPurchase);
            await _dbContext.SaveChangesAsync();
            return await GetPurchaseByPurchaseIdAsync(dbPurchase.Id);
        }

        #endregion


    }
}
