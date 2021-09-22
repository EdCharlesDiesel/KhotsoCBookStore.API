using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Entities
{
    public partial class Wishlist
    {
        public string WishlistId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
