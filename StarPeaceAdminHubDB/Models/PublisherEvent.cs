using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class PublisherEvent: Entity<long>, IPublisherEvent
    {
        public PublisherEventType Type { get; set; }
        public int PublisherId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
