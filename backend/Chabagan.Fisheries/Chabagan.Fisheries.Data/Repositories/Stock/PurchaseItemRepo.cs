using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Fisheries.Data.Repositories.Stock
{
    public class PurchaseItemRepo : IPurchaseItemRepo
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
        public PurchaseItemRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Get all purchase items data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProcessPurchaseItem>> GetAllPurchaseItemsByPurchaseIdAsync(long purchaseId)
        {
            return _mapper.Map<IEnumerable<ProcessPurchaseItem>>(await _dbContext.PurchaseItems.Where(x => x.PurchaseId == purchaseId).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get a single purchase item data from database by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<ProcessPurchaseItem> GetPurchaseItemByItemIdAsync(long itemId)
        {
            return _mapper.Map<ProcessPurchaseItem>(await _dbContext.PurchaseItems.Where(x => x.Id == itemId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save Purchase item information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ProcessPurchaseItem> SavePurchaseItemAsync(ProcessPurchaseItem model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPurchaseItem dbPurchaseItem = _mapper.Map<DbPurchaseItem>(model);
            await _dbContext.PurchaseItems.AddAsync(dbPurchaseItem);
            await _dbContext.SaveChangesAsync();
            return await GetPurchaseItemByItemIdAsync(dbPurchaseItem.Id);
        }


        /// <summary>
        /// Update Purchase Item information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ProcessPurchaseItem> UpdatePurchaseItemAsync(ProcessPurchaseItem model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPurchaseItem? dbPurchaseItem = await _dbContext.PurchaseItems.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchaseItem is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPurchaseItem = _mapper.Map<DbPurchaseItem>(model);
            _dbContext.PurchaseItems.Update(dbPurchaseItem);
            await _dbContext.SaveChangesAsync();
            return await GetPurchaseItemByItemIdAsync(dbPurchaseItem.Id);
        }


        /// <summary>
        /// Delete a Purchase Item data by item id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ProcessPurchase> DeletePurchaseItemByItemIdAsync(long purchaseId)
        {
            if (purchaseId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbPurchaseItem? dbPurchaseItem = await _dbContext.PurchaseItems.Where(x => x.Id == purchaseId).AsNoTracking().SingleOrDefaultAsync();

            if (dbPurchaseItem is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            _dbContext.PurchaseItems.Remove(dbPurchaseItem);
            await _dbContext.SaveChangesAsync();
            return new ProcessPurchase();
        }

        #endregion
    }
}
