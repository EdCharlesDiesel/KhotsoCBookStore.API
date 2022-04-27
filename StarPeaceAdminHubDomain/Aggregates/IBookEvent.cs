using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum BookEventType {Deleted}
    
    public interface IBookEvent: IEntity<long>
    {
        BookEventType Type { get; }
        int BookId { get; }
        string Title {get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
