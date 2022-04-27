using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Models.Books
{
    public class BooksListViewModel
    {
        public IEnumerable<BookInfosViewModel> Items { get; set; }
    }
}
