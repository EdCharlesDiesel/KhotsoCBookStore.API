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

        public IAuthorEvent New(AuthorEventType type, int id, long oldVersion, long? newVersion=null, decimal bookStartPrice=0)
        {
            // var model = new AuthorEvent
            // {
            //     Type = type,
            //     AuthorId = id,
            //     OldVersion = oldVersion,
            //     NewVersion = newVersion,
            //     NewBookStartPrice = bookStartPrice
            // };
            // context.AuthorEvents.Add(model);
            // return model;

            throw new NotImplementedException();
        }
    }
}
