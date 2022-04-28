using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using StarPeaceAdminHubDomain.Events;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    public class Category: Entity<int>, ICategory
    {       

        [MaxLength(128), Required(ErrorMessage = "Category Name is required")]        
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
