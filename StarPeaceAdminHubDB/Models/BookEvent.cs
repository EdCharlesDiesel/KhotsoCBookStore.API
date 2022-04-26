using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDB.Models
{
    public class BookEvent: Entity<long>, IBookEvent
    {
        public BookEventType Type { get; set; }
        
        public Guid BookId { get; set; }
        
        public decimal NewPrice { get; set; }


        public decimal NewCost { get; set; }    

        public decimal NewRetailPrice { get; set; }
        
        public long? OldVersion { get; set; }
        
        public long? NewVersion { get; set; }

    }
}
