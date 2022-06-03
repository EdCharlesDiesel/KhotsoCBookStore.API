using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum PublisherEventType {Deleted, CostChanged}
    public interface IPublisherEvent: IEntity<long>
    {
        PublisherEventType Type { get; }
        int PublisherId { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
