using System;
using KhotsoCBookStore.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Authentication
{
    public class UserMaster : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public ICollection<UserType> UserTypes { get; set; } = new List<UserType>();
    }
}
