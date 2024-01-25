using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Models.Setup;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Chabagan.Fisheries.Data.Repositories.Setup
{
    public class StockCategoryRepo : IStockCategoryRepo
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
        public StockCategoryRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all category data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwStockCategory>> GetAllStockCategoriesAsync()
        {
            return _mapper.Map<IEnumerable<VwStockCategory>>(await _dbContext.StockCategories.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get a single stock category data from database by category id
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public async Task<VwStockCategory> GetStockCategoryByIdAsync(long catId)
        {
            return _mapper.Map<VwStockCategory>(await _dbContext.StockCategories.Where(x => x.Id == catId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save category information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwStockCategory> SaveStockCategoryAsync(VwStockCategory model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            bool isExist = await _dbContext.StockCategories.AnyAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower());

            if (isExist)
                throw new DuplicateNameException(ResponseMessage.ExistingData);

            DbStockCategory dbCategory = _mapper.Map<DbStockCategory>(model);
            await _dbContext.StockCategories.AddAsync(dbCategory);
            await _dbContext.SaveChangesAsync();
            return await GetStockCategoryByIdAsync(dbCategory.Id);
        }


        /// <summary>
        /// Update category information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwStockCategory> UpdateStockCategoryAsync(VwStockCategory model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            bool isExist = await _dbContext.StockCategories.AnyAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower() && x.Id != model.Id);

            if (isExist)
                throw new DuplicateNameException(ResponseMessage.ExistingData);

            DbStockCategory? dbCategory = await _dbContext.StockCategories.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbCategory is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbCategory = _mapper.Map<DbStockCategory>(model);
            _dbContext.StockCategories.Update(dbCategory);
            await _dbContext.SaveChangesAsync();
            return await GetStockCategoryByIdAsync(dbCategory.Id);
        }


        /// <summary>
        /// Delete a category data by User id
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwStockCategory> DeleteStockCategoryByIdAsync(long catId)
        {
            if (catId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbStockCategory? dbCategory = await _dbContext.StockCategories.Where(x => x.Id == catId).AsNoTracking().SingleOrDefaultAsync();

            if (dbCategory is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbCategory.IsDeleted = true;
            _dbContext.StockCategories.Update(dbCategory);
            await _dbContext.SaveChangesAsync();
            return await GetStockCategoryByIdAsync(dbCategory.Id);
        }

        #endregion
    }
}
