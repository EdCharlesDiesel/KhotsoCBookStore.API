using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class EmployeeDto
    {

        public Guid EmployeeId { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage ="Please enter an Employee begining with: EMP:")]
        public string  FirstName { get; set; }


        [Required(ErrorMessage ="Please enter an Employee begining with: EMP:")]
        public string  LastName { get; set; }


        [Required(ErrorMessage ="Please enter an Employee begining with: EMP:")]
        public string EmployeeNumber { get; set; }

        
        [Required(ErrorMessage="Please provide first date of employment")]
        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
    }
}
