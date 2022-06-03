using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IEmployeesListQuery: IQuery
    {
        Task<IEnumerable<EmployeeInfosViewModel>> GetAllEmployees();
        Task<EmployeeInfosViewModel> GetEmployeeById(int authorId);
    }
}
