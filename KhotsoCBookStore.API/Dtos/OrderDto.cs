using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Dtos
{
    public class OrderDto
    {
        public string OrderId { get; set; }
        //public List<CartItemDto> OrderItems { get; set; }
        public decimal CartTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
