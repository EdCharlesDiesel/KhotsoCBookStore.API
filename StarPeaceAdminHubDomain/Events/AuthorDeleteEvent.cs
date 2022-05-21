using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Events
{
    public class AuthorDeleteEvent: IEventNotification
    {
        public AuthorDeleteEvent(int id, long oldVersion)
        {
            AuthorId = id;
            OldVersion = oldVersion;
        }
        public int AuthorId { get; private set; }
        
        public long OldVersion { get; private set; }
        
    }
}
