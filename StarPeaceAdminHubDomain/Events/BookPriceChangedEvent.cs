using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.Events
{
    public class BookPriceChangedEvent: IEventNotification
    {
        public BookPriceChangedEvent(int id, decimal price, long oldVersion, long newVersion)
        {
            BookId = id;
            NewPrice = price;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }
        public int BookId { get; private set; }
        public decimal NewPrice { get; private set; }
        public long OldVersion { get; private set; }
        public long NewVersion { get; private set; }
    }
}
