using System;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB
{
    public class Employee : Entity<int>, IEmployee
    {
        public void FullUpdate(IEmployeeFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
               // BookId = o.BookId;
            }
        
            FirstName = o.FirstName;
            LastName = o.LastName;
            IdNumber = o.IdNumber;
            StartOfEmployment = o.StartOfEmployment;
            EndOfEmployement = o.EndOfEmployement;
        }

        [MaxLength(150), Required(ErrorMessage = "You should provide a first name.")]
        public string FirstName { get; set; }


        [MaxLength(150), Required(ErrorMessage = "You should provide a last name.")]
        public string LastName { get; set; }
        
        [MaxLength(13), Required(ErrorMessage = "You should provide a Id Number.")]
        public int IdNumber { get; set; }

        public DateTime StartOfEmployment { get;set;}
        
        public DateTime? EndOfEmployement { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion { get; set; }

 
    }
}
