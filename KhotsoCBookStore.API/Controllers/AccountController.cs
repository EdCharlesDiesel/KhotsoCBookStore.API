// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Models.Account;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;

// namespace StarPeaceAdminHub.Controllers
// {
//     [Produces("application/json")]
//     [Route("api/[controller]")]
//     public class AccountController : Controller
//     {
//         private readonly UserManager<IdentityUser<int>> _userManager;
//         private readonly SignInManager<IdentityUser<int>> _signInManager;

        
//         public AccountController(
//             UserManager<IdentityUser<int>> userManager,
//             SignInManager<IdentityUser<int>> signInManager)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//         }

//         [HttpOptions]
//         public IActionResult GetLoginAPIOptions()
//         {
//             Response.Headers.Add("Allow", "GET,OPTIONS,POST");
//             return Ok();
//         }
//         [HttpGet]
//         [ProducesResponseType(404)]
//         [ProducesResponseType(500)]
//         public async Task<IActionResult> Login(string returnUrl = null)
//         {
//             // Clear the existing external cookie 
//             //to ensure a clean login process
//             // await HttpContext
//             //     .SignOutAsync(IdentityConstants.ExternalScheme);

//             // ViewData["ReturnUrl"] = returnUrl;
//              return Ok();            
//         }
        
//         [HttpGet]
//         public async Task<IActionResult> Login(
//             LoginViewModel model,
//            string returnUrl = null)
//         {
//             ViewData["ReturnUrl"] = returnUrl;
//             if (User.Identity.IsAuthenticated)
//             {
//                 await HttpContext.SignOutAsync();
//                 return View(model);
//             }
//             if (ModelState.IsValid)
//             {
//                 // This doesn't count login failures towards account lockout
//                 // To enable password failures to trigger account lockout, set lockoutOnFailure: true
//                 var result = await _signInManager.PasswordSignInAsync(
//                     model.UserName, 
//                     model.Password, model.RememberMe, lockoutOnFailure: false);
//                 if (result.Succeeded)
//                 {
//                     if (!string.IsNullOrEmpty(returnUrl))
//                     return Ok(returnUrl);
//                         //return LocalRedirect(returnUrl);
//                     // else
//                     //     return RedirectToAction(nameof(HomeController.Index), "Home");
//                 }
//                 else
//                 {
//                     ModelState.AddModelError(string.Empty, "wrong user name or password");
//                     return Ok();
//                 }
//             }

//             // If we got this far, something failed, redisplay form
//             return Ok(model);
//         }
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Logout()
//         {
//             await _signInManager.SignOutAsync();
//             return NoContent();
//             // return RedirectToAction(nameof(HomeController.Index), "Home");
//         }
//     }
// }
