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
    public class BookTitleEventRepository : IBookTitleEventRepository
    {
        private MainDbContext context;
        public BookTitleEventRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<IBookTitleEvent>> GetFirstN(int n)
        {
            return await context.BookTitleEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IBookTitleEvent New(BookTitleEventType type, int id, long oldVersion, long? newVersion=null)
        {
            var model = new BookTitleEvent
            {
                Type = type,
                BookTitleId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion
            };
            context.BookTitleEvents.Add(model);
            return model;
        }
    }
}
