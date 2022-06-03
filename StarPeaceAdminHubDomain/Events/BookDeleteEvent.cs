using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Events
{
    public class BookDeleteEvent: IEventNotification
    {
        public BookDeleteEvent(int id, long oldVersion)
        {
            BookId = id;
            OldVersion = oldVersion;
        }
        
        public int BookId { get; private set; }
        
        public long OldVersion { get; private set; }          
    }
}
