using System;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB
{
    public class Customer : Entity<int>, ICustomer
    {
        public void FullUpdate(ICustomerFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
               // BookId = o.BookId;
            }
          
            FirstName = o.FirstName;
            LastName = o.LastName;
            DateOfBirth = o.DateOfBirth;
            IdNumber = o.IdNumber;
            SocialMediaFaceBook = o.SocialMediaFaceBook;
        }

        [MaxLength(150), Required(ErrorMessage = "You should provide a first name.")]
        public string FirstName { get; set; }


        [MaxLength(150), Required(ErrorMessage = "You should provide a last name.")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        [MaxLength(13), Required(ErrorMessage = "You should provide the Id number.")]
        public int IdNumber { get; set; }

        public string SocialMediaFaceBook { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion { get; set; }

       // public int BookId { get; set; }
    }
}
