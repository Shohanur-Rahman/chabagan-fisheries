using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.Entities.Models.User;
using Chabagan.Fisheries.Mapping.User;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Fisheries.Data.Repositories.Administration
{
    public class RoleRepo : IRoleRepo
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
        public RoleRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all roles data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DbRole>> GetAllRolesAsync()
        {
            return await _dbContext.Roles.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get a single Roles data from database by Roles id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<DbRole?> GetRoleByRoleIdAsync(long roleId)
        {
            return await _dbContext.Roles.Where(x => x.Id == roleId).AsNoTracking().SingleOrDefaultAsync();
        }


        /// <summary>
        /// Save Role information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbRole?> SaveRoleAsync(DbRole model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            var dbRole = _mapper.Map<DbRole>(model);
            await _dbContext.Roles.AddAsync(dbRole);
            await _dbContext.SaveChangesAsync();
            return await GetRoleByRoleIdAsync(dbRole.Id);
        }


        /// <summary>
        /// Update Role information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DbRole?> UpdateRoleAsync(DbRole model)
        {
            if (model is null) 
                throw new ArgumentNullException(nameof(model));

            DbRole? dbRole = await _dbContext.Roles.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbRole is null) 
                throw new ArgumentNullException(ResponseMessage.FailRetrieve);

            dbRole = _mapper.Map<DbRole>(model);
            _dbContext.Roles.Update(dbRole);
            await _dbContext.SaveChangesAsync();
            return await GetRoleByRoleIdAsync(dbRole.Id);
        }


        /// <summary>
        /// Delete a User data by User id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> DeleteRoleByRoleIdAsync(long roleId)
        {
            if (roleId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbRole? dbRole = await _dbContext.Roles.Where(x => x.Id == roleId).AsNoTracking().SingleOrDefaultAsync();

            if (dbRole is null)
                throw new ArgumentNullException(ResponseMessage.FailRetrieve);

            _dbContext.Roles.Remove(dbRole);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
