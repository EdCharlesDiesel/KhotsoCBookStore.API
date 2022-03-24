using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartForCreateDto
    {                
        public Guid CartItemId { get; set; } 

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
