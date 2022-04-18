using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using Interpreter.Core;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using StarPeace.Admin.Contexts;
using StarPeace.Admin.Helpers;

namespace StarPeace.Admin.Controllers
{
    public class HomeController : Controller
    {
        IHostingEnvironment env;

        public HomeController(IHostingEnvironment env)
        {
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExecuteJSON(List<IFormFile> files)
        {
            foreach (IFormFile file in files)
            {
                //save file
                ContentDispositionHeaderValue header = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                string fileName = header.FileName;
                fileName = fileName.Trim('"');
                fileName = Path.GetFileName(fileName);

                var fi1 = env.WebRootFileProvider.GetFileInfo("/BatchFiles/" + fileName);
                string filePath = fi1.PhysicalPath;
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                //load file
                List<ApiCall> apiCalls = JsonConvert.DeserializeObject<List<ApiCall>>(System.IO.File.ReadAllText(filePath));
                InterpreterContext context = new InterpreterContext();
                var fi2 = env.WebRootFileProvider.GetFileInfo("/AssemblyStore");
                context.AssemblyStore = fi2.PhysicalPath;
                context.BasePath = env.WebRootPath;

                //execute commands
                foreach (ApiCall call in apiCalls)
                {
                    call.Interpret(context);
                }
            }
            ViewBag.Message = "API calls from the file(s) have been executed!";
            return View("Index");
        }

       
    }
}
