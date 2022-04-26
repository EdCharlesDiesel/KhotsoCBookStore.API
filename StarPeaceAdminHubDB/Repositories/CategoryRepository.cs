using DDD.DomainLayer;
using StarPeaceAdminHub.Aggregates;
using StarPeaceAdminHubDB.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHub.Models;
using StarPeaceAdminHub.Events;
using StarPeaceAdminHubDB.Contexts;
using StarPeaceAdminHubDomain.IRepositories;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDB.Models;

namespace StarPeaceAdminHubDB.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainDbContext context;
        public CategoryRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<ICategory> Get(Guid id)
        {
            return await context.Categories.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<ICategory> Delete(Guid id)
        {
            var model = await Get(id);
            if (model is not Category category) return null;
            context.Categories.Remove(category);
            model.AddDomainEvent(
               new CategoryDeleteEvent(
                    model.Id, category.EntityVersion));
            return model;

        }
        public ICategory New()
        {
            var model = new Category() {EntityVersion=1 };
            context.Categories.Add(model);
            return model;
        }
    }
}
