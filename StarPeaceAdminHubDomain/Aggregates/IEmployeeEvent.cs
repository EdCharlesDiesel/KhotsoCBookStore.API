using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum EmployeeEventType {Deleted}
    public interface IEmployeeEvent: IEntity<long>
    {
        EmployeeEventType Type { get; }
        int EmployeeId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
