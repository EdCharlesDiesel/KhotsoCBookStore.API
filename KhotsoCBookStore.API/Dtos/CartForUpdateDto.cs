using System;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartForUpdateDto
    { 
        public Guid CartItemId { get; set; } 

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
