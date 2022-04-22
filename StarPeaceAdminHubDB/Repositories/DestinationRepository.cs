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

namespace StarPeaceAdminHubDB.Repositories
{
    public class DestinationRepository : IDestinationRepository

    {
        private MainDbContext context;
        public DestinationRepository(MainDbContext context)
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
