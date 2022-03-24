using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KhotsoCBookStore.API.Entities
{
    public class BookAuthor: AuditableEntity
    {
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
