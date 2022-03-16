using KhotsoCBookStore.API.Dtos;
using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Services
{
    public interface IOrderService
    {
        void CreateOrder(Guid userId, OrderDto orderDetails);
        List<OrderDto> GetOrderList(Guid userId);
    }
}
