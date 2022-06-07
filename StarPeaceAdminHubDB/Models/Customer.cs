using System;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace StarPeaceAdminHubDB
{
    public class Customer : Entity<int>, ICustomer
    {
        public void FullUpdate(ICustomerFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.CustomerId;
            }
          
            FirstName = o.FirstName;
            LastName = o.LastName;
            DateOfBirth = o.DateOfBirth;
            IdNumber = o.IdNumber;
            ContactTitle = o.ContactTitle;
            Address = o.Address;
            City = o.City;
            Region = o.Region;
            PostalCode = o.PostalCode;
            Country = o.Country;
            Phone = o.Phone;
            MobileNumber = o.MobileNumber;
           
        }

        [MaxLength(150), Required(ErrorMessage = "You should provide a first name.")]
        public string FirstName { get; set; }


        [MaxLength(150), Required(ErrorMessage = "You should provide a last name.")]
        public string LastName { get; set; }

        [MaxLength(13), Required(ErrorMessage = "You should provide the Id number.")]
        public int IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
       
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string MobileNumber { get; set; }
        [ConcurrencyCheck]
        public long EntityVersion { get; set; }

        // public int BookId { get; set; }
    }
}
