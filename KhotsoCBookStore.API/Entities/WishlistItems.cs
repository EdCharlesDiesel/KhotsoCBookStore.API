﻿using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Entities
{
    public partial class WishlistItems
    {
        public int WishlistItemId { get; set; }
        public string WishlistId { get; set; }
        public int ProductId { get; set; }
    }
}
