using System;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IBookFullEditDTO
    {
        int BookId { get; set; }

        string Title { get;set;  }

        string ISBN { get; set;}

        string Description {get;set;}
        
        DateTime PublishingDate { get; set; }
        
        decimal UnitCost { get;set;  }        
        
        string CoverFileName { get; set; }

        public int? SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; } 
    }
}
