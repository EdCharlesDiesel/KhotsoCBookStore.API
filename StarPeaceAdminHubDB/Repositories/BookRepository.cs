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
    public class BookRepository : IBookRepository
    {
        private MainDbContext context;
        public BookRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IBook> Get(int id)
        {
            return await context.Books.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IBook> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.Books.Remove(model as Book);
            model.AddDomainEvent(
                new BookDeleteEvent(
                    model.Id, (model as Book).EntityVersion));
            return model;
        }
        public IBook New()
        {
            var model = new Book() {EntityVersion=1 };
            context.Books.Add(model);
            return model;
        }
    }
}
