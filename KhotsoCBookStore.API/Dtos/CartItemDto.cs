using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartItemDto
    {
        private Guid productId;
        public CartItemDto()
        {
            ProductId = BookId;
        }
        public Guid CartItemId { get; set; }

        public Guid ProductId
        {
            get { return productId; }
            set { productId = BookId; }
        }

        public Guid BookId { get; set; }

        public int Quantity { get; set; } 
    }
}