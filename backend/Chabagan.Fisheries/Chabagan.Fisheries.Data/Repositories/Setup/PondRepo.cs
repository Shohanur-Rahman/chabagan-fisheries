using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Models.Setup;
using Chabagan.Fisheries.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Fisheries.Data.Repositories.Setup
{
    public class PondRepo: IPondRepo
    {
        #region Properties and Variables
        /// <summary>
        /// Database instance in this Pond
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
        public PondRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all Ponds data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwPond>> GetAllPondsAsync()
        {
            return _mapper.Map<IEnumerable<VwPond>>(await _dbContext.Ponds.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get all ponds by project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<VwPond>> GetAllPondsByProjectIdAsync(long projectId)
        {
            return _mapper.Map<IEnumerable<VwPond>>(await _dbContext.Ponds.Where(x => !x.IsDeleted && x.ProjectId == projectId).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get Pond dropdowns
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DropdownModel>> GetPondsDropdownAsync()
        {
            return _mapper.Map<IEnumerable<DropdownModel>>(await _dbContext.Ponds.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get a single Pond data from database by Pond id
        /// </summary>
        /// <param name="pondId"></param>
        /// <returns></returns>
        public async Task<VwPond> GetPondByPondIdAsync(long pondId)
        {
            return _mapper.Map<VwPond>(await _dbContext.Ponds.Where(x => x.Id == pondId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save Pond information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwPond> SavePondAsync(VwPond model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPond dbPond = _mapper.Map<DbPond>(model);
            await _dbContext.Ponds.AddAsync(dbPond);
            await _dbContext.SaveChangesAsync();
            return await GetPondByPondIdAsync(dbPond.Id);
        }


        /// <summary>
        /// Update Pond information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwPond> UpdatePondAsync(VwPond model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbPond? dbPond = await _dbContext.Ponds.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbPond is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPond = _mapper.Map<DbPond>(model);
            _dbContext.Ponds.Update(dbPond);
            await _dbContext.SaveChangesAsync();
            return await GetPondByPondIdAsync(dbPond.Id);
        }


        /// <summary>
        /// Delete a Pond data by User id
        /// </summary>
        /// <param name="PondId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwPond> DeletePondByPondIdAsync(long PondId)
        {
            if (PondId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbPond? dbPond = await _dbContext.Ponds.Where(x => x.Id == PondId).AsNoTracking().SingleOrDefaultAsync();

            if (dbPond is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbPond.IsDeleted = true;
            _dbContext.Ponds.Update(dbPond);
            await _dbContext.SaveChangesAsync();
            return await GetPondByPondIdAsync(dbPond.Id);
        }

        #endregion
    }
}
