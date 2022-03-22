using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhotsoCBookStore.API.Repositories
{
    public class OrderRepository : IOrderService
    {
        readonly KhotsoCBookStoreDbContext _dbContext;
        public OrderRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OrderDto> CreateOrderAsync(Guid customerId, Order orderDetails)
        {
            // try
            // {
            //     StringBuilder orderid = new StringBuilder();
            //     orderid.Append(CreateRandomNumber(3));
            //     orderid.Append('-');
            //     orderid.Append(CreateRandomNumber(6));

            //     CustomerOrders customerOrder = new CustomerOrders
            //     {
            //         OrderId = orderid.ToString(),
            //         UserId = userId,
            //         DateCreated = DateTime.Now.Date,
            //         CartTotal = orderDetails.CartTotal
            //     };
            //     _dbContext.CustomerOrders.Add(customerOrder);
            //     _dbContext.SaveChanges();

            //     foreach (CartItemModel order in orderDetails.OrderDetails)
            //     {
            //         CustomerOrderDetails productDetails = new CustomerOrderDetails
            //         {
            //             OrderId = orderid.ToString(),
            //             ProductId = order.Book.BookId,
            //             Quantity = order.Quantity,
            //             Price = order.Book.PurchasePrice
            //         };
            //         _dbContext.CustomerOrderDetails.Add(productDetails);
            //         _dbContext.SaveChanges();
            //     }
            // }
            // catch
            // {
            //     throw;
            // }
            
             return  new OrderDto();
        }

        public  Task<IEnumerable<Order>> GetOrderListAsync(Guid customerId)
        {
            // var customerOrders = new List<Order>();
            

            // // customerOrders = _dbContext.Orders.Where(x => x.CustomerId == customerId)
            // //     .Select(x => x.OrderId).ToList();

            // foreach (var item in customerOrders)
            // {
            //     var order = new Order
            //     {
            //         // OrderId = orderid,
            //         // CartTotal = _dbContext.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).CartTotal,
            //         // OrderDate = _dbContext.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).DateCreated
            //     };

            //     List<CustomerOrderDetails> orderDetail = _dbContext.CustomerOrderDetails.Where(x => x.OrderId == orderid).ToList();

            //     order.OrderDetails = new List<CartItemModel>();

            //     foreach (CustomerOrderDetails customerOrder in orderDetail)
            //     {
            //         CartItemModel item = new CartItemModel();

            //         Book book = new Book
            //         {
            //             BookId = customerOrder.ProductId,
            //             Name = _dbContext.Books.FirstOrDefault(x => x.BookId == customerOrder.ProductId && customerOrder.OrderId == orderid).Name,
            //             PurchasePrice = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && customerOrder.OrderId == orderid).Price
            //         };

            //         item.Book = book;
            //         item.Quantity = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && x.OrderId == orderid).Quantity;

            //         order.OrderDetails.Add(item);
            //     }
            //     userOrders.Add(order);
            // }
            // return userOrders.OrderByDescending(x => x.OrderDate).ToList();

            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        Task IOrderService.CreateOrderAsync(Guid customerId, Order orderItems)
        {
            throw new NotImplementedException();
        }

        private int CreateRandomNumber(int length)
        {
            Random rnd = new Random();
            return rnd.Next(Convert.ToInt32(Math.Pow(10, length - 1)), Convert.ToInt32(Math.Pow(10, length)));
        }
    }
}
