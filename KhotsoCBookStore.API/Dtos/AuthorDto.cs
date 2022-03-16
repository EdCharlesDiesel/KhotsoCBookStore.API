using System;

namespace KhotsoCBookStore.API.Entities
{
    public class AuthorDto
    {
        public Guid AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
