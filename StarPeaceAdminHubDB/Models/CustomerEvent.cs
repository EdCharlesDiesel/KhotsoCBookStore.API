using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class CustomerEvent: Entity<long>, ICustomerEvent
    {
        public CustomerEventType Type { get; set; }
        public int CustomerId { get; set; }
        public decimal NewBookStartPrice { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
