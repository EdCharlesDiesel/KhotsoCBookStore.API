using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class OrderEvent: Entity<long>, IOrderEvent
    {
        public OrderEventType Type { get; set; }
        public int OrderId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
