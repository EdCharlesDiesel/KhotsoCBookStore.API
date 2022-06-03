// using DDD.DomainLayer;
// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.IRepositories;
// using System.Threading.Tasks;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using StarPeaceAdminHubDomain.Events;

// namespace StarPeaceAdminHubDB.Repositories
// {
//     public class EmployeeRepository : IEmployeeRepository
//     {
//         private MainDbContext context;
//         public EmployeeRepository(MainDbContext context)
//         {
//             this.context = context;
//         }
//         public IUnitOfWork UnitOfWork => context;

//         public async Task<IEmployee> Get(int id)
//         {
//             return await context.Employees.Where(m => m.Id == id)
//                 .FirstOrDefaultAsync();
//         }
       
//         public IEmployee New()
//         {
//             var model = new Employee() {EntityVersion=1 };
//             context.Employees.Add(model);
//             return model;
//         }

//          public async Task<IEmployee> Delete(int id)
//         {
//             var model = await Get(id);
//             if (model == null) return null;
//             context.Employees.Remove(model as Employee);
//             model.AddDomainEvent(
//                 new EmployeeDeleteEvent(
//                     model.Id, (model as Employee).EntityVersion));
//             return model;
//         }
//     }
// }
