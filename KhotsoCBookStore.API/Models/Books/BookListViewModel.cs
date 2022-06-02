using System.Collections.Generic;

namespace KhotsoCBookStore.API.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<BookInfosViewModel> Books { get; set; }
    }
}
