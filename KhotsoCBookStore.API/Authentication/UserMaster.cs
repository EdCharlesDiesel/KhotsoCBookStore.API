using System;
using KhotsoCBookStore.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Authentication
{
    public class UserMaster 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

         [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        //[Required]
        public DateTime DateOfBirth { get; set; }

       // [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [ForeignKey(nameof(UserType))]
        public Guid UserTypeId { get; set; }

        //public ICollection<UserType> UserTypes { get; set; } = new List<UserType>();
    }
}
