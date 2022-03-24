using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class AuthorForCreateDto
    {
         [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }
    }
}
