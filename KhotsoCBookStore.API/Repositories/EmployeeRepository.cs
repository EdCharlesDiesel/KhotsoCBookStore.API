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

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            try
            {
                if (newEmployee != null)
                {
                   await _dbContext.AddAsync(newEmployee);
                }
    
                return await _dbContext.Employees.LastOrDefaultAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAync()
        {
            try
            {
                return await _dbContext.Employees.OrderBy(e=>e.LastName).ToListAsync();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
           try
           {
                return await _dbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == employeeId);
           }
           catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public void DeleteEmployee(Employee employeeToDelete)
        {
            
            try
            {
                _dbContext.Employees.Remove(employeeToDelete);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _dbContext.SaveChangesAsync() >= 0);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }

        public async Task<bool> EmployeeIfExistsAsync(Guid employeeId)
        {
            try
            {
                return await _dbContext.Employees.AnyAsync(c => c.EmployeeId == employeeId);
            }
            catch (System.Exception ex)
            {
                throw new AggregateException(ex.Message);
            }
        }
    }
}
