using System;
using System.ComponentModel.DataAnnotations;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models.Books
{
    public class CustomerFullEditViewModel: ICustomerFullEditDTO
    {
        public CustomerFullEditViewModel() { }
        public CustomerFullEditViewModel(ICustomer o)
        {
             FirstName = o.FirstName;
            LastName = o.LastName;
            DateOfBirth = o.DateOfBirth;
            ContactTitle = o.ContactTitle;
            Address = o.Address;
            City = o.City;
            Region = o.Region;
            PostalCode = o.PostalCode;
            Country = o.Country;
            Phone = o.Phone;
            MobileNumber = o.MobileNumber;
        }
        
        public int CustomerId { get; set; }

        [StringLength(150, MinimumLength = 5), Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(150, MinimumLength = 5), Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int IdNumber { get; set; }
        public string SocialMediaFaceBook { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string MobileNumber { get; set; }
    }
}
