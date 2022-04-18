using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using StarPeace.Admin.Entities;


namespace StarPeace.Admin.Services
{
    public interface ICustomer
    {
        List<Customer> Get();
        Customer Get(string customerid);
        void Post(Customer obj);
        void Put(string customerid, Customer obj);
        void Delete(string customerid);
    }
}
