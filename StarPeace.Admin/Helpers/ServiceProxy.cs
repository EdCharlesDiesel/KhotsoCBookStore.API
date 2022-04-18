using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using StarPeace.Admin.Services;
using StarPeace.Admin.Entities;

namespace StarPeace.Admin.Helpers
{
    public class ServiceProxy : ICustomer
    {
        private HttpClient client = new HttpClient();

        public ServiceProxy()
        {
            client.BaseAddress = new Uri(AppSettings.ServiceBaseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Customer> Get()
        {
            HttpResponseMessage response = client.GetAsync(AppSettings.ServiceUrl).Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            List<Customer> data = JsonConvert.DeserializeObject<List<Customer>> (jsonData);
            System.IO.File.AppendAllText(AppSettings.LogFilePath, $"Get() called on {DateTime.Now}");
            return data;
        }

        public Customer Get(string customerid)
        {
            HttpResponseMessage response = client.GetAsync(AppSettings.ServiceUrl + $"/{customerid}").Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            Customer data = JsonConvert.DeserializeObject<Customer>(jsonData);
            System.IO.File.AppendAllText(AppSettings.LogFilePath, $"Get({customerid}) called on {DateTime.Now}");
            return data;
        }

        public void Post(Customer obj)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(jsonData);
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/json");
            HttpResponseMessage response = client.PostAsync(AppSettings.ServiceUrl, content).Result;
            System.IO.File.AppendAllText(AppSettings.LogFilePath, $"Post() called on {DateTime.Now}");
        }

        public void Put(string customerid, Customer obj)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(jsonData);
            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/json");
            HttpResponseMessage response = client.PutAsync(AppSettings.ServiceUrl + $"/{customerid}", content).Result;
            System.IO.File.AppendAllText(AppSettings.LogFilePath, $"Put() called on {DateTime.Now}");
        }

        public void Delete(string customerid)
        {
            HttpResponseMessage response = client.DeleteAsync(AppSettings.ServiceUrl + $"/{customerid}").Result;
            System.IO.File.AppendAllText(AppSettings.LogFilePath, $"Delete() called on {DateTime.Now}");
        }
    }
}
