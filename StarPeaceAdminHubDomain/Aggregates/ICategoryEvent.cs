using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public enum CategoryEventType {Deleted, CategoryNameChanged}
    //public enum CategoryEventType {Deleted}
    
    public interface ICategoryEvent: IEntity<long>
    {
        CategoryEventType Type { get; }
        int CategoryId { get; }
        string CategoryName {get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
