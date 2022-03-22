using System;

namespace KhotsoCBookStore.API.Dto
{
    public class BookForUpdateDto
    {
        public string Title { get; set; }

        public DateTime PublishingDate { get; set; }
        
        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }     
        
        public string CoverFileName { get; set; }
    }
}
