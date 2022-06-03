using System;

namespace KhotsoCBookStore.API.Models.Employees
{
    public class EmployeeInfosViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IdNumber { get; set; }
        
        public DateTime StartOfEmployment { get; set; }

        public DateTime? EndOfEmployement { get; set; }
        
        
        public override string ToString()
        {
            return string.Format("Employee {0} {1} Book Id {2}, Has an Id of  price: {3}",
                FirstName, LastName, Id);
        }
    }
}
