using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum BookEventType {Deleted}
    
    public interface IBookEvent: IEntity<long>
    {
        BookEventType Type { get; }
        int BookId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
