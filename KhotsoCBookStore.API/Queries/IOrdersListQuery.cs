using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public interface IOrdersListQuery: IQuery
    {
        Task<IEnumerable<OrderInfosViewModel>> GetAllOrders();
        Task<OrderInfosViewModel> GetOrderById(int orderId);
        
    }
}
