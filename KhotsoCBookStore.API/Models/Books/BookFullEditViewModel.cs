using System;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models.Books
{
    public class BookFullEditViewModel: IBookFullEditDTO
    {
        public BookFullEditViewModel(IBook o)
        {
            BookId = o.Id;
            Title = o.Title;
            ISBN = o.ISBN;
            PublishingDate = o.PublishingDate;
            UnitCost = o.UnitCost;
            SupplierId = o.SupplierId;
            UnitPrice = o.UnitPrice;
            UnitsInStock = o.UnitsInStock;
            UnitsOnOrder = o.UnitsOnOrder;
            ReorderLevel = o.ReorderLevel;
            Discontinued = o.Discontinued;
        }

        public int BookId { get ;set; }

        public string Title { get; set ;}

        public string ISBN { get; set; }

        public string Descripion { get ; set; }

        public DateTime PublishingDate { get ;set; }

        public decimal Cost { get;set ; }

        public decimal RetailPrice { get ;set ; }

        public string CoverFileName { get ; set; }

        public string Description { get; set; }

        public decimal UnitCost { get; set; }

        public int? SupplierId { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
