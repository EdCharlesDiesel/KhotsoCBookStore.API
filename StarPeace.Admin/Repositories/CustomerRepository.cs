using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;


namespace StarPeace.Admin.Repositories
{
    //public class CustomerRepository:IRepository<Customer,string>,IDisposable

    public class CustomerRepository:ICustomerRepository,IDisposable
    {
        private StarPeaceAdminDbContext db;

        public CustomerRepository()
        {
            this.db = new StarPeaceAdminDbContext();
        }

        public CustomerRepository(StarPeaceAdminDbContext db)
        {
            this.db = db;
        }

        public List<Customer> SelectAll()
        {
            return db.Customers.ToList();
        }

        public Customer SelectByID(string id)
        {
            return db.Customers.Where(c => c.CustomerID == id).SingleOrDefault();
        }

        public void Insert(Customer obj)
        {
            db.Customers.Add(obj);
        }

        public void Update(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            Customer obj = db.Customers.Where(c => c.CustomerID == id).SingleOrDefault();
            db.Customers.Remove(obj);
        }

        public void Save()
        {
            db.SaveChanges();            
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
