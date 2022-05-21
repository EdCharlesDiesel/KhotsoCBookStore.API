using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CustomerForCreateDto
    {
         //public Guid CustomerId { get; set; } 
        [Required(ErrorMessage ="Please enter first name")]
        public string FirstName { get; set; }        
        
        [Required(ErrorMessage ="Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter date of birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Required(ErrorMessage ="Please enter username")]        
        public string Username { get; set; }
        
        [Required(ErrorMessage ="Please enter email address")]
        [EmailAddress(ErrorMessage ="Please enter valid email addess")]
        public string EmailAddress { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        //  public ICollection<Order> Orders { get; set; } = new List<Order>();

        // public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        //  public ICollection<ProductSubscription>  ProductSubscriptions{ get; set; } = new List<ProductSubscription>();
    }    
}