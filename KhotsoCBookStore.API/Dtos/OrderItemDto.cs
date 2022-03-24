using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Dtos
{
   public class OrderItemDto
    {
        public Guid OrderItemId { get; set; }

        public Guid OrderId { get; set; }
        
        public Guid BookId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
    }
}
