using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum CustomerEventType {Deleted, CostChanged}
    public interface ICustomerEvent: IEntity<long>
    {
        CustomerEventType Type { get; }
        int CustomerId { get; }
        decimal NewBookStartPrice { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
