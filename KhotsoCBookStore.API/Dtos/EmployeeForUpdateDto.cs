using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class EmployeeForUpdateDto
    {  
        [Required(ErrorMessage ="Please enter first name")]
        public string  FirstName { get; set; }


        [Required(ErrorMessage ="Please enter last name")]
        public string  LastName { get; set; }


        [Required(ErrorMessage ="Please enter  employee begining with: EMP:")]
        public string EmployeeNumber { get; set; }

        
        [Required(ErrorMessage ="Please enter date of birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Required(ErrorMessage ="Please enter date of birth")]
        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
        
    }
}
