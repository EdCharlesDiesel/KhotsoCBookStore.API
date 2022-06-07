using System;

namespace KhotsoCBookStore.API.Models
{
    public class OrderInfosViewModel
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        
        
        public override string ToString()
        {
            return string.Format("Order Id {0} should be shipped to {1}",
                OrderId,ShipAddress);
        }
    }
}
