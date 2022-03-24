using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Guid customerId, Order orderItems);
        
        Task<IEnumerable<Order>> GetOrderListAsync(Guid customerId);

        Task<bool> SaveChangesAsync();
        
        Task<Order> GetOrderForUserAsync(Guid customerId);
    }
}
