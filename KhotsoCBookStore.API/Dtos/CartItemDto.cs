using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartItemDto
    {
        public Guid CartItemId { get; set; }  =Guid.NewGuid();

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}