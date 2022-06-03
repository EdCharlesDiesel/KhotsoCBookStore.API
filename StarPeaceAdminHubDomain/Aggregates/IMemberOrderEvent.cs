using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum MemberOrderEventType {Deleted}
    public interface IMemberOrderEvent: IEntity<long>
    {
        MemberOrderEventType Type { get; }
        int MemberOrderId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
