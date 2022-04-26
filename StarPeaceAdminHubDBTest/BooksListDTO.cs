using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDBTest
{
    public class BooksListDTO
    {
        public Guid BookId { get;  set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public DateTime? StartValidityDate { get; set; }
        public DateTime? EndValidityDate { get; set; }
        public string DestinationName { get; set; }
        public Guid DestinationId { get; set; }
        public override string ToString()
        {
            return string.Format("{0}. {1} days in {2}, price: {3}", 
                Title, DurationInDays, DestinationName, Price);
        }
    }
}
