using System.Collections.Generic;

namespace KhotsoCBookStore.API.Models.Authors
{
    public class AuthorsListViewModel
    {
        public IEnumerable<AuthorInfosViewModel> Authors { get; set; }
    }
}
