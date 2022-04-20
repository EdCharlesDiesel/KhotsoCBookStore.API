using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StarPeace.Admin.Controllers
{
    public class ServiceLayerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
