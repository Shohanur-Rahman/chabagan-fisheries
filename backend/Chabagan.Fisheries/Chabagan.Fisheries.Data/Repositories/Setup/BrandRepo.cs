using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Models.Setup;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Chabagan.Fisheries.Data.Repositories.Setup
{
    public class BrandRepo : IBrandRepo
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
        public BrandRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Get all Brands data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwBrand>> GetAllBrandsAsync()
        {
            return _mapper.Map<IEnumerable<VwBrand>>(await _dbContext.Brands.Where(x => !x.IsDeleted).AsNoTracking().OrderByDescending(x => x.Id).ToListAsync());
        }


        /// <summary>
        /// Get brand autocomplete data
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AutoCompleteModel>> GetBrandAutocompleteAsync()
        {
            return await _dbContext.Brands.Where(x => !x.IsDeleted)
                .AsNoTracking()
                .Select(x => new AutoCompleteModel { Label = x.Name, Value = x.Id.ToString() })
                .OrderBy(x => x.Label)
                .ToListAsync();
        }

        /// <summary>
        /// Get a single Brand data from database by brand id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public async Task<VwBrand> GetBrandByBrandIdAsync(long brandId)
        {
            return _mapper.Map<VwBrand>(await _dbContext.Brands.Where(x => x.Id == brandId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save Brand information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwBrand> SaveBrandAsync(VwBrand model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            bool isExist = await _dbContext.Brands.AnyAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower());

            if (isExist)
                throw new DuplicateNameException(ResponseMessage.ExistingData);

            DbBrand dbBrand = _mapper.Map<DbBrand>(model);
            await _dbContext.Brands.AddAsync(dbBrand);
            await _dbContext.SaveChangesAsync();
            return await GetBrandByBrandIdAsync(dbBrand.Id);
        }


        /// <summary>
        /// Update Brand information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwBrand> UpdateBrandAsync(VwBrand model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            bool isExist = await _dbContext.Brands.AnyAsync(x => x.Name.ToLower().Trim() == model.Name.ToLower() && x.Id != model.Id);

            if (isExist)
                throw new DuplicateNameException(ResponseMessage.ExistingData);

            DbBrand? dbBrand = await _dbContext.Brands.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbBrand is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbBrand = _mapper.Map<DbBrand>(model);
            _dbContext.Brands.Update(dbBrand);
            await _dbContext.SaveChangesAsync();
            return await GetBrandByBrandIdAsync(dbBrand.Id);
        }


        /// <summary>
        /// Delete a Brand data by User id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwBrand> DeleteBrandByBrandIdAsync(long brandId)
        {
            if (brandId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbBrand? dbBrand = await _dbContext.Brands.Where(x => x.Id == brandId).AsNoTracking().SingleOrDefaultAsync();

            if (dbBrand is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbBrand.IsDeleted = true;
            _dbContext.Brands.Update(dbBrand);
            await _dbContext.SaveChangesAsync();
            return await GetBrandByBrandIdAsync(dbBrand.Id);
        }

        #endregion
   
    
    }
}
