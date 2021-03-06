using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Username { get; set; } 
        
        public string EmailAddress { get; set; }  
      
        public string Address { get; set; }

        public string City { get; set; }
        
        public string Province { get; set; }

        public int Postal { get; set; }
    }
}