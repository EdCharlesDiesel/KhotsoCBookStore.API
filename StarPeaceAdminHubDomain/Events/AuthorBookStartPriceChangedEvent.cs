using DDD.DomainLayer;

namespace StarPeaceAdminHubDomain.Events
{
    public class AuthorBookStartPriceChangedEvent: IEventNotification
    {
        public AuthorBookStartPriceChangedEvent(int id, decimal bookStartPrice, long oldVersion, long newVersion)
        {
            AuthorId = id;
            NewBookStartPrice = bookStartPrice;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }
        public int AuthorId { get; private set; }
        public decimal NewBookStartPrice { get; private set; }
        public long OldVersion { get; private set; }
        public long NewVersion { get; private set; }
    }
}
