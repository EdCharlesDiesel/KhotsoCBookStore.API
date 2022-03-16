using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class EmployeeForCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string EmployeeNumber { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
    }
}
