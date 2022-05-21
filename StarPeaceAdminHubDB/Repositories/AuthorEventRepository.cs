using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;
using AuthorsManagementDomain.IRepositories;

namespace StarPeaceAdminHubDB.Repositories
{
    public class AuthorEventRepository : IAuthorEventRepository
    {
        private MainDbContext context;
        public AuthorEventRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<IAuthorEvent>> GetFirstN(int n)
        {
            return await context.AuthorEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IAuthorEvent New(AuthorEventType type, int id, long oldVersion, long? newVersion=null, decimal price=0)
        {
            var model = new AuthorEvent
            {
                Type = type,
                AuthorId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion,
                NewBookStartPrice = price
            };
            context.AuthorEvents.Add(model);
            return model;
        }
    }
}
