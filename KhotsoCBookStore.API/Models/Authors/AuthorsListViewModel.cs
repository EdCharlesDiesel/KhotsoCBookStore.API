using System.Collections.Generic;
using KhotsoCBookStore.API.Models.Authors;

namespace KhotsoCBookStore.API.Models
{
    public class AuthorsListViewModel
    {
        public IEnumerable<AuthorInfosViewModel> AllAuthors { get; set; }
    }
}
