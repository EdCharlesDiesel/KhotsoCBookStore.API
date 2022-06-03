using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum AuthorEventType {Deleted, CostChanged}
    public interface IAuthorEvent: IEntity<long>
    {
        AuthorEventType Type { get; }
        int AuthorId { get; }
        decimal NewBookStartPrice { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
