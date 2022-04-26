using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    [Table("WishLists")]
    public class WishList : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WishlistId { get; set; }

        public Guid CustomerId { get; set; }
        
        public Customer Customer { get; set; }

        public ICollection<WishListItem> WishListItems { get; set; }
    }
}
