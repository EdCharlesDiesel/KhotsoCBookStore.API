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
//     public class EmployeeEventRepository : IEmployeeEventRepository
//     {
//         private MainDbContext context;
//         public EmployeeEventRepository(MainDbContext context)
//         {
//             this.context = context;
//         }
//         public IUnitOfWork UnitOfWork => context;

//         public async Task<IEnumerable<IEmployeeEvent>> GetFirstN(int n)
//         {
//             return await context.EmployeeEvents
//                 .OrderBy(m => m.Id)
//                 .Take(n)
//                 .ToListAsync();
//         }

//         public IEmployeeEvent New(EmployeeEventType type, int id, long oldVersion, long? newVersion=null, decimal bookStartPrice=0)
//         {
//             var model = new EmployeeEvent
//             {
//                 Type = type,
//                 EmployeeId = id,
//                 OldVersion = oldVersion,
//                 NewVersion = newVersion,
//                 NewBookStartPrice = bookStartPrice
//             };
//             context.EmployeeEvents.Add(model);
//             return model;

//         }
//     }
// }
