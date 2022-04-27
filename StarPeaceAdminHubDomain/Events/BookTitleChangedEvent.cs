using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.Events
{
    public class BookTitleChangedEvent: IEventNotification
    {
        public BookTitleChangedEvent(int id, string title, long oldVersion, long newVersion)
        {
            CategoryId = id;
            Title = title;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }
        public int CategoryId { get; private set; }

        public string Title { get; private set; }
        
        public long OldVersion { get; private set; }
        
        public long NewVersion { get; private set; }

    }
}
