using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Models
{
    public class CartItemModel
    {
        public Book Book { get; set; }

        public int Quantity { get; set; }
    }
}
