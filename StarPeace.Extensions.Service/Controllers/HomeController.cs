using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StarPeace.Extensions.Service.Controllers
{
    public class HomeController : Controller
    {
        //Prototype
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

                UploadedFile primaryObj = new UploadedFile();
                primaryObj.FileName = fileName;
                primaryObj.ContentType = file.ContentType;
                primaryObj.Size = file.Length;
                primaryObj.TimeStamp = DateTime.Now;
                primaryObj.FileContent = data;

                IUploadedFile backupObj = primaryObj.Clone();

                //IUploadedFile backupObj = primaryObj.DeepCopy();

                //send primaryObj to main system
                //send backupObj to backup system
            }
            ViewBag.Message = files.Count +  " file(s) uploaded successfully!";
            return View("Index");
        }
        // Singleton
        public IActionResult Index()
        {
            WebsiteMetadata metadata = WebsiteMetadata.GetInstance();
            return OK(metadata);
        }

        // Factory Method
        [HttpGet]
        public IActionResult GetImageFree()
        {
            ChartProviderFree cp = new ChartProviderFree();
            IChart chart = cp.GetChart();
            chart.Title = "Hours per day";
            List<string> xdata = new List<string>();
            xdata.Add("Mon");
            xdata.Add("Tue");
            xdata.Add("Wed");
            xdata.Add("Thu");
            xdata.Add("Fri");
            xdata.Add("Sat");
            xdata.Add("Sun");
            List<int> ydata = new List<int>();
            ydata.Add(12);
            ydata.Add(7);
            ydata.Add(4);
            ydata.Add(10);
            ydata.Add(3);
            ydata.Add(11);
            ydata.Add(5);
            chart.XData = xdata;
            chart.YData = ydata;
            Bitmap bmp = chart.GenerateChart();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

         [HttpGet]
        public IActionResult GetImagePaid()
        {
            ChartProviderPaid cp = new ChartProviderPaid();
            IChart chart = cp.GetChart();
            chart.Title = "Hours per day";
            List<string> xdata = new List<string>();
            xdata.Add("Mon");
            xdata.Add("Tue");
            xdata.Add("Wed");
            xdata.Add("Thu");
            xdata.Add("Fri");
            xdata.Add("Sat");
            xdata.Add("Sun");
            List<int> ydata = new List<int>();
            ydata.Add(12);
            ydata.Add(7);
            ydata.Add(4);
            ydata.Add(10);
            ydata.Add(3);
            ydata.Add(11);
            ydata.Add(5);
            chart.XData = xdata;
            chart.YData = ydata;
            Bitmap bmp = chart.GenerateChart();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

        public IActionResult GetCustomers()
        {
            using (CustomerRepository repository = new CustomerRepository())
            {
                List<Customer> customers = repository.SelectAll();
                Customers = from c in customers
                            select new SelectListItem()
                            {
                                Text = c.CustomerID,
                                Value = c.CustomerID
                            };
                return Ok();
            }
        }

        [HttpPost]
        public IActionResult SelectByID(string customerid)
        {
            using (CustomerRepository repository = new CustomerRepository())
            {
                Customer data = repository.SelectByID(customerid);
                List<Customer> customers = repository.SelectAll();
                Customers = from c in customers
                            select new SelectListItem()
                            {
                                Text = c.CustomerID,
                                Value = c.CustomerID
                            };
                return Ok(data);
            }
        }

        [HttpPost]
        public IActionResult Update(Customer obj)
        {
            using (CustomerRepository repository = new CustomerRepository())
            {
                repository.Update(obj);
                repository.Save();
                List<Customer> customers = repository.SelectAll();
                Customers = from c in customers
                            select new SelectListItem()
                            {
                                Text = c.CustomerID,
                                Value = c.CustomerID
                            };
                Message = "Customer modified successfully!";
                return OK(obj);
            }
        }
    }
}
