using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CustomerForCreateDto
    {

        [Required(ErrorMessage ="Please enter email address")]
        [EmailAddress(ErrorMessage ="Please enter valid email addess")]
        public string EmailAddress { get; set; }

        
        [Required(ErrorMessage ="Please enter  username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter  password")]
        public string Password { get; set; }

        
        [Required(ErrorMessage ="Please enter  first name")]
        public string Firstname { get; set; }
        
        
        [Required(ErrorMessage ="Please enter last name")]
        public string Lastname { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }

        public UserType UserType { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<WishList> WishLists { get; set; } = new List<WishList>();

        public ICollection<ProductSubscription>  ProductSubscriptions{ get; set; } = new List<ProductSubscription>();
    }
    
}