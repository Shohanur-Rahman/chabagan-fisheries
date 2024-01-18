using AutoMapper;
using Chabagan.Chabagan.Fisheries.Models.User;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Common.Encription;
using Chabagan.Chabagan.Fisheries.DB;
using Chabagan.Chabagan.Fisheries.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.Entities.Mapping.User;
using Chabagan.Fisheries.Mapping.User;
using Microsoft.EntityFrameworkCore;

namespace Chabagan.Chabagan.Fisheries.Repositories.Administration
{
    public class UserRepo: IUserRepo
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
        public UserRepo(FisheriesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Get all User data from database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<VwUserResponse>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<VwUserResponse>>(await _dbContext.Users.Include(x=> x.Role).AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get a single User data from database by User id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<VwUserResponse> GetUserByUserIdAsync(long UserId)
        {
            return _mapper.Map<VwUserResponse>(await _dbContext.Users.Where(x => x.Id == UserId).Include(x => x.Role)
                .AsNoTracking()
                .SingleOrDefaultAsync());
        }


        /// <summary>
        /// Save User information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwUserResponse> SaveUserAsync(VwUser model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbUser dbUser = _mapper.Map<DbUser>(model);
            await _dbContext.Users.AddAsync(dbUser);
            await _dbContext.SaveChangesAsync();
            return await GetUserByUserIdAsync(dbUser.Id);
        }


        /// <summary>
        /// Update User information in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwUserResponse> UpdateUserAsync(VwUser model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            DbUser? dbUser = await _dbContext.Users.Where(x => x.Id == model.Id).AsNoTracking().SingleOrDefaultAsync();

            if (dbUser is null)
                throw new ArgumentNullException(ResponseMessage.FailRetrieve);

            dbUser = _mapper.Map<DbUser>(model);
            dbUser.PasswordSalt = EncryptPassword.GetSalt();
            dbUser.Password = EncryptPassword.GetHas(model.Password, dbUser.PasswordSalt);
            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync();
            return await GetUserByUserIdAsync(dbUser.Id);
        }


        /// <summary>
        /// Delete a User data by User id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<VwUserResponse> DeleteUserByUserIdAsync(long userId)
        {
            if (userId == 0)
                throw new ArgumentNullException(ResponseMessage.BadRequest);

            DbUser? dbUser = await _dbContext.Users.Where(x => x.Id == userId).AsNoTracking().SingleOrDefaultAsync();

            if (dbUser is null)
                throw new ArgumentNullException(ResponseMessage.FailRetrieve);
            dbUser.IsDeleted = true;
            _dbContext.Users.Update(dbUser);
            await _dbContext.SaveChangesAsync();
            return await GetUserByUserIdAsync(dbUser.Id);
        }


        /// <summary>
        /// Get authenticate user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<VwUserResponse> GetAutheticateUser(VwLogin model)
        {
            var dbUser = await _dbContext.Users.Where(x => x.Email.ToLower() == model.Email.ToLower() && !x.IsDeleted)
                .Include(x => x.Role)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (dbUser is null)
                throw new Exception(ResponseMessage.LoginInvalidPassword);

            if (dbUser.IsLock)
                throw new Exception(ResponseMessage.AccountLocked);

            if (!EncryptPassword.IsValid(model.Password, dbUser.PasswordSalt, dbUser.Password))
                throw new Exception(ResponseMessage.LoginInvalidPassword);

            return _mapper.Map<VwUserResponse>(dbUser);
        }

        

        #endregion
    }
}
