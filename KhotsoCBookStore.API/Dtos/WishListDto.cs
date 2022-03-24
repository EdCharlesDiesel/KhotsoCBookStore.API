using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class WishListDto
    {
        public Guid WishListId { get; set; } 

        public Guid CustomerId { get; set; }
        
        public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();     
    }
}
