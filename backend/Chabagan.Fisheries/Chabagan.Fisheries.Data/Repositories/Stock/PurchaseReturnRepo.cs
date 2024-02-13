using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Common.Enums;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Fisheries.Data.Repositories.Stock
{
    public class PurchaseReturnRepo : IPurchaseReturnRepo
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
        public PurchaseReturnRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all purchase returns data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaaseInfo>> GetAllPurchaseReturnsAsync()
        {
            return _mapper.Map<IEnumerable<PurchaaseInfo>>(await _dbContext.PurchaseReturns.Where(x => !x.IsDeleted)
                .Include(x => x.Supplier)
                .Include(x => x.Project)
                .AsNoTracking()
                 .OrderByDescending(x => x.Id)
                .ToListAsync());
        }

        /// <summary>
        /// Get a single purchase returns data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public async Task<DbPurchaseReturn?> GetPurchaseReturnByPurchaseIdAsync(long purchaseId)
        {
            return await _dbContext.PurchaseReturns.Where(x => x.Id == purchaseId)
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
        /// Save purchase returns information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPurchaseReturn?> SavePurchaseReturnAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPurchaseReturn dbPurchaseReturn = _mapper.Map<DbPurchaseReturn>(model);
            await _dbContext.PurchaseReturns.AddAsync(dbPurchaseReturn);
            await _dbContext.SaveChangesAsync();

            /***********
         * ***********
         * Save transection
         * *********
         *******/
            DbAccountTransection transection = new DbAccountTransection()
            {
                BillDate = dbPurchaseReturn.BillDate,
                BillId = dbPurchaseReturn.Id,
                SupplierId = dbPurchaseReturn.SupplierId,
                ProjectId = dbPurchaseReturn.ProjectId,
                TransTypeId = (int)TransectionTypeEnum.PurchaseReturn,
                PurchaseReturnTotalAmount = dbPurchaseReturn.TotalAmount,
                PurchaseReturnDiscount = dbPurchaseReturn.Discount,
                PurchaseReturnNetAmount = dbPurchaseReturn.NetAmount,
                PurchaseReturnPaidAmount = dbPurchaseReturn.PaidAmount,
                PurchaseReturnDuesAmount = dbPurchaseReturn.DuesAmount
            };
            await _dbContext.AccountTransections.AddAsync(transection);
            await _dbContext.SaveChangesAsync();

            return await GetPurchaseReturnByPurchaseIdAsync(dbPurchaseReturn.Id);

        }


        /// <summary>
        /// Update purchase returns information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPurchaseReturn?> UpdatePurchaseReturnAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPurchase? dbPurchaseReturn = await _dbContext.Purchases.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchaseReturn is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            var items = await _dbContext.PurchaseReturnItems.Where(x => x.PurchaseId == model.Id).AsNoTracking().ToListAsync();
            if (items.Any())
            {
                _dbContext.PurchaseReturnItems.RemoveRange(items);
                await _dbContext.SaveChangesAsync();
            }

            dbPurchaseReturn = _mapper.Map<DbPurchase>(model);
            _dbContext.Purchases.Update(dbPurchaseReturn);
            await _dbContext.SaveChangesAsync();


            /***********
            * ***********
            * Update transection
            * *********
            *******/

            DbAccountTransection? transection = await _dbContext.AccountTransections.Where(x => x.BillId == dbPurchaseReturn.Id &&
                x.TransTypeId == (int)TransectionTypeEnum.PurchaseReturn).AsNoTracking().SingleOrDefaultAsync();

            if (transection is not null)
            {
                transection.BillDate = dbPurchaseReturn.BillDate;
                transection.SupplierId = dbPurchaseReturn.SupplierId;
                transection.ProjectId = dbPurchaseReturn.ProjectId;
                transection.PurchaseReturnTotalAmount = dbPurchaseReturn.TotalAmount;
                transection.PurchaseReturnDiscount = dbPurchaseReturn.Discount;
                transection.PurchaseReturnNetAmount = dbPurchaseReturn.NetAmount;
                transection.PurchaseReturnPaidAmount = dbPurchaseReturn.PaidAmount;
                transection.PurchaseReturnDuesAmount = dbPurchaseReturn.DuesAmount;

                _dbContext.AccountTransections.Update(transection);
                await _dbContext.SaveChangesAsync();
            }
            return await GetPurchaseReturnByPurchaseIdAsync(dbPurchaseReturn.Id);
        }


        /// <summary>
        /// Delete a purchase returns data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPurchaseReturn?> DeletePurchaseReturnByPurchaseIdAsync(long purchaseId)
        {
            if (purchaseId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbPurchase? dbPurchaseReturn = await _dbContext.Purchases.Where(x => x.Id == purchaseId).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchaseReturn is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPurchaseReturn.IsDeleted = true;
            _dbContext.Purchases.Update(dbPurchaseReturn);
            await _dbContext.SaveChangesAsync();

            /***********
           * ***********
           * Delete transection
           * *********
           *******/

            DbAccountTransection? transection = await _dbContext.AccountTransections.Where(x => x.BillId == dbPurchaseReturn.Id &&
                x.TransTypeId == (int)TransectionTypeEnum.PurchaseReturn).AsNoTracking().SingleOrDefaultAsync();
            if (transection is not null)
            {
                transection.IsDeleted = true;

                _dbContext.AccountTransections.Update(transection);
                await _dbContext.SaveChangesAsync();
            }

            return await GetPurchaseReturnByPurchaseIdAsync(dbPurchaseReturn.Id);
        }

        #endregion
    }
}
