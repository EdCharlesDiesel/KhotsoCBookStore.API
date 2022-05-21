using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartItemForCreateDto
    {
        public Guid CartId { get; set; }
        
        public Guid ProductId;

        public Guid BookId { get; set; }

        public int Quantity { get; set; }
    }
}