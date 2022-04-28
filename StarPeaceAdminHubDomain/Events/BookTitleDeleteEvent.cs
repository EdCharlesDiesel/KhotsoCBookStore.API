using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.Events
{
    public class BookTitleDeleteEvent: IEventNotification
    {
        public BookTitleDeleteEvent(int id, long oldVersion)
        {
            BookTitleId = id;
            OldVersion = oldVersion;
        }
        
        public int BookTitleId { get; private set; }
        
        public long OldVersion { get; private set; }        

    }
}
