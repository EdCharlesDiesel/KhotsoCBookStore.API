using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class Customer : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; } 

        [Required]
        public string EmailAddress { get; set; }
        
        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        public ICollection<ProductSubscription>  ProductSubscriptions{ get; set; } = new List<ProductSubscription>();
    }
}
