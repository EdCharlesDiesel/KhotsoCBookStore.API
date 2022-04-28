using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class BookTitleEvent: Entity<long>, IBookTitleEvent
    {
        public BookTitleEventType Type { get; set; }
        
        public int BookTitleId { get; set; } 
        
        public long? OldVersion { get; set; }
        
        public long? NewVersion { get; set; }

    }
}
