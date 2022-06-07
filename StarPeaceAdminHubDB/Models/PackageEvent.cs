using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class PackageEvent: Entity<long>, IPackageEvent
    {
        public PackageEventType Type { get; set; }
        public int PackageId { get; set; }
        public decimal NewPrice { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
