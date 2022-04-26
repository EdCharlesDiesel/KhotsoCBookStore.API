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
    public class CategoryEventRepository : ICategoryEventRepository
    {
        private MainDbContext context;
        public CategoryEventRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<ICategoryEvent>> GetFirstN(int n)
        {
            return await context.CategoryEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public ICategoryEvent New(CategoryEventType type, int id, long oldVersion, long? newVersion=null, string categoryName=null)
        {
            var model = new CategoryEvent
            {
                Type = type,
                CategoryId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion,
                CategoryName = categoryName
            };
            context.CategoryEvents.Add(model);
            return model;
        }
    }
}
