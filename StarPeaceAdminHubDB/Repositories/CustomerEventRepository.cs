// using DDD.DomainLayer;
// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.IRepositories;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using StarPeaceAdminHubDB.Models;

// namespace StarPeaceAdminHubDB.Repositories
// {
//     public class CustomerEventRepository : ICustomerEventRepository
//     {
//         private MainDbContext context;
//         public CustomerEventRepository(MainDbContext context)
//         {
//             this.context = context;
//         }
//         public IUnitOfWork UnitOfWork => context;

//         public async Task<IEnumerable<ICustomerEvent>> GetFirstN(int n)
//         {
//             return await context.CustomerEvents
//                 .OrderBy(m => m.Id)
//                 .Take(n)
//                 .ToListAsync();
//         }

//         public ICustomerEvent New(CustomerEventType type, int id, long oldVersion, long? newVersion=null, decimal bookStartPrice=0)
//         {
//             var model = new CustomerEvent
//             {
//                 Type = type,
//                 CustomerId = id,
//                 OldVersion = oldVersion,
//                 NewVersion = newVersion,
//                 NewBookStartPrice = bookStartPrice
//             };
//             context.CustomerEvents.Add(model);
//             return model;

//         }
//     }
// }
