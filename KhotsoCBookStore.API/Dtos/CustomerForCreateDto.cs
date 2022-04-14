using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CustomerForCreateDto
    { 

        [Required(ErrorMessage ="Please provide first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please provide last name")]        
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please provide date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Please provide username")]
        public string Username { get; set; } 

        [Required(ErrorMessage ="Please email address")]
        [EmailAddress(ErrorMessage ="Please provide a valid email address")]
        public string EmailAddress { get; set; }  
      
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }
    }    
}