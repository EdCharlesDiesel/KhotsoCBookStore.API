using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class MemberOrderEvent: Entity<long>, IMemberOrderEvent
    {
        public MemberOrderEventType Type { get; set; }
        public int MemberOrderId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
