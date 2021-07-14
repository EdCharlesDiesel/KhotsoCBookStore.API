using KhotsoCBookStore.API.Models;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderService
    {
        void CreateOrder(int userId, OrdersDto orderDetails);
        List<OrdersDto> GetOrderList(int userId);
    }
}
