using System;
using KhotsoCBookStore.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Authentication
{
    public  class UserMaster:Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        [ForeignKey("UserTypeId")]
        public Guid UserTypeId { get; set; }
        
        public UserType UserType { get; set; }
    }
}
