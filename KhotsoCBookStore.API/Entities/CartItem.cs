using System;


namespace KhotsoCBookStore.API.Entities
{
    public class CartItem: AuditableEntity
    {
        
        public Guid CartItemId { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
