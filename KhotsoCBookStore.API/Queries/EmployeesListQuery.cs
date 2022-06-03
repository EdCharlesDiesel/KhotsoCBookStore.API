using KhotsoCBookStore.API.Models.Employees;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public class EmployeesListQuery : IEmployeesListQuery
    {
        private readonly MainDbContext ctx;
        public EmployeesListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<EmployeeInfosViewModel>> GetAllEmployees()
        {
            return await ctx.Employees.Select(o => new EmployeeInfosViewModel
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                IdNumber = o.IdNumber,
                StartOfEmployment = o.StartOfEmployment,
                EndOfEmployement = o.EndOfEmployement,
            }).ToListAsync();
        }

      
        public async Task<EmployeeInfosViewModel> GetEmployeeById(int authorId)
        {
            return await ctx.Employees.Select(o => new EmployeeInfosViewModel
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                IdNumber = o.IdNumber,
                StartOfEmployment = o.StartOfEmployment,
                EndOfEmployement = o.EndOfEmployement,
            }).FirstOrDefaultAsync();
        }
        
    }
}
