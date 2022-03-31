using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
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

namespace KhotsoCBookStore.API.Controllers
{
    public class AccountController : BaseController
    {

        #region Property  
        /// <summary>  
        /// Property Declaration  
        /// </summary>  
        /// <returns></returns>  
        readonly IConfiguration _config;
        private IAccountService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        readonly ICartService _cartService;
        #endregion

        #region Contructor Injector 
        public AccountController(IConfiguration config,
                                      IAccountService userService,
                                      ICartService cartService,
                                      IMapper mapper,
                                      IOptions<AppSettings> appSettings)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
            _userService = userService ?? throw new ArgumentNullException(nameof(_userService));;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));;
            _appSettings = appSettings.Value;
            _cartService = cartService ?? throw new ArgumentNullException(nameof(_cartService));;
        }
        #endregion 

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetLoginAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE");
            return Ok();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);
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
        [HttpGet(Name ="GetUser")]
        public ActionResult GetUser(Guid userId)
        {
            return Ok( _userService.GetUserById(userId));
        }

        /// <summary>
        /// Check username availability. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("validateUserName/{userName}")]
        public async Task<bool> ValidateUserName(string userName)
        {
            return await _userService.CheckUserAvailabity(userName);
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
                await _userService.RegisterUser(model, model.Password);
                await _userService.SaveChangesAsync();

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
