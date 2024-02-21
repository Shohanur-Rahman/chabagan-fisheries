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
    public class PaymentCollectionRepo: IPaymentCollectionRepo
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
        public PaymentCollectionRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all payment data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PaymentCollectionGrid>> GetAllPaymentCollectionsAsync(int typeId)
        {
            return await _dbContext.PaymentCollections.Where(x => !x.IsDeleted && x.PaymentCollectionType == typeId)
                .Include(x => x.Supplier)
                .AsNoTracking().Select(x => new PaymentCollectionGrid
                {
                    Id = x.Id,
                    SupplierName = x.Supplier.Name,
                    SupplierId = x.SupplierId,
                    PaidAmount = x.PaidAmount,
                    Note = x.Note,
                    BillDate = x.BillDate.Value.ToString("dd MMM yyyy")
                }).OrderByDescending(x => x.Id).ToListAsync();
        }

        /// <summary>
        /// Get a single payment data from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DbPaymentCollection?> GetPaymentCollectionByIdAsync(long id)
        {
            return await _dbContext.PaymentCollections.Where(x => x.Id == id)
                .Include(x => x.Supplier)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// Save payment information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPaymentCollection?> SavePaymentCollectionAsync(ProcessPaymentCollection model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPaymentCollection dbPaymentCollection = _mapper.Map<DbPaymentCollection>(model);
            await _dbContext.PaymentCollections.AddAsync(dbPaymentCollection);
            await _dbContext.SaveChangesAsync();

            /***********
             * ***********
             * Save transection
             * *********
             *******/
            DbAccountTransection transection = new DbAccountTransection()
            {
                BillDate = dbPaymentCollection.BillDate,
                BillId = dbPaymentCollection.Id,
                SupplierId = dbPaymentCollection.SupplierId,
                TransTypeId = dbPaymentCollection.PaymentCollectionType,
                PurchasePaidAmount = (dbPaymentCollection.PaymentCollectionType == (int)TransectionTypeEnum.Payment ? dbPaymentCollection.PaidAmount : 0),
                SalesPaidAmount = (dbPaymentCollection.PaymentCollectionType == (int)TransectionTypeEnum.Collection ? dbPaymentCollection.PaidAmount : 0),
            };
            await _dbContext.AccountTransections.AddAsync(transection);
            await _dbContext.SaveChangesAsync();

            return await GetPaymentCollectionByIdAsync(dbPaymentCollection.Id);
        }


        /// <summary>
        /// Update Purchase information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPaymentCollection?> UpdatePaymentCollectionAsync(ProcessPaymentCollection model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPaymentCollection? dbPaymentCollection = await _dbContext.PaymentCollections.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPaymentCollection is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPaymentCollection = _mapper.Map<DbPaymentCollection>(model);
            _dbContext.PaymentCollections.Update(dbPaymentCollection);
            await _dbContext.SaveChangesAsync();

            /***********
            * ***********
            * Update transection
            * *********
            *******/

            DbAccountTransection? transection = await _dbContext.AccountTransections.Where(x => x.BillId == dbPaymentCollection.Id &&
                x.TransTypeId == dbPaymentCollection.PaymentCollectionType).AsNoTracking().SingleOrDefaultAsync();

            if (transection is not null)
            {
                transection.BillDate = dbPaymentCollection.BillDate;
                transection.SupplierId = dbPaymentCollection.SupplierId;
                transection.TransTypeId = dbPaymentCollection.PaymentCollectionType;
                transection.PurchasePaidAmount = (dbPaymentCollection.PaymentCollectionType == (int)TransectionTypeEnum.Payment ? dbPaymentCollection.PaidAmount : 0);
                transection.SalesPaidAmount = (dbPaymentCollection.PaymentCollectionType == (int)TransectionTypeEnum.Collection ? dbPaymentCollection.PaidAmount : 0);

                _dbContext.AccountTransections.Update(transection);
                await _dbContext.SaveChangesAsync();
            }

            return await GetPaymentCollectionByIdAsync(dbPaymentCollection.Id);
        }


        /// <summary>
        /// Delete a payment data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbPaymentCollection?> DeletePaymentCollectionByIdAsync(long id)
        {
            if (id == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbPaymentCollection? dbPaymentCollection = await _dbContext.PaymentCollections.Where(x => x.Id == id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPaymentCollection is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPaymentCollection.IsDeleted = true;
            _dbContext.PaymentCollections.Update(dbPaymentCollection);
            await _dbContext.SaveChangesAsync();

            /***********
           * ***********
           * Delete transection
           * *********
           *******/

            DbAccountTransection? transection = await _dbContext.AccountTransections.Where(x => x.BillId == dbPaymentCollection.Id &&
                x.TransTypeId == dbPaymentCollection.PaymentCollectionType).AsNoTracking().SingleOrDefaultAsync();
            if (transection is not null)
            {
                transection.IsDeleted = true;

                _dbContext.AccountTransections.Update(transection);
                await _dbContext.SaveChangesAsync();
            }

            return await GetPaymentCollectionByIdAsync(dbPaymentCollection.Id);
        }

        #endregion
    }
}
