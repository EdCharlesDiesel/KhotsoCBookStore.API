using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace KhotsoCBookStore.API.Controllers
{
    public class AuthenticateController : BaseController
    {
        
         #region Property  
        /// <summary>  
        /// Property Declaration  
        /// </summary>  
        /// <returns></returns>  
        readonly IUserService _userService;
        readonly IConfiguration _config;  
        #endregion  
        
        #region Contructor Injector 
        public AuthenticateController(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
            // _userService = userService ?? throw new ArgumentNullException(nameof(_userService));
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

  
         
        // /// <summary>  
        // /// Constructor Injection to access all methods or simply DI(Dependency Injection)  
        // /// </summary>  
        // public AuthenticateController(IConfiguration config)  
        // {  
        //     _config = config;  
        // }  
       
  
        #region GenerateJWT  
        /// <summary>  
        /// Generate Json Web Token Method  
        /// </summary>  
        /// <param name="userInfo"></param>  
        /// <returns></returns>  
        private string GenerateJSONWebToken(LoginModel userInfo)  
        {  
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);  
  
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],  
              _config["Jwt:Issuer"],  
              null,  
              expires: DateTime.Now.AddMinutes(120),  
              signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }  
        #endregion  
  
        #region AuthenticateUser  
        /// <summary>  
        /// Hardcoded the User authentication  
        /// </summary>  
        /// <param name="login"></param>  
        /// <returns></returns>  
        private async Task<LoginModel> AuthenticateUser(LoginModel login)  
        {  
            LoginModel user = null;  
  
            //Validate the User Credentials      
            //Demo Purpose, I have Passed HardCoded User Information      
            if (login.UserName == "Jay")  
            {  
                user =  new LoginModel { UserName = "Jay", Password = "123456" };  
            }  
            return user;  
        }  
        #endregion  
  
        #region Login Validation  
        /// <summary>  
        /// Login Authenticaton using JWT Token Authentication  
        /// </summary>  
        /// <param name="data"></param>  
        /// <returns></returns>  
        [AllowAnonymous]  
        [HttpPost(nameof(Login))]  
        public async Task<IActionResult> Login([FromBody] LoginModel data)  
        {  
            IActionResult response = Unauthorized();  
            var user = await AuthenticateUser(data);  
            if (data != null)  
            {  
                var tokenString = GenerateJSONWebToken(user);  
                response = Ok(new { Token = tokenString , Message = "Success" });  
            }  
            return response;  
        }  
        #endregion  
  
        #region Get  
        /// <summary>  
        /// Authorize the Method  
        /// </summary>  
        /// <returns></returns>  
        [HttpGet(nameof(Get))]  
        public async Task<IEnumerable<string>> Get()  
        {  
            var accessToken = await HttpContext.GetTokenAsync("access_token");  
  
            return new string[] { accessToken };  
        }  
  
  
        #endregion  
  
    }  
  
    #region JsonProperties  
    /// <summary>  
    /// Json Properties  
    /// </summary>  
    public class LoginModel  
    {  
        [Required]  
        public string UserName { get; set; }  
        [Required]  
        public string Password { get; set; }  
    }  

    public class User
     {
         [Required]
         public string Username { get; set; }
         [Required]
         public string Password { get; set; }
         [Required]
         public string Email { get; set; }
         [Required]
         public string Role { get; set; }
         public DateTime Date { get; set; } = DateTime.Now;
     }
    #endregion  
}

        // /// <summary>
        // /// Login.
        // /// </summary>
        // /// <param name="userMaster"></param>
        // /// <returns></returns>
        // [HttpGet()]
        // public async Task<IActionResult> Login([FromBody] UserMaster userMaster)
        // {
        //     var user = await _userService.Authenticate(userMaster.Username, userMaster.Password);
        //     if (user == null)
        //     {
        //         return BadRequest(new { message = "Username or password is incorrect" });
        //     }

        //     var tokenString = GenerateJSONWebToken(user);
        //     return Ok(new
        //     {
        //         token = tokenString,
        //         userDetails = user,
        //     });
        // }


        // /// <summary>
        // /// Logout
        // /// </summary>
        // /// <returns></returns>
        // [HttpPost()]        
        // public  Task<ActionResult> Logout()
        // {
        //     throw new NotImplementedException();
        // }
        
        // private string GenerateJSONWebToken(UserMaster userMaster)
        // {
        //     var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        //     var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //     var claims = new[]
        //     {
        //         //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
        //         //new Claim("userid", userInfo.UserId.ToString(CultureInfo.InvariantCulture)),
        //         //new Claim("userTypeId", userInfo.UserTypeId.ToString(CultureInfo.InvariantCulture)),
        //         //new Claim(ClaimTypes.Role,userInfo.UserTypeId.ToString(CultureInfo.InvariantCulture)),
        //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //     };

        //     var token = new JwtSecurityToken(
        //         issuer: _config["Jwt:Issuer"],
        //         audience: _config["Jwt:Audience"],
        //         claims: claims,
        //         expires: DateTime.Now.AddMinutes(60),
        //         signingCredentials: credentials
        //     );

        //     return new JwtSecurityTokenHandler().WriteToken(token);
        // }
//     }
// }
