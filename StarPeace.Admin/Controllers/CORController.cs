using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using StarPeace.Admin.Helpers;

namespace StarPeace.Admin.Controllers
{
    public class CORController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                ContentDispositionHeaderValue header = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                string fileName = header.FileName;
                fileName = fileName.Trim('"');
                fileName = Path.GetFileName(fileName);

                MemoryStream ms = new MemoryStream();
                Stream s = file.OpenReadStream();
                s.CopyTo(ms);
                byte[] data = ms.ToArray();
                s.Dispose();
                ms.Dispose();
                string fileContent = System.Text.ASCIIEncoding.ASCII.GetString(data);

                FileFormatHandler handler1 = new FileFormatHandler();
                FileStorageHandler handler2 = new FileStorageHandler();
                DataImportHandler handler3 = new DataImportHandler();

                handler1.NextHandler = handler2;
                handler2.NextHandler = handler3;
                handler3.NextHandler = null;

                handler1.Process(fileName, fileContent);
            }
            ViewBag.Message = files.Count + " file(s) imported successfully!";
            return View("Index");
        }
    }
}
