using System;

namespace KhotsoCBookStore.API.DTOs
{
    public class CustomerDTO
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