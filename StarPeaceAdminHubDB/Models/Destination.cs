using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class Destination: Entity<int>, IDestination
    {
        
        [MaxLength(128), Required]
        public string Name { get; set; }
        [MaxLength(128), Required]
        public string Country { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }

        public void FullUpdate(IDestination o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            Name = o.Name;
            Country = o.Country;
            Description = o.Description;
        }
    }
}
