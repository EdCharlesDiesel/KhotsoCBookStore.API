using System;
using System.ComponentModel.DataAnnotations;
using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace StarPeaceAdminHubDB
{
    public class Order : Entity<int>, IOrder
    {
        public void FullUpdate(IOrderFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.OrderId;
            }

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

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        [MaxLength(40)]
        public string ShipName { get; set; }

        [MaxLength(60)]
        public string ShipAddress { get; set; }

        [MaxLength(15)]
        public string ShipCity { get; set; }

        [MaxLength(15)]
        public string ShipRegion { get; set; }

        [MaxLength(10)]
        public string ShipPostalCode { get; set; }

        [MaxLength(15)]
        public string ShipCountry { get; set; }
        [ConcurrencyCheck]
        public long EntityVersion { get; set; }
    }
}
