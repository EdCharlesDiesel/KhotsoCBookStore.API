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
        
        public int BookId { get; set; }
        
        public string Title { get; set; } 
        
        public long? OldVersion { get; set; }
        
        public long? NewVersion { get; set; }
    }
}
