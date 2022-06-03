using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;

namespace StarPeaceAdminHubDB.Models
{
    public class EmployeeEvent: Entity<long>, IEmployeeEvent
    {
        public EmployeeEventType Type { get; set; }
        public int EmployeeId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
    }
}
