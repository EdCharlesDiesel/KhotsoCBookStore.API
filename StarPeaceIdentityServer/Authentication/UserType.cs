using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarPeace.IdentityServer.Authentication
{
    public class UserType : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserTypeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string UserTypeName { get; set; }
    }
}
