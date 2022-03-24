// using System;
// using System.Globalization;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Authentication;
// using KhotsoCBookStore.API.Dtos;
// using KhotsoCBookStore.API.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;

// namespace KhotsoCBookStore.API.Controllers
// {
//     [Produces("application/json")]
//     [Route("api/[controller]")]
//     public class LoginController : Controller
//     {
//         readonly IUserService _userService;
//         readonly IConfiguration _config;

//         public LoginController(IConfiguration config, IUserService userService)
//         {
//             _config = config ?? throw new ArgumentNullException(nameof(_config));
//             _userService = userService ?? throw new ArgumentNullException(nameof(_userService));
//         }

//         /// <summary>
//         /// Login.
//         /// </summary>
//         /// <param name="userMaster"></param>
//         /// <returns></returns>
//         [HttpPost]
//         [AllowAnonymous]
//         public async Task<IActionResult> Login([FromBody] UserMaster userMaster)
//         {
//             var user = await _userService.Authenticate(userMaster.Username, userMaster.Password);
//             if (user == null)
//             {
//                 return BadRequest(new { message = "Username or password is incorrect" });
//             }

//             var tokenString = GenerateJSONWebToken(user);
//             return Ok(new
//             {
//                 token = tokenString,
//                 userDetails = user,
//             });
//         }

//         private string GenerateJSONWebToken(UserMaster userMaster)
//         {
//             var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
//             var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//             var claims = new[]
//             {
//                 //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
//                 //new Claim("userid", userInfo.UserId.ToString(CultureInfo.InvariantCulture)),
//                 //new Claim("userTypeId", userInfo.UserTypeId.ToString(CultureInfo.InvariantCulture)),
//                 //new Claim(ClaimTypes.Role,userInfo.UserTypeId.ToString(CultureInfo.InvariantCulture)),
//                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//             };

//             var token = new JwtSecurityToken(
//                 issuer: _config["Jwt:Issuer"],
//                 audience: _config["Jwt:Audience"],
//                 claims: claims,
//                 expires: DateTime.Now.AddMinutes(60),
//                 signingCredentials: credentials
//             );

//             return new JwtSecurityTokenHandler().WriteToken(token);
//         }

//         /// <summary>
//         /// Logout
//         /// </summary>
//         /// <returns></returns>
//         [HttpPost]
//         [AllowAnonymous]
//         public async Task<IActionResult> Logout()
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
