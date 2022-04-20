using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Helpers;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Controllers
{
    public class VisitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string visitortype)
        {
            ISwitchboardVisitor visitor = null;
            if (visitortype == "Normal")
            {
                visitor = new NormalVisitor();
            }
            else
            {
                visitor = new SpecialVisitor();
            }

            Switchboard switchboard = new Switchboard(visitor);
            switchboard.Items.Add(new Enclosure() { Cost = 50000 });
            switchboard.Items.Add(new Transformer() { Cost = 10000 });
            switchboard.Items.Add(new Busbars() { Cost = 5000 });
            switchboard.Items.Add(new CircuitBreaker() { Cost = 20000 });
            double totalCost = switchboard.Calculate();
            ViewBag.PackingShippingType = visitortype;
            ViewBag.TotalCost = totalCost;
            return View();
        }
    }
}
