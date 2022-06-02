using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum MemberOrderEventType {Deleted, CostChanged}
    public interface IMemberOrderEvent: IEntity<long>
    {
        MemberOrderEventType Type { get; }
        int MemberOrderId { get; }
        decimal NewBookStartPrice { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
