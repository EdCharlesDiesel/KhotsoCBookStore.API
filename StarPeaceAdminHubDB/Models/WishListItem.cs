using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarPeaceAdminHubDB.Models
{
    [Table("WishListItems")]
    public class WishListItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WishListItemId { get; set; }

        public Guid WishListId { get; set; }
        
        public WishList WishList { get; set; }

        public Guid ProductId { get; set; }
    }
}
