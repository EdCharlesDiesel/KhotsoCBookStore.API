using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class PublisherEvent: Entity<long>, IAuthorEvent
    {
        public AuthorEventType Type { get; set; }
        public int AuthorId { get; set; }
        public decimal NewBookStartPrice { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
