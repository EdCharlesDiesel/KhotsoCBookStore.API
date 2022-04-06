using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
  public class RegisterModel
  {
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

        //   [Required]
        // public DateTime DateOfBirth { get; set; }
    
    public string EmailAddress { get; set; }

   public Guid UserTypeId { get; set; }
  }
}