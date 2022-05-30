using System;

namespace KhotsoCBookStore.API.DTOs
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; } 
        
        public Guid CustomerId { get; set; }
        
        public Guid BookId { get; set; }

        public DateTime OrderDate { get; set; }
        
        public DateTime ShipDate { get; set; }
        
        public string ShipAddress { get; set; }

        public decimal CartTotal { get; set; }

    }
}
