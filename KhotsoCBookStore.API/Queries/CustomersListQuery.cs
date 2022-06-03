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
            return await ctx.Customers.Select(m => new CustomerInfosViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                DateOfBirth = m.DateOfBirth,
                IdNumber = m.IdNumber,
                SocialMediaFaceBook = m.SocialMediaFaceBook
            }).ToListAsync();
        }

        public async Task<CustomerInfosViewModel> GetCustomerById(int customerId)
        {
               return await ctx.Customers.Select(m => new CustomerInfosViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                DateOfBirth = m.DateOfBirth,
                IdNumber = m.IdNumber,
                SocialMediaFaceBook = m.SocialMediaFaceBook
            }).FirstOrDefaultAsync();
        }
    }
}
