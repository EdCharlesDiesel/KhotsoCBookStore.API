// using DDD.DomainLayer;
// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.IRepositories;
// using System.Threading.Tasks;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using StarPeaceAdminHubDomain.Events;

// namespace StarPeaceAdminHubDB.Repositories
// {
//     public class PublisherRepository : IPublisherRepository
//     {
//         private MainDbContext context;
//         public PublisherRepository(MainDbContext context)
//         {
//             this.context = context;
//         }
//         public IUnitOfWork UnitOfWork => context;

//         public async Task<IPublisher> Get(int id)
//         {
//             return await context.Publishers.Where(m => m.Id == id)
//                 .FirstOrDefaultAsync();
//         }
       
//         public IPublisher New()
//         {
//             var model = new Publisher() {EntityVersion=1 };
//             context.Publishers.Add(model);
//             return model;
//         }

//          public async Task<IPublisher> Delete(int id)
//         {
//             var model = await Get(id);
//             if (model == null) return null;
//             context.Publishers.Remove(model as Publisher);
//             model.AddDomainEvent(
//                 new PublisherDeleteEvent(
//                     model.Id, (model as Publisher).EntityVersion));
//             return model;
//         }
//     }
// }
