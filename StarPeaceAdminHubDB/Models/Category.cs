using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StarPeaceAdminHubDB.Models
{
    // 13. Some of them have an EntityVersion property that is decorated with
    // the [ConcurrencyCheck] attribute. It contains the entity version that is
    // needed for sending a property all entity changes to other applications. The
    // ConcurrencyCheck attribute is needed to prevent concurrency errors while
    // updating the entity version. This prevents suffering the performance penalty
    // implied by a transaction.

    // More specifically, when saving entity changes, if the value of a field marked with the
    // ConcurrencyCheck attribute is different from the one that was read when the entity
    // was loaded in memory, a concurrency exception is thrown to inform the calling
    // method that someone else modified this value after the entity was read, but before
    // we attempted to save its changes. This way, the calling method can repeat the whole
    // operation with the hope that, this time, no one will write the same entity in the
    // database during its execution.
    public class Category: Entity<int>, ICategory
    {
       

        [MaxLength(128), Required]        
        public string CategoryName { get; set; }
        
        public Book Book { get; set; }
        
        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }

        public int BookId { get; set; }  

        public void FullUpdate(ICategoryFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                BookId = o.BookId;
            }
            else
            {
                if (o.CategoryName != this.CategoryName)
                     this.AddDomainEvent(new CategoryCategoryNameChangedEvent(
                             Id, o.CategoryName, EntityVersion, EntityVersion + 1));

            }

            CategoryName = o.CategoryName;
        }
                        
    }
}
