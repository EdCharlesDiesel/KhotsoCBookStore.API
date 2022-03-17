using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KhotsoCBookStore.API.Authentication;

namespace KhotsoCBookStore.API.Entities
{
    public class Customer : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }

        // [Required(ErrorMessage ="Please enter valid email address")]
        // [EmailAddress]
        public string EmailAddress { get; set; }
        
        //[Required(ErrorMessage ="Please enter a username")]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        [ForeignKey("UserTypeId")]
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        public ICollection<ProductSubscription>  ProductSubscriptions{ get; set; } = new List<ProductSubscription>();
    }
}
