using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Security.Claims;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Dtos;
using AutoMapper;
using KhotsoCBookStore.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace KhotsoCBookStore.API.Controllers
{
    public class AccountController :Controller
    {

        #region Property  
        /// <summary>  
        /// Property Declaration  
        /// </summary>  
        /// <returns></returns>  
        private readonly IConfiguration _config;
        private readonly IAccountService _userRepository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ICartService _cartRepository;
        private readonly IMailService _mailRepository;
        #endregion

        #region Contructor Injector 
        public AccountController(IConfiguration config,
                                      IAccountService userService,
                                      ICartService cartService,
                                      IMapper mapper,
                                      IMailService mailService,
                                      IOptions<AppSettings> appSettings)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
            _userRepository = userService ?? throw new ArgumentNullException(nameof(_userRepository));;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));;
            _mailRepository = mailService ?? throw new ArgumentNullException(nameof(_mailRepository));
            _appSettings = appSettings.Value;
            _cartRepository = cartService ?? throw new ArgumentNullException(nameof(_cartRepository));;
        }
        #endregion 

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions()]
        public IActionResult GetLoginAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="model"></param>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]UserMaster model)
        {
           // var user = _mapper.Map<UserMaster>(model);
            try
            {
                // create user
                await _userRepository.RegisterUser(model, model.Password);
                await _userRepository.SaveChangesAsync();

                 return CreatedAtRoute("GetUser",
                new { username = model.Username },
                model);
                //return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userRepository.Authenticate(model.Username, model.Password);
            if (user == null)
            {
            return BadRequest(new { message = "Username or password is incorrect" });
            }  

            var tokenString = GenerateJSONWebToken(user);
            return Ok(new
            {
                token = tokenString,
                userDetails = user,
            });
        }        

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}",Name ="GetUser")]
        public ActionResult GetUser(Guid userId)
        {
            return Ok( _userRepository.GetUserById(userId));
        }

        /// <summary>
        /// Check username availability. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("validateUserName/{userName}")]
        public ActionResult<bool> ValidateUserName(string userName)
        {
            return _userRepository.CheckUserAvailabity(userName);
        }

        /// <summary>
        /// Update user resource by userId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns no content.</response>
        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdateUser(Guid userId, RegisterDto userToUpdate)
        {
            // if ( _userRepository.GetUserById(userId))
            // {
            //     return NotFound();
            // }

            // var userEntity =  await _userRepository.GetUserByIdAsync(userId);
            // if (userEntity == null)
            // {
            //     return NotFound();
            // }

            // _mapper.Map(userToUpdate, userEntity);

            // await _userRepository.SaveChangesAsync();

            return  NoContent();
        }  

        /// <summary>
        /// Delete a single user resource by userId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            // if (!await _userRepository.GetUserById(userId))
            // {
            //     return NotFound();
            // }

            // var userEntity = await  _userRepository.GetUserByIdAsync(userId);

            // if (userEntity == null)
            // {
            //     return NotFound();
            // }

            // _userRepository.DeleteUser(userEntity);
            // await _userRepository.SaveChangesAsync();

            //  _mailService.Send(
            //      "User deleted.",
            //   $"User named {userEntity.FirstName} with id {userEntity.UserId} was deleted.");

            return NoContent();
        }

        private string GenerateJSONWebToken(UserMaster userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim("userid", userInfo.UserId.ToString(CultureInfo.InvariantCulture.ToString())),
                new Claim("userTypeId", userInfo.UserTypeId.ToString(CultureInfo.InvariantCulture.ToString())),
                new Claim(ClaimTypes.Role,userInfo.UserTypeId.ToString(CultureInfo.InvariantCulture.ToString())),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
