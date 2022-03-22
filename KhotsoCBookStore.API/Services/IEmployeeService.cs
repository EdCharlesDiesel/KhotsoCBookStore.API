using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace KhotsoCBookStore.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAync();
        
        Task<Employee> GetEmployeeAsync(Guid employeeId);
        
        Task<Employee> CreateEmployeeAsync(CreateEmployeeDto newEmployee);
        
        Task<Employee> UpdateEmployeeAsync(Employee employeeToUpdate);
        
        void DeleteEmployee(Employee employeeToDelete);

        Task<bool> SaveChangesAsync();
        
        Task<bool> EmployeeIfExistsAsync(Guid employeeId);
    }
}
