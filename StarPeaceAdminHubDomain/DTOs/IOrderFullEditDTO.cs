using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IOrderFullEditDTO
    {
        int OrderId { get; set; }

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
    }
}
