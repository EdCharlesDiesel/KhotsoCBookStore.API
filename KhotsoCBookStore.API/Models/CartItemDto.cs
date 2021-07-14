using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Models
{
    public class CartItemDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
