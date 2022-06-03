using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;

namespace StarPeaceAdminHubDB.Repositories
{
    public class PublisherEventRepository : IPublisherEventRepository
    {
        private MainDbContext context;
        public PublisherEventRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<IPublisherEvent>> GetFirstN(int n)
        {
            return await context.PublisherEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IPublisherEvent New(PublisherEventType type, int id, long oldVersion, long? newVersion=null)
        {
            var model = new PublisherEvent
            {
                Type = type,
                PublisherId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion,
            };
            context.PublisherEvents.Add(model);
            return model;

        }
    }
}
