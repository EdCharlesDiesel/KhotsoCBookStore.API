using Microsoft.EntityFrameworkCore;
using KhotsoCBookStore.API.Models.Publishers;
using StarPeaceAdminHubDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public class PublishersListQuery : IPublishersListQuery
    {
        MainDbContext ctx;
        public PublishersListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<PublisherInfosViewModel>> GetAllPublishers()
        {
            return await ctx.Publishers.Select(o => new PublisherInfosViewModel
            {
                CompanyName = o.CompanyName,
                ContactName = o.ContactName,
                ContactTitle = o.ContactTitle,
                Address = o.Address,
                City = o.City,
                Region = o.Region,
                PostalCode = o.PostalCode,
                Country = o.Country,
                Phone = o.Phone,
                Fax = o.Fax,
                HomePage = o.HomePage
            }).ToListAsync();
        }

        public Task<PublisherInfosViewModel> GetPublisherById(int PublisherId)
        {
            throw new System.NotImplementedException();
        }
    }
}
