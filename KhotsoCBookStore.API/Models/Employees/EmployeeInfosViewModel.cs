using System;

namespace KhotsoCBookStore.API.Models.Employees
{
    public class EmployeeInfosViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; }

        public decimal BookStartPrice { get; set; }
        
        public DateTime? StartPublishingDate { get; set; }

        public DateTime? EndPublishingDate { get; set; }
    
        public int BookId { get; set; }
        
        
        public override string ToString()
        {
            return string.Format("Employee {0} {1} Book Id {2}, Has an Id of  price: {3}",
                FirstName, LastName, BookId, Id);
        }
    }
}
