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
    public class BookRepository : ICategoryRepository

    {
        private MainDbContext context;
        public BookRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<Category> Get(Guid id)
        {
            return await context.Categories.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public Category New()
        {
            var model = new Categories();
            context.Categories.Add(model);
            return model;
        }
    }
}
