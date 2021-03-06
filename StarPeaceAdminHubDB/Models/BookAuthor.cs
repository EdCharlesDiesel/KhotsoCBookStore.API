using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class BookAuthor: AuditableEntity
    {
        [ForeignKey("BookId")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
