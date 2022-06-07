using System;

namespace KhotsoCBookStore.API.Models
{
    public class CustomerInfosViewModel
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int IdNumber { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string MobileNumber { get; set; }

        
        public override string ToString()
        {
            return string.Format("Customer {0} {1} has an Id of : {3}",
                FirstName, LastName, CustomerId);
        }
    }
}
