using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Entities
{
    public partial class BookSubscriptionItems
    {
        
        public int BookSubscriptionItemId { get; set; }
        public string BookSubscriptionId { get; set; }
        public int ProductId { get; set; }
    }
}
