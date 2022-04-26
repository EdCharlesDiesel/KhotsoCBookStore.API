using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarPeaceAdminHubDB.Models
{
    public class Category: Entity<int>, ICategory
    {
        public void FullUpdate(ICategoryFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                BookId = o.BookId;
            }
            else
            {
                // if (o.Price != this.Price)
                //     this.AddDomainEvent(new CategoryPriceChangedEvent(
                //             Id, o.Price, EntityVersion, EntityVersion+1));
                if (o.CategoryName != this.CategoryName)
                     this.AddDomainEvent(new CategoryCategoryNameChangedEvent(
                             Id, o.CategoryName, EntityVersion, EntityVersion + 1));

            }

            CategoryName = o.CategoryName;
            // Description = o.Description;
            // Price = o.Price;
            // DurationInDays = o.DurationInDays;
            // StartValidityDate = o.StartValidityDate;
            // EndValidityDate = o.EndValidityDate;
        }

        [MaxLength(128), Required]        
        public string CategoryName { get; set; }
        
        public Book Book { get; set; }
        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }

        public int BookId { get; set; }  
                        
    }
}
