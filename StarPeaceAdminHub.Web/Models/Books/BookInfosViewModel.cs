using StarPeaceAdminHubDomain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Models.Books
{
    public class BookInfosViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }

        public int BookId { get; set; }
        public override string ToString()
        {
            return string.Format("{0}. bookId, BookName: {1}",
                BookId, BookName);
        }
    }
}
