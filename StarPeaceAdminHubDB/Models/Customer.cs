using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Customers")]
    public class Customer 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; } 

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Username { get; set; } 

        [Required]
        public string EmailAddress { get; set; }  
             
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
