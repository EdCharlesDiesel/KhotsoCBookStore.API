using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceIdentityServer.Authentication
{
    public class UserType 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserTypeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string UserTypeName { get; set; }
    }
}
