using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860  

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]  
    [Route("api/[controller]")]  
    [ApiController]  
    // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication
    // .JwtBearer.JwtBearerDefaults.AuthenticationScheme)]  
    [Authorize]
    public class BaseController : ControllerBase  
    {  
        
    }  
} 