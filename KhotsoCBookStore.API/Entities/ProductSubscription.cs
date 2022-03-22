using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Entities
{
    public class ProductSubscription
    {
        public string ProductSubscriptionId { get; set; }        

        public int UserId { get; set; }               
        
        public DateTime DateCreated { get; set; }
    }
}
