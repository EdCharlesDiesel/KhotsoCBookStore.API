using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.IRepositories
{

    // 12. When an aggregate sends all its changes to another application, it must have
    // a version property. The application that receives the changes uses this version
    // property to apply all changes in the right order. An explicit version number is
    // necessary because changes are sent asynchronously, so the order they are received
    // in may differ from the order they were sent in. For this purpose, events that are used
    // to publish changes outside of the application have both OldVersion (the version
    // before the change) and NewVersion (the version after the change) properties. Events
    // associated with delete events have no NewVersion since after being deleted, an entity
    // can't store any versions.
    public interface ICategoryEventRepository:IRepository<ICategoryEvent>
    {
        Task<IEnumerable<ICategoryEvent>> GetFirstN(int n);
        
        ICategoryEvent New(CategoryEventType type, int id, long oldVersion, long? newVersion= null, string categoryName = null);
    
    }
}
