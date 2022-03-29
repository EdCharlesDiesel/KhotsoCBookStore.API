using KhotsoCBookStore.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace KhotsoCBookStore.API.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(Employee newEmployee);

        
        Task<IEnumerable<Employee>> GetAllEmployeesAync();

        
        Task<Employee> GetEmployeeByIdAsync(Guid employeeId);

        
        Task UpdateEmployeeAsync(Employee oldEmployeeToUpdate);

        
        void DeleteEmployee(Employee employeeToDelete);


        Task<bool> SaveChangesAsync();
        
        
        Task<bool> EmployeeIfExistsAsync(Guid employeeId);
    }
}
