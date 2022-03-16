using System;

namespace KhotsoCBookStore.API.Dto
{
    public class BookDto
    {
        public Guid BookId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }
        
        public string Author { get; set; }
        
        public string Category { get; set; }
        
        public decimal PurchasePrice { get; set; }        
        
        public string CoverFileName { get; set; }
    }
}
