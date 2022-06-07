using System;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models
{
    public class OrderFullEditViewModel: IOrderFullEditDTO
    {
        public OrderFullEditViewModel() { }
        public OrderFullEditViewModel(IOrder o)
        {
            OrderId = o.Id;
            OrderDate = o.OrderDate;
            RequiredDate = o.RequiredDate;
            ShippedDate = o.ShippedDate;
            ShipVia = o.ShipVia;
            Freight = o.Freight;
            ShipName = o.ShipName;
            ShipAddress = o.ShipAddress;
            ShipCity = o.ShipCity;
            ShipRegion = o.ShipRegion;
            ShipPostalCode = o.ShipPostalCode;
            ShipCountry = o.ShipCountry; 
        }
        
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
    }
}
