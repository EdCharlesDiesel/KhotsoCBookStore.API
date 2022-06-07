using System.Collections.Generic;

namespace KhotsoCBookStore.API.Models.Publishers
{
    public class PublishersListViewModel
    {
        public IEnumerable<PublisherInfosViewModel> AllPublishers { get; set; }
    }
}
