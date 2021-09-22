using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
          public string EmailAddress { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public int UserTypeId { get; set; }
    }
}