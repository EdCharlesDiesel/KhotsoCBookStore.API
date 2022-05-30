using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class Customer 
    // IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

       
        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Username { get; set; } 

        [EmailAddress]
        public string EmailAddress { get; set; }  
             
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        public ICollection<MemberOrder> Orders { get; set; }

    }
}
