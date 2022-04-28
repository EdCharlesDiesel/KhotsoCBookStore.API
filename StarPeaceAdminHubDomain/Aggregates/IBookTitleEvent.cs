using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum BookTitleEventType {Deleted}
    
    public interface IBookTitleEvent: IEntity<long>
    {
        BookTitleEventType Type { get; }
        int BookTitleId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
