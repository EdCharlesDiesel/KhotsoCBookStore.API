using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartItemForUpdateDto
    {
        public Guid ProductId;

        public Guid BookId { get; set; }

        public int Quantity { get; set; }
    }
}