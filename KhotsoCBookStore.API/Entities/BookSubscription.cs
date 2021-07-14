using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Entities
{
    public class BookSubscription
    {
        public string BookSubscriptionId { get; set; }        
        public int UserId { get; set; }               
        public DateTime DateCreated { get; set; }

    }
}
