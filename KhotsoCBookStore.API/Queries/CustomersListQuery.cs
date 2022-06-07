using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Models;

namespace KhotsoCBookStore.API.Queries
{
    public class CustomersListQuery : ICustomersListQuery
    {
        MainDbContext ctx;
        public CustomersListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<CustomerInfosViewModel>> GetAllCustomers()
        {
            return await ctx.Customers.Select(o => new CustomerInfosViewModel
            {
                CustomerId = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                DateOfBirth = o.DateOfBirth,
                ContactTitle = o.ContactTitle,
                Address = o.Address,
                City = o.City,
                Region = o.Region,
                PostalCode = o.PostalCode,
                Country = o.Country,
                Phone = o.Phone,
                MobileNumber = o.MobileNumber,
            }).ToListAsync();
        }

        public async Task<CustomerInfosViewModel> GetCustomerById(int customerId)
        {
            return await ctx.Customers.Select(o => new CustomerInfosViewModel
            {
                CustomerId = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                DateOfBirth = o.DateOfBirth,
                ContactTitle = o.ContactTitle,
                Address = o.Address,
                City = o.City,
                Region = o.Region,
                PostalCode = o.PostalCode,
                Country = o.Country,
                Phone = o.Phone,
                MobileNumber = o.MobileNumber,
            }).FirstOrDefaultAsync();
        }
    }
}
