using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class EmployeeForUpdateDto
    {  
        public string  FirstName { get; set; }
        
        public string  LastName { get; set; }
     
        public string EmployeeNumber { get; set; }

        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
        
    }
}
