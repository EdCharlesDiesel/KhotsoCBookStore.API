using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class EmployeeDto
    {

        public Guid EmployeeId { get; set; }

        public string  FirstName { get; set; }

        public string  LastName { get; set; }

        public string EmployeeNumber { get; set; }

        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
    }
}
