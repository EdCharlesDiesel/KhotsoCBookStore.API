using System.Collections.Generic;

namespace KhotsoCBookStore.API.Models
{
    public class CustomersListViewModel
    {
        public IEnumerable<CustomerInfosViewModel> Customers { get; set; }
    }
}
