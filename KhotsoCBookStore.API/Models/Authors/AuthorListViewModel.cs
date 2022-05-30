using System.Collections.Generic;

namespace KhotsoCBookStore.API.Models.Authors
{
    public class AuthorsListViewModel
    {
        public IEnumerable<AuthorInfosViewModel> Items { get; set; }
    }
}
