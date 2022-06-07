using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IOrder : IEntity<int>
    {
        void FullUpdate(IOrderFullEditDTO o);

        DateTime? OrderDate { get; set; }

        DateTime? RequiredDate { get; set; }

        DateTime? ShippedDate { get; set; }

        int? ShipVia { get; set; }

        decimal? Freight { get; set; }

        string ShipName { get; set; }

        string ShipAddress { get; set; }

        string ShipCity { get; set; }

        string ShipRegion { get; set; }

        string ShipPostalCode { get; set; }

        string ShipCountry { get; set; }

        // public Customers Customer { get; set; }
        // public Employee Employee { get; set; }
        // public IEnumerable<OrderDetails> OrderDetails { get; set; }     
    }    
}
