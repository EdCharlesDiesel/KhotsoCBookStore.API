using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB.Repositories
{
    public class BookTitleRepository : IBookTitleRepository
    {
        private MainDbContext context;
        public BookTitleRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IBookTitle> Get(int id)
        {
            return await context.BookTitles.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IBookTitle> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.BookTitles.Remove(model as BookTitle);
            model.AddDomainEvent(
                new BookTitleDeleteEvent(
                    model.Id, (model as BookTitle).EntityVersion));
            return model;
        }

        public IBookTitle New()
        {
            var model = new BookTitle();
            context.BookTitles.Add(model);
            return model;
        }        
    }
}
