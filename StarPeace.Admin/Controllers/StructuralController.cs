using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarPeace.Admin.Models;
using StarPeace.Admin.Helpers;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Controllers
{
    public class StructuralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }   

        public IActionResult FlyWeight()
        {
            return View();
        }  
        // Facade
        public IActionResult Search(string isbn)
        {
            PriceComparer comparer = new PriceComparer();
            List<Book> books = comparer.Compare(isbn);
            return View("Results",books);
        } 

        // Proxy
        [HttpPost]
        public IActionResult ShowStats(string host)
        {
            WebsiteStatsFactory factory = new WebsiteStatsFactory();
            WebsiteStats stats = (WebsiteStats)factory[host];
            if (stats == null)
            {
                ViewBag.Message = "Invalid Host Name!";
                return View("Index");
            }
            else
            {
                return View(stats);
            }
        } 
    }
}
