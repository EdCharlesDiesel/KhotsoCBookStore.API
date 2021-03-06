using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Dtos
{
    public class OrderForUpdateDto
    {
        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }
        
        public DateTime ShipDate { get; set; }
        
        public string ShipAddress { get; set; }

        public decimal CartTotal { get; set; }

    }
}
