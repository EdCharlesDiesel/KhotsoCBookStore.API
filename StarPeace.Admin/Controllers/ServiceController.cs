using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarPeace.Admin.Services;
using StarPeace.Admin.Contexts;
using StarPeace.Admin.Entities;
using Microsoft.EntityFrameworkCore;

namespace StarPeace.Admin.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : Controller,ICustomer
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public ServiceController(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return _dbContext.Customers.ToList();        
        }

        [HttpGet("{customerid}")]
        public Customer Get(string customerid)
        {
            return _dbContext.Customers.Where(m => m.CustomerID == customerid).SingleOrDefault();            
        }

        [HttpPost]
        public void Post([FromBody]Customer obj)
        {
            _dbContext.Customers.Add(obj);
            _dbContext.SaveChanges();
        }

        [HttpPut("{customerid}")]
        public void Put(string customerid, [FromBody]Customer obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        [HttpDelete("{customerid}")]
        public void Delete(string customerid)
        {
            Customer obj = _dbContext.Customers.Where(m => m.CustomerID == customerid).SingleOrDefault();
            _dbContext.Customers.Remove(obj);
            _dbContext.SaveChanges();
            
        }
    }
}
