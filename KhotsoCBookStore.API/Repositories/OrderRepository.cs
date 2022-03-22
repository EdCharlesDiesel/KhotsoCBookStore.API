using KhotsoCBookStore.API.Contexts;
using System;

namespace KhotsoCBookStore.API.Repositories
{
    public class OrderRepository 
    {
        readonly KhotsoCBookStoreDbContext _dbContext;
        public OrderRepository(KhotsoCBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // public void CreateOrder(int userId, OrdersModel orderDetails)
        // {
        //     try
        //     {
        //         StringBuilder orderid = new StringBuilder();
        //         orderid.Append(CreateRandomNumber(3));
        //         orderid.Append('-');
        //         orderid.Append(CreateRandomNumber(6));

        //         CustomerOrders customerOrder = new CustomerOrders
        //         {
        //             OrderId = orderid.ToString(),
        //             UserId = userId,
        //             DateCreated = DateTime.Now.Date,
        //             CartTotal = orderDetails.CartTotal
        //         };
        //         _dbContext.CustomerOrders.Add(customerOrder);
        //         _dbContext.SaveChanges();

        //         foreach (CartItemModel order in orderDetails.OrderDetails)
        //         {
        //             CustomerOrderDetails productDetails = new CustomerOrderDetails
        //             {
        //                 OrderId = orderid.ToString(),
        //                 ProductId = order.Book.BookId,
        //                 Quantity = order.Quantity,
        //                 Price = order.Book.PurchasePrice
        //             };
        //             _dbContext.CustomerOrderDetails.Add(productDetails);
        //             _dbContext.SaveChanges();
        //         }
        //     }
        //     catch
        //     {
        //         throw;
        //     }
        // }

        // public List<OrdersModel> GetOrderList(int userId)
        // {
        //     List<OrdersModel> userOrders = new List<OrdersModel>();
        //     List<string> userOrderId = new List<string>();

        //     userOrderId = _dbContext.CustomerOrders.Where(x => x.UserId == userId)
        //         .Select(x => x.OrderId).ToList();

        //     foreach (string orderid in userOrderId)
        //     {
        //         OrdersModel order = new OrdersModel
        //         {
        //             OrderId = orderid,
        //             CartTotal = _dbContext.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).CartTotal,
        //             OrderDate = _dbContext.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).DateCreated
        //         };

        //         List<CustomerOrderDetails> orderDetail = _dbContext.CustomerOrderDetails.Where(x => x.OrderId == orderid).ToList();

        //         order.OrderDetails = new List<CartItemModel>();

        //         foreach (CustomerOrderDetails customerOrder in orderDetail)
        //         {
        //             CartItemModel item = new CartItemModel();

        //             Book book = new Book
        //             {
        //                 BookId = customerOrder.ProductId,
        //                 Name = _dbContext.Books.FirstOrDefault(x => x.BookId == customerOrder.ProductId && customerOrder.OrderId == orderid).Name,
        //                 PurchasePrice = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && customerOrder.OrderId == orderid).Price
        //             };

        //             item.Book = book;
        //             item.Quantity = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && x.OrderId == orderid).Quantity;

        //             order.OrderDetails.Add(item);
        //         }
        //         userOrders.Add(order);
        //     }
        //     return userOrders.OrderByDescending(x => x.OrderDate).ToList();
        // }

        int CreateRandomNumber(int length)
        {
            Random rnd = new Random();
            return rnd.Next(Convert.ToInt32(Math.Pow(10, length - 1)), Convert.ToInt32(Math.Pow(10, length)));
        }
    }
}
