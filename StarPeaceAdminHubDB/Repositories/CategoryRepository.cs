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
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private MainDbContext context;
        public CategoryRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<ICategory> Get(int id)
        {
            return await context.Categorys.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<ICategory> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.Categorys.Remove(model as Category);
            model.AddDomainEvent(
                new CategoryDeleteEvent(
                    model.Id, (model as Category).EntityVersion));
            return model;
        }
        public ICategory New()
        {
            var model = new Category() {EntityVersion=1 };
            context.Categorys.Add(model);
            return model;
        }
    }
}
