using System.Collections.Generic;
using KhotsoCBookStore.API.Models.Employees;

namespace KhotsoCBookStore.API.Models
{
    public class EmployeesListViewModel
    {
        public IEnumerable<EmployeeInfosViewModel> Employees { get; set; }
    }
}
