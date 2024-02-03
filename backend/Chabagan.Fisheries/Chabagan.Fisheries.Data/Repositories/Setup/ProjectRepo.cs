using AutoMapper;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Data.Repositories.Setup.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.Setup;
using Chabagan.Fisheries.Entities.Models.Setup;
using Chabagan.Fisheries.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Chabagan.Fisheries.Data.Repositories.Setup
{
    public class ProjectRepo: IProjectRepo
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
        public ProjectRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Get all projects data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwProject>> GetAllProjectsAsync()
        {
            return _mapper.Map<IEnumerable<VwProject>>(await _dbContext.Projects.Where(x => !x.IsDeleted).AsNoTracking().OrderByDescending(x => x.Id).ToListAsync());
        }

        /// <summary>
        /// Get project dropdowns
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DropdownModel>> GetProjectsDropdownAsync()
        {
            return _mapper.Map<IEnumerable<DropdownModel>>(await _dbContext.Projects.Where(x => !x.IsDeleted).AsNoTracking().OrderByDescending(x => x.Id).ToListAsync());
        }

        /// <summary>
        /// Get a single Project data from database by Project id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<VwProject> GetProjectByProjectIdAsync(long projectId)
        {
            return _mapper.Map<VwProject>(await _dbContext.Projects.Where(x => x.Id == projectId)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }

        /// <summary>
        /// Save project information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwProject> SaveProjectAsync(VwProject model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbProject dbProject = _mapper.Map<DbProject>(model);
            await _dbContext.Projects.AddAsync(dbProject);
            await _dbContext.SaveChangesAsync();
            return await GetProjectByProjectIdAsync(dbProject.Id);
        }


        /// <summary>
        /// Update Project information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwProject> UpdateProjectAsync(VwProject model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbProject? dbProject = await _dbContext.Projects.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbProject is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbProject = _mapper.Map<DbProject>(model);
            _dbContext.Projects.Update(dbProject);
            await _dbContext.SaveChangesAsync();
            return await GetProjectByProjectIdAsync(dbProject.Id);
        }


        /// <summary>
        /// Delete a Project data by User id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwProject> DeleteProjectByProjectIdAsync(long projectId)
        {
            if (projectId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbProject? dbProject = await _dbContext.Projects.Where(x => x.Id == projectId).AsNoTracking().SingleOrDefaultAsync();

            if (dbProject is null)
                throw new Exception(ResponseMessage.FailRetrieve);

            dbProject.IsDeleted = true;
            _dbContext.Projects.Update(dbProject);
            await _dbContext.SaveChangesAsync();
            return await GetProjectByProjectIdAsync(dbProject.Id);
        }

        #endregion

    }
}
