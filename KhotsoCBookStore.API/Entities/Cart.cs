using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KhotsoCBookStore.API.Authentication;

namespace KhotsoCBookStore.API.Entities
{
    public class Cart: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartId { get; set; }
        
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserMaster  UserMaster { get; set; }
        
    }
}
