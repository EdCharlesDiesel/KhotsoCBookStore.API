using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Dtos
{
    public class CartForCreateDto
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
