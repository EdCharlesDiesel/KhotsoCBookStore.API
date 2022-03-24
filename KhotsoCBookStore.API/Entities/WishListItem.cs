using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    [Table("WishListItems")]
    public class WishListItem : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WishListItemId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(WishList))]
        public Guid WishListId { get; set; }

        public Guid ProductId { get; set; }
    }
}
