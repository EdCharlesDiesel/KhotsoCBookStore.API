using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class BookDto
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public DateTime PublishingDate { get; set; }
        
        public Guid PublisherId { get; set; }
        
        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }
    }
}
