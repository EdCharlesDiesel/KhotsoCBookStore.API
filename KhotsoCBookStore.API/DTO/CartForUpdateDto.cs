using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartForUpdateDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
