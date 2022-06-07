using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum OrderEventType {Deleted}
    public interface IOrderEvent: IEntity<long>
    {
        OrderEventType Type { get; }
        int OrderId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
