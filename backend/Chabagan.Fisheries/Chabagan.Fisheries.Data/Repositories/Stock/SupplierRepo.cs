using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Stock.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Stock;
using Chabagan.Fisheries.Entities.Models.Stock;
using Chabagan.Fisheries.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Chabagan.Fisheries.Data.Repositories.Stock
{
    public class SupplierRepo: ISupplierRepo
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
        public SupplierRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all supplier data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwSupplier>> GetAllSupplierAsync()
        {
            return _mapper.Map<IEnumerable<VwSupplier>>(await _dbContext.Suppliers.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync());
        }


        /// <summary>
        /// Get all supplier dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DropdownModel>> GetSupplierDropdownAsync()
        {
            return _mapper.Map<IEnumerable<DropdownModel>>(await _dbContext.Suppliers.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get a single Supplier data from database by Supplier id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public async Task<VwSupplier> GetSupplierBySupplierIdAsync(long supplierId)
        {
            return _mapper.Map<VwSupplier>(await _dbContext.Suppliers.Where(x => x.Id == supplierId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save Supplier information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwSupplier> SaveSupplierAsync(VwSupplier model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbSupplier dbSupplier = _mapper.Map<DbSupplier>(model);
            await _dbContext.Suppliers.AddAsync(dbSupplier);
            await _dbContext.SaveChangesAsync();
            return await GetSupplierBySupplierIdAsync(dbSupplier.Id);
        }


        /// <summary>
        /// Update Supplier information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwSupplier> UpdateSupplierAsync(VwSupplier model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbSupplier? dbSupplier = await _dbContext.Suppliers.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbSupplier is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbSupplier = _mapper.Map<DbSupplier>(model);
            _dbContext.Suppliers.Update(dbSupplier);
            await _dbContext.SaveChangesAsync();
            return await GetSupplierBySupplierIdAsync(dbSupplier.Id);
        }


        /// <summary>
        /// Delete a Supplier data by User id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwSupplier> DeleteSupplierBySupplierIdAsync(long supplierId)
        {
            if (supplierId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbSupplier? dbSupplier = await _dbContext.Suppliers.Where(x => x.Id == supplierId).AsNoTracking().SingleOrDefaultAsync();

            if (dbSupplier is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbSupplier.IsDeleted = true;
            _dbContext.Suppliers.Update(dbSupplier);
            await _dbContext.SaveChangesAsync();
            return await GetSupplierBySupplierIdAsync(dbSupplier.Id);
        }

        #endregion
    }
}
