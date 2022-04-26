using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDomain.Events
{
    public class CategoryCategoryNameChangedEvent: IEventNotification
    {
        public CategoryCategoryNameChangedEvent(Guid id, string CategoryName, long oldVersion, long newVersion)
        {
            CategoryId = id;
            //NewPrice = price;
            CategoryName = CategoryName;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }
        public Guid CategoryId { get; private set; }
        //public decimal NewPrice { get; private set; }
        public string CategoryName { get; private set; }
        
        public long OldVersion { get; private set; }
        public long NewVersion { get; private set; }
    }
}
