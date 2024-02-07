using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Fisheries.Data.Repositories.Stock
{
    public class SalesRepo: ISalesRepo
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
        public SalesRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Get all Sales data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PurchaaseInfo>> GetAllSalesAsync()
        {
            return _mapper.Map<IEnumerable<PurchaaseInfo>>(await _dbContext.Sales.Where(x => !x.IsDeleted)
                .Include(x => x.Supplier)
                .Include(x => x.Project)
                .AsNoTracking()
                .ToListAsync());
        }

        /// <summary>
        /// Get a single Sales data from database by brand id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public async Task<DbSales?> GetSalesBySalesIdAsync(long purchaseId)
        {
            return await _dbContext.Sales.Where(x => x.Id == purchaseId)
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
        public async Task<DbSales?> SaveSalesAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbSales dbSales = _mapper.Map<DbSales>(model);
            await _dbContext.Sales.AddAsync(dbSales);
            await _dbContext.SaveChangesAsync();
            return await GetSalesBySalesIdAsync(dbSales.Id);
        }


        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbSales?> UpdateSalesAsync(ProcessPurchase model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbSales? dbPurchase = await _dbContext.Sales.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchase is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            var items = await _dbContext.SalesItems.Where(x => x.PurchaseId == model.Id).AsNoTracking().ToListAsync();
            if (items.Any())
            {
                _dbContext.SalesItems.RemoveRange(items);
                await _dbContext.SaveChangesAsync();
            }

            dbPurchase = _mapper.Map<DbSales>(model);
            _dbContext.Sales.Update(dbPurchase);
            await _dbContext.SaveChangesAsync();
            return await GetSalesBySalesIdAsync(dbPurchase.Id);
        }


        /// <summary>
        /// Delete a Purchase data by User id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbSales?> DeleteSalesBySalesIdAsync(long purchaseId)
        {
            if (purchaseId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbSales? dbPurchase = await _dbContext.Sales.Where(x => x.Id == purchaseId).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchase is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPurchase.IsDeleted = true;
            _dbContext.Sales.Update(dbPurchase);
            await _dbContext.SaveChangesAsync();
            return await GetSalesBySalesIdAsync(dbPurchase.Id);
        }

        #endregion

    }
}
