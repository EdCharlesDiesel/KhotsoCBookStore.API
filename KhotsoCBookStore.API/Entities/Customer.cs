using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class Customer : AuditableEntity
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

        // public ICollection<Order> Orders { get; set; } = new List<Order>();

        // public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        // public ICollection<ProductSubscription>  ProductSubscriptions{ get; set; } = new List<ProductSubscription>();
    }
}
