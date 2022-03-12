using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Models
{
    public class OrdersModel
    {
        public string OrderId { get; set; }

        public List<CartItemModel> OrderDetails { get; set; }

        public decimal CartTotal { get; set; }
        
        public DateTime OrderDate { get; set; }
    }
}
