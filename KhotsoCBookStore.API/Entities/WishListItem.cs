using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    public class WishListItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WishListItemId { get; set; }  =Guid.NewGuid();

        [ForeignKey("WishListId")]
        public Guid WishListId { get; set; }
        public WishList WishList { get; set; }

        public Guid ProductId { get; set; }
    }
}
