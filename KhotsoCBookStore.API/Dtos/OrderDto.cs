using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; } 
        
        public Guid CustomerId { get; set; }
        
        public Guid BookId { get; set; }

        public DateTime OrderDate { get; set; }
        
        public DateTime ShipDate { get; set; }
        
        public string ShipAddress { get; set; }

        public decimal CartTotal { get; set; }

        public List<CartItemDto> OrderItems { get; set; }
    }
}
