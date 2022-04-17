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
        //Builder
        public IActionResult Build(string usagetype)
        {
            IBookSeriesBuilder builder = null;
            switch(usagetype)
            {
                case "programming":
                    builder = new ProgrammingBookSeriesBuilder();
                    break;
                case "selfHelp":
                    builder = new SelfHelpBookSeriesBuilder();
                    break;
                case "Career":
                    builder = new CareerBookSeriesBuilder();
                    break;
            }
            BookSeriesAssembler assembler = new BookSeriesAssembler(builder);
            BookSeries bookSeries = assembler.AssembleBookSeries();
            return Ok(bookSeries);
        }
        
        // Abstract Factory
        [HttpPost]
        public IActionResult ExecuteQuery(string factorytype,string query)
        {
            IDatabaseFactory factory = null;
            if (factorytype == "sqlclient")
            {
                factory = new SqlClientFactory();
            }
            else
            {
                factory = new OleDbFactory();
            }
            DatabaseHelper helper = new DatabaseHelper(factory);
            query = query.ToLower();
            if(query.StartsWith("select"))
            {
                DbDataReader reader = helper.ExecuteSelect(query);
                return Ok( reader);
            }
            else
            {
                int i = helper.ExecuteAction(query);
                return Ok( i);
            }
        }

        [HttpPost]
        public IActionResult ExecuteQueryConfig(string query)
        {
            IDatabaseFactory factory = null;

            string factorytype = AppSettings.Factory;


            if (factorytype == "sqlclient")
            {
                factory = new SqlClientFactory();
            }
            else
            {
                factory = new OleDbFactory();
            }

            DatabaseHelper helper = new DatabaseHelper(factory);

            query = query.ToLower();

            if (query.StartsWith("select"))
            {
                DbDataReader reader = helper.ExecuteSelect(query);
                return Ok( reader);
            }
            else
            {
                int i = helper.ExecuteAction(query);
                return Ok(i);
            }
        }

        [HttpPost]
        public IActionResult ExecuteQueryReflection(string query)
        {
            IDatabaseFactory factory = null;

            string factorytype = AppSettings.FactoryType;

            ObjectHandle o = Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, factorytype);
            factory = (IDatabaseFactory)o.Unwrap();

            DatabaseHelper helper = new DatabaseHelper(factory);

            query = query.ToLower();

            if (query.StartsWith("select"))
            {
                DbDataReader reader = helper.ExecuteSelect(query);
                return Ok(reader);
            }
            else
            {
                int i = helper.ExecuteAction(query);
                return Ok(i);
            }
        }
        
        // Prototype
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
            OkBag.Message = files.Count +  " file(s) uploaded successfully!";
            return Ok("Index");
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

    }
}
