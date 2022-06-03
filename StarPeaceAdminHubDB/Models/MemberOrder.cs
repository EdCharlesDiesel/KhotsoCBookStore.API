using System;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;

namespace StarPeaceAdminHubDB
{
    public class MemberOrder : Entity<int>, IMemberOrder
    {
        public void FullUpdate(IMemberOrderFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                BookId = o.BookId;
            }
            else
            {
                if (o.BookStartPrice != this.BookStartPrice)
                    this.AddDomainEvent(new MemberOrderBookStartPriceChangedEvent(
                            Id, o.BookStartPrice, EntityVersion, EntityVersion + 1));
            }
            FirstName = o.FirstName;
            LastName = o.LastName;
            StartPublishingDate = o.StartPublishingDate;
            EndPublishingDate = o.EndPublishingDate;
            BookStartPrice = o.BookStartPrice;
        }

        [MaxLength(150), Required(ErrorMessage = "You should provide a first name.")]
        public string FirstName { get; set; }


        [MaxLength(150), Required(ErrorMessage = "You should provide a last name.")]
        public string LastName { get; set; }

        public DateTime? StartPublishingDate { get; set; }

        public DateTime? EndPublishingDate { get; set; }

        public decimal BookStartPrice { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion { get; set; }

        public int BookId { get; set; }
    }
}
