using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Entities
{
    public partial class WishListItem
    {
        public int WishListItemId { get; set; }

        public string WishListId { get; set; }
        
        public int ProductId { get; set; }
    }
}
