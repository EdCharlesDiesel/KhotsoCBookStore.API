using System;
using KhotsoCBookStore.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Authentication
{
    public class UserType : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserTypeId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(150)]
        public string UserTypeName { get; set; }

        [ForeignKey("UserId")]
        public UserMaster UserMaster { get; set; }
        public Guid UserId { get; set; }
    }
}
