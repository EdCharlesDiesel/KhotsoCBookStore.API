using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage="Please enter an email")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage ="Please enter a username")]
        public string Username { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        public ICollection<ProductSubscription>  ProductSubscriptions{ get; set; } = new List<ProductSubscription>();
    }
}