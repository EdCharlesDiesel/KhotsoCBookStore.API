using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private MainDbContext context;
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
       
        public IAuthor New()
        {
            var model = new Author() {EntityVersion=1 };
            context.Authors.Add(model);
            return model;
        }

         public async Task<IAuthor> Delete(int id)
        {
            var model = await Get(id);
            if (model == null) return null;
            context.Authors.Remove(model as Author);
            model.AddDomainEvent(
                new AuthorDeleteEvent(
                    model.Id, (model as Author).EntityVersion));
            return model;
        }
    }
}
