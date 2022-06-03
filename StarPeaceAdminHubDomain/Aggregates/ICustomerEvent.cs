using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum CustomerEventType {Deleted}
    public interface ICustomerEvent: IEntity<long>
    {
        CustomerEventType Type { get; }
        int CustomerId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
