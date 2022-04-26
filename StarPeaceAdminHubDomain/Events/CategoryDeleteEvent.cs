using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.Events
{
    public class CategoryDeleteEvent: IEventNotification
    {
        public CategoryDeleteEvent(Guid id, long oldVersion)
        {
            CategoryId = id;
            OldVersion = oldVersion;
        }
        public Guid CategoryId { get; private set; }
        public long OldVersion { get; private set; }
        
    }
}
