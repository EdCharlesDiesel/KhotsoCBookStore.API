
using KhotsoCBookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Queries
{
    public class OrdersListQuery : IOrdersListQuery
    {
        private readonly MainDbContext ctx;
        public OrdersListQuery(MainDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<IEnumerable<OrderInfosViewModel>> GetAllOrders()
        {
            return await ctx.Orders.Select(o => new OrderInfosViewModel
            {
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                ShipVia = o.ShipVia,
                Freight = o.Freight,
                ShipName = o.ShipName,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry,
            }).ToListAsync();
        }


        public async Task<OrderInfosViewModel> GetOrderById(int authorId)
        {
            return await ctx.Orders.Select(o => new OrderInfosViewModel
            {
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                ShipVia = o.ShipVia,
                Freight = o.Freight,
                ShipName = o.ShipName,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry
            }).FirstOrDefaultAsync();
        }

    }
}
