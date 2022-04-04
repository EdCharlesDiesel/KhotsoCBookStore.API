using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class AuthorForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
