using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using StarPeace.Admin.Helpers;
using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;

namespace TemplateMethod.Controllers
{
    public class HomeController : Controller
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public HomeController(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessOrder(string type)
        {
            OrderProcessor processor = null;

            if(type=="store")
            {
                processor = new StoreOrderProcessor();
            }
            else
            {
                processor = new OnlineOrderProcessor();
            }
            int orderId = new Random().Next(100, 1000);
            processor.ProcessOrder(orderId);
           
            List<OrderLog> logs = _dbContext.OrderLog.Where(o => o.OrderId == orderId).ToList();
            return View("Success", logs);
        }
    }
}
