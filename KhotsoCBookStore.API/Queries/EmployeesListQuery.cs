using KhotsoCBookStore.API.Models;
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
                Title = o.Title,
                TitleOfCourtesy = o.TitleOfCourtesy,
                BirthDate = o.BirthDate,
                HireDate = o.HireDate,
                Address = o.Address,
                City = o.City,
                Region = o.Region,
                PostalCode = o.PostalCode,
                Country = o.Country,
                Photo = o.Photo,
                Notes = o.Notes,
                ReportsTo = o.ReportsTo,
                PhotoPath = o.PhotoPath
            }).ToListAsync();
        }


        public async Task<EmployeeInfosViewModel> GetEmployeeById(int authorId)
        {
            return await ctx.Employees.Select(o => new EmployeeInfosViewModel
            {
                FirstName = o.FirstName,
                LastName = o.LastName,
                IdNumber = o.IdNumber,
                Title = o.Title,
                TitleOfCourtesy = o.TitleOfCourtesy,
                BirthDate = o.BirthDate,
                HireDate = o.HireDate,
                Address = o.Address,
                City = o.City,
                Region = o.Region,
                PostalCode = o.PostalCode,
                Country = o.Country,
                Photo = o.Photo,
                Notes = o.Notes,
                ReportsTo = o.ReportsTo,
                PhotoPath = o.PhotoPath
            }).FirstOrDefaultAsync();
        }

    }
}
