using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
