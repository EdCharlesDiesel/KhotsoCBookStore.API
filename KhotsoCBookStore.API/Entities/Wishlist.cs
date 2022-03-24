using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    [Table("WishLists")]
    public class WishList : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WishListId { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        
        public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();
    }
}
