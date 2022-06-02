using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum EmployeeEventType {Deleted, CostChanged}
    public interface IEmployeeEvent: IEntity<long>
    {
        EmployeeEventType Type { get; }
        int EmployeeId { get; }
        decimal NewBookStartPrice { get; }
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
