using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class WishListForUpdateDto
    {        
        public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();   
     
    }
}
