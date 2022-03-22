using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class Employee: Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; } = Guid.NewGuid();
        
        [Required]
        public string EmployeeNumber { get; set; }
        
        [Required]
        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
    }
}
