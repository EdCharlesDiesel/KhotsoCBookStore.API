using System;

namespace KhotsoCBookStore.API.DTOs
{
    public record AuthorsListDTO
    {
        public int Id { get; set; }    

        public string FirstName { get; set; }

        public string LastName { get;set;}

        public decimal BookStartPrice { get; set; }

        public DateTime? StartPublishingDate { get;set;}
        
        public DateTime? EndPublishingDate { get; set; }

        int BookId { get; } 
    }
}
