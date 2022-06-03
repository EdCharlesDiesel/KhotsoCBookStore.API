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
//     public class MemberOrderEventRepository : IMemberOrderEventRepository
//     {
//         private MainDbContext context;
//         public MemberOrderEventRepository(MainDbContext context)
//         {
//             this.context = context;
//         }
//         public IUnitOfWork UnitOfWork => context;

//         public async Task<IEnumerable<IMemberOrderEvent>> GetFirstN(int n)
//         {
//             return await context.MemberOrderEvents
//                 .OrderBy(m => m.Id)
//                 .Take(n)
//                 .ToListAsync();
//         }

//         public IMemberOrderEvent New(MemberOrderEventType type, int id, long oldVersion, long? newVersion=null, decimal bookStartPrice=0)
//         {
//             var model = new MemberOrderEvent
//             {
//                 Type = type,
//                 MemberOrderId = id,
//                 OldVersion = oldVersion,
//                 NewVersion = newVersion,
//                 NewBookStartPrice = bookStartPrice
//             };
//             context.MemberOrderEvents.Add(model);
//             return model;

//         }
//     }
// }
