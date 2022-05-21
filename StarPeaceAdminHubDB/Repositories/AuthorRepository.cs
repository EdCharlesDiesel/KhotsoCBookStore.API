using DDD.DomainLayer;
using System.Threading.Tasks;
using System.Linq;
using StarPeaceAdminHubDomain.Aggregates;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Events;
using StarPeaceAdminHubDomain.IRepositories;

namespace StarPeaceAdminHubDB.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly MainDbContext context;
        public AuthorRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IAuthor> Get(int id)
        {
            return await context.Authors.Where(m => m.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IAuthor> Delete(int id)
        {
            var model = await Get(id);
            if (model is not Author Author) return null;
            context.Authors.Remove(Author);
            model.AddDomainEvent(
               new AuthorDeleteEvent(
                    model.Id, Author.EntityVersion));
            return model;
        }
        public IAuthor New()
        {
            var model = new Author() {EntityVersion=1 };
            context.Authors.Add(model);
            return model;
        }
    }
}
