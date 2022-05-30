using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
       

      
        public string EmployeeNumber { get; set; }
         public string FirstName { get; set; }
          public string LastName { get; set; }

           public string Occupation { get; set; }
           public DateTime DateOfBirth { get; set; }
           public int IdNumber { get; set; }
           public string HighestQualification { get; set; }
        
        public DateTime DateOfStartEmployment { get; set; }
        
        public DateTime DateOfEndEmployment { get; set; }
    }
}
