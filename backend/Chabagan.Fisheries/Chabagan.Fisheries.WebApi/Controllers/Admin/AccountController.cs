using Chabagan.Chabagan.Fisheries.Repositories.Administration.Interfaces;
using Chabagan.Fisheries.Common.APIResponse.Generic;
using Chabagan.Fisheries.Common.APIResponse;
using Chabagan.Fisheries.Common.Constants;
using Chabagan.Fisheries.Entities.Mapping.User;
using Chabagan.Fisheries.Mapping.User;
using Chabagan.Fisheries.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chabagan.Fisheries.WebApi.Utilities.Interfaces;

namespace Chabagan.Fisheries.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Private Properties and Variables
        /// <summary>
        /// Logger for log Error 
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// Interface for access data
        /// </summary>
        private readonly IUserRepo _userRepo;
        /// <summary>
        /// Helper service for access helper methods
        /// </summary>
        private readonly IHelperService _helperService;
        /// <summary>
        /// Configuration Settings
        /// </summary>
        public readonly IConfigSettings _configuration;
        #endregion


        #region Constructors

        /// <summary>
        /// Call instantly
        /// </summary>
        /// <param name="logger">Inject Logger</param>
        /// <param name="UserRepo">Inject User</param>
        /// <param name="helperService">Inject helpers</param>
        /// <param name="configSettings">Inject Configuration</param>
        public AccountController(
            ILogger<AccountController> logger, 
            IUserRepo UserRepo, 
            IHelperService helperService,
            IConfigSettings configSettings)
        {
            _userRepo = UserRepo;
            _logger = logger;
            _helperService = helperService;
            _configuration = configSettings;

        }
        #endregion

        #region Public Methods and Endpoints
        [Route("SignIn")]
        [HttpPost]
        [ProducesResponseType(typeof(APIOperationResultGeneric<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<APIOperationResultGeneric<string>>> GetAuthorizedUser([FromBody] VwLogin model)
        {
            try
            {
                VwUserResponse? user = await _userRepo.GetAutheticateUser(model);

                if (user is null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, APIOperationResult.Failure(ResponseMessage.LoginInvalidPassword));
                }
                return Ok(BusinessOperationResult.Success(GenerateJwtToken(user)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, APIOperationResult.Failure(ex.Message));
            }
        }
        #endregion


        #region Private methods
        private string GenerateJwtToken(VwUserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetJWTKey());
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user?.Role?.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.UserData, (user.Avatar is not null)?user.Avatar:"File_Storage/Uploads/Users/img6.jpg"),
                    }),

                Expires = DateTime.UtcNow.AddDays(30),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenDetails = tokenHandler.CreateToken(tokenDescription);

            var jwtToken = tokenHandler.WriteToken(tokenDetails);

            return jwtToken;
        }
        #endregion
    }
}
