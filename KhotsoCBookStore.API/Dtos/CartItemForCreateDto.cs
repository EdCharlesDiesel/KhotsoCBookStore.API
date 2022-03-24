using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartItemForCreateDto
    {
        public Guid CartId { get; set; } 
        private Guid productId;
   

       
        public int Quantity { get; set; } 
    }
}