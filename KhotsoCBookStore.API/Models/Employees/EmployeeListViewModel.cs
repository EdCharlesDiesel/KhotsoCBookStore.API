using System.Collections.Generic;
using KhotsoCBookStore.API.Models;

namespace KhotsoCBookStore.API.Models
{
    public class EmployeesListViewModel
    {
        public IEnumerable<EmployeeInfosViewModel> AllEmployees { get; set; }
    }
}
