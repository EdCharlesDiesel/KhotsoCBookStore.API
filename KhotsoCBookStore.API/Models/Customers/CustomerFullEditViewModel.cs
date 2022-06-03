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
            Id = o.Id;
            FirstName = o.FirstName;
            LastName = o.LastName;
            DateOfBirth = o.DateOfBirth;
            IdNumber = o.IdNumber;
            SocialMediaFaceBook = o.SocialMediaFaceBook;
        }
        
        public int Id { get; set; }

        [StringLength(150, MinimumLength = 5), Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(150, MinimumLength = 5), Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int IdNumber { get; set; }
        public string SocialMediaFaceBook { get; set; }
    }
}
