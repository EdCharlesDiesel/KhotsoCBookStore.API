
using System;

namespace KhotsoCBookStore.API.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; }

        public string FirstName { get; set; }

        public string LastName { get;set;}

        public decimal BookStartPrice { get; set; }

        public DateTime? StartPublishingDate { get;}
        
        public DateTime? EndPublishingDate { get;  }

    }
}