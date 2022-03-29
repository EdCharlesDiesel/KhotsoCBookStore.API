using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Guid customerId);

        Task AddBookToOrderAsync(Guid customerId, Guid bookId);

        Task<string> GetOrderIdAsync(Guid customerId);

        Task<IEnumerable<Order>> GetOrdersAsync(Guid customerId);        

        Task UpdateOrderItems(Guid customerId);  

        Task<int> GetOrderItemsCount(Guid customerId);      
        
        Task DeleteOrderItem(Guid customerId, Guid bookId);       
       
        Task<int> ClearOrder(Guid customerId);

        Task<bool> SaveChangesAsync();
    }
}
