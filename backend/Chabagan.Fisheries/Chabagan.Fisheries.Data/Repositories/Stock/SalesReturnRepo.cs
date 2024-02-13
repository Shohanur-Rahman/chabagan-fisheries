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
    public class SalesReturnRepo: ISalesReturnRepo
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
        public SalesReturnRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Get all Sales returns data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaaseInfo>> GetAllSalesReturnsAsync()
        {
            return _mapper.Map<IEnumerable<PurchaaseInfo>>(await _dbContext.SalesReturns.Where(x => !x.IsDeleted)
                .Include(x => x.Supplier)
                .Include(x => x.Project)
                .AsNoTracking()
                 .OrderByDescending(x => x.Id)
                .ToListAsync());
        }

        /// <summary>
        /// Get a single Sales Returns data from database by Sales Returns id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public async Task<DbSalesReturn?> GetSalesReturnsBySalesReturnsIdAsync(long purchaseId)
        {
            return await _dbContext.SalesReturns.Where(x => x.Id == purchaseId)
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
        /// Save Sales Returns information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbSalesReturn?> SaveSalesReturnsAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbSalesReturn dbSalesReturn = _mapper.Map<DbSalesReturn>(model);
            await _dbContext.SalesReturns.AddAsync(dbSalesReturn);
            await _dbContext.SaveChangesAsync();

            /***********
             * ***********
             * Save transection
             * *********
             *******/
            DbAccountTransection transection = new DbAccountTransection()
            {
                BillDate = dbSalesReturn.BillDate,
                BillId = dbSalesReturn.Id,
                SupplierId = dbSalesReturn.SupplierId,
                ProjectId = dbSalesReturn.ProjectId,
                TransTypeId = (int)TransectionTypeEnum.SalesReturn,
                SalesReturnTotalAmount = dbSalesReturn.TotalAmount,
                SalesReturnDiscount = dbSalesReturn.Discount,
                SalesReturnNetAmount = dbSalesReturn.NetAmount,
                SalesReturnPaidAmount = dbSalesReturn.PaidAmount,
                SalesReturnDuesAmount = dbSalesReturn.DuesAmount
            };
            await _dbContext.AccountTransections.AddAsync(transection);
            await _dbContext.SaveChangesAsync();

            return await GetSalesReturnsBySalesReturnsIdAsync(dbSalesReturn.Id);
        }


        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbSalesReturn?> UpdateSalesReturnAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbSalesReturn? dbSalesReturn = await _dbContext.SalesReturns.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbSalesReturn is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            var items = await _dbContext.SalesReturnItems.Where(x => x.PurchaseId == model.Id).AsNoTracking().ToListAsync();
            if (items.Any())
            {
                _dbContext.SalesReturnItems.RemoveRange(items);
                await _dbContext.SaveChangesAsync();
            }

            dbSalesReturn = _mapper.Map<DbSalesReturn>(model);
            _dbContext.SalesReturns.Update(dbSalesReturn);
            await _dbContext.SaveChangesAsync();

            /***********
            * ***********
            * Update transection
            * *********
            *******/

            DbAccountTransection? transection = await _dbContext.AccountTransections.Where(x => x.BillId == dbSalesReturn.Id &&
                x.TransTypeId == (int)TransectionTypeEnum.SalesReturn).AsNoTracking().SingleOrDefaultAsync();

            if (transection is not null)
            {
                transection.BillDate = dbSalesReturn.BillDate;
                transection.SupplierId = dbSalesReturn.SupplierId;
                transection.ProjectId = dbSalesReturn.ProjectId;
                transection.SalesReturnTotalAmount = dbSalesReturn.TotalAmount;
                transection.SalesReturnDiscount = dbSalesReturn.Discount;
                transection.SalesReturnNetAmount = dbSalesReturn.NetAmount;
                transection.SalesReturnPaidAmount = dbSalesReturn.PaidAmount;
                transection.SalesReturnDuesAmount = dbSalesReturn.DuesAmount;

                _dbContext.AccountTransections.Update(transection);
                await _dbContext.SaveChangesAsync();
            }

            return await GetSalesReturnsBySalesReturnsIdAsync(dbSalesReturn.Id);
        }


        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbSalesReturn?> DeleteSalesReturnBySalesReturnIdAsync(long purchaseId)
        {
            if (purchaseId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbSalesReturn? dbSalesReturn = await _dbContext.SalesReturns.Where(x => x.Id == purchaseId).AsNoTracking().SingleOrDefaultAsync();

            if (dbSalesReturn is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbSalesReturn.IsDeleted = true;
            _dbContext.SalesReturns.Update(dbSalesReturn);
            await _dbContext.SaveChangesAsync();

            /***********
           * ***********
           * Delete transection
           * *********
           *******/

            DbAccountTransection? transection = await _dbContext.AccountTransections.Where(x => x.BillId == dbSalesReturn.Id &&
                x.TransTypeId == (int)TransectionTypeEnum.SalesReturn).AsNoTracking().SingleOrDefaultAsync();
            if (transection is not null)
            {
                transection.IsDeleted = true;

                _dbContext.AccountTransections.Update(transection);
                await _dbContext.SaveChangesAsync();
            }

            return await GetSalesReturnsBySalesReturnsIdAsync(dbSalesReturn.Id);
        }

        #endregion


    }
}
