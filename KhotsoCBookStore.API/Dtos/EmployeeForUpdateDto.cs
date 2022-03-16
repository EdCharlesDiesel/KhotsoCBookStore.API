using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class EmployeeForUpdateDto
    {
         public Guid EmployeeId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string EmployeeNumber { get; set; }
    }
}
