using System.Collections.Generic;

namespace KhotsoCBookStore.API.Models
{
    public class OrdersListViewModel
    {
        public IEnumerable<OrderInfosViewModel> AllOrders { get; set; }
    }
}
