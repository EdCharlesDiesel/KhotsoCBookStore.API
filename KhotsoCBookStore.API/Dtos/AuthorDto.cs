using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }        
       
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
