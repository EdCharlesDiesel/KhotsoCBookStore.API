using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using StarPeace.Admin.Entities;


namespace StarPeace.Admin.Repositories
{
    public class ServiceAClient
    {
        public Book SearchBook(string isbn)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/ServiceA/" + isbn).Result;
            string jsonData = response.Content.ReadAsStringAsync().Result;
            Book book = JsonConvert.DeserializeObject<Book>(jsonData);
            return book;
        }
    }
}
