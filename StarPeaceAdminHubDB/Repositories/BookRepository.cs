using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;
using StarPeaceAdminHubDB.Contexts;

namespace StarPeaceAdminHubDB.Repositories
{
    public class BookRepository : IDestinationRepository

    {
        private MainDbContext context;
        public BookRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IDestination> Get(int id)
        {
            return await context.Destinations.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public IDestination New()
        {
            var model = new Destination();
            context.Destinations.Add(model);
            return model;
        }
    }
}
