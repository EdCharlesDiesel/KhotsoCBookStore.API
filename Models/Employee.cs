using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; }
        
        [Required]
        public string EmployeeNumber { get; set; }
        
        [Required]
        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
    }
}
