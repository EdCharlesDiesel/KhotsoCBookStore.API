using KhotsoCBookStore.API.Dtos;
using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderService
    {
        void CreateOrder(Guid userId, OrdersDto orderDetails);
        List<OrdersDto> GetOrderList(Guid userId);
    }
}
