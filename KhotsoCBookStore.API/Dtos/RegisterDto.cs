using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public int UserTypeId { get; set; }
    }
}