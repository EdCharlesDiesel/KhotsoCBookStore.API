// using DDD.DomainLayer;
// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.IRepositories;
// using System.Threading.Tasks;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using StarPeaceAdminHubDomain.Events;

// namespace StarPeaceAdminHubDB.Repositories
// {
//     public class MemberOrderRepository : IMemberOrderRepository
//     {
//         private MainDbContext context;
//         public MemberOrderRepository(MainDbContext context)
//         {
//             this.context = context;
//         }
//         public IUnitOfWork UnitOfWork => context;

//         public async Task<IMemberOrder> Get(int id)
//         {
//             return await context.MemberOrders.Where(m => m.Id == id)
//                 .FirstOrDefaultAsync();
//         }
       
//         public IMemberOrder New()
//         {
//             var model = new MemberOrder() {EntityVersion=1 };
//             context.MemberOrders.Add(model);
//             return model;
//         }

//          public async Task<IMemberOrder> Delete(int id)
//         {
//             var model = await Get(id);
//             if (model == null) return null;
//             context.MemberOrders.Remove(model as MemberOrder);
//             model.AddDomainEvent(
//                 new MemberOrderDeleteEvent(
//                     model.Id, (model as MemberOrder).EntityVersion));
//             return model;
//         }
//     }
// }
