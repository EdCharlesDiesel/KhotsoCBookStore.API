using KhotsoCBookStore.API.Models;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderService
    {
        void CreateOrder(int userId, OrdersModel orderDetails);
        List<OrdersModel> GetOrderList(int userId);
    }
}
