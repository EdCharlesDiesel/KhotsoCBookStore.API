using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Dtos;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        int AddEmployee(Employee book);
        int UpdateEmployee(Employee book);
        Employee GetEmployeeData(int bookId);
        string DeleteEmployee(int bookId);
    }
}
