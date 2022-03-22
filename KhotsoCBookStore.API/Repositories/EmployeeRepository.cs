using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class EmployeeRepository : IEmployeeService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;

        public EmployeeRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAync()
        {
            return await _dbContext.Employees.OrderBy(e=>e.LastName).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid employeeId)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == employeeId);
        }

        public async Task<Employee> CreateEmployeeAsync(EmployeeForCreateDto newEmployee)
        {
            if (newEmployee != null)
            {
               await _dbContext.AddAsync(newEmployee);
            }

            return await _dbContext.Employees.LastOrDefaultAsync();
        }

        public Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employeeToDelete)
        {
            _dbContext.Employees.Remove(employeeToDelete);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> EmployeeIfExistsAsync(Guid employeeId)
        {
            return await _dbContext.Employees.AnyAsync(c => c.EmployeeId == employeeId);
        }

        Task<IEnumerable<EmployeeDto>> IEmployeeService.GetAllEmployeesAync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeAsync(EmployeeForUpdateDto employeeToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
