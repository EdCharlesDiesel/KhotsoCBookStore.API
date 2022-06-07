using System;

namespace KhotsoCBookStore.API.Models
{
    public class BookInfosViewModel
    {

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
        
        
        public override string ToString()
        {
            return string.Format("Book {0} {1}  has an Id of : {3}",
                Title, Description, BookId);
        }
    }
}
