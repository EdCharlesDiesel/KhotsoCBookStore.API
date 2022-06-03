using System;

namespace KhotsoCBookStore.API.Models
{
    public class BookInfosViewModel
    {
        public int Id { get; set; }


        public string Title { get; set ;}
        public string ISBN { get; set; }

        public string Description { get ; set; }

        public DateTime PublishingDate { get ;set; }

        public decimal Cost { get;set ; }

        public decimal RetailPrice { get ;set ; }

        public string CoverFileName { get ; set; }
        
        
        public override string ToString()
        {
            return string.Format("Book {0} {1} Book Id {2}, Has an Id of  price: {3}",
                Title, Description, Id);
        }
    }
}
