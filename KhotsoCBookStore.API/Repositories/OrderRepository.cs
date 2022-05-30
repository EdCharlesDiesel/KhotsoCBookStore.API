// using KhotsoCBookStore.API.Contexts;
// using KhotsoCBookStore.API.Dtos;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Services;
// using Microsoft.EntityFrameworkCore;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace KhotsoCBookStore.API.Repositories
// {
//     public class OrderRepository : IOrderService
//     {
//         readonly KhotsoCBookStoreDbContext _dbContext;
//         public OrderRepository(KhotsoCBookStoreDbContext dbContext)
//         {
//             _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
//         }
//         public async Task CreateOrderAsync(Guid customerId, Order orderDetails)
//         {
//             try
//             {
//                 var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
//                 var order = new Order
//                 {
//                     OrderId = Guid.NewGuid(),
//                     CustomerId = customer.CustomerId,
//                     OrderDate = orderDetails.OrderDate,
//                     ShipAddress = orderDetails.ShipAddress,
//                     ShipDate = orderDetails.ShipDate,
//                     CartTotal = orderDetails.CartTotal
//                 };

//                 await _dbContext.Orders.AddAsync(order);
//                 await _dbContext.SaveChangesAsync();

//                 foreach (var orderitem in order.OrderItems)
//                 {
//                     var book = _dbContext.Books.FirstOrDefault(b => b.BookId == orderDetails.BookId);
//                     OrderItem productDetails = new OrderItem
//                     {
//                         OrderId = order.OrderId,
//                         ProductId = order.BookId,
//                         Quantity = order.OrderItems.Count,
//                         Price = book.RetailPrice
//                     };
//                     await _dbContext.OrderItems.AddAsync(productDetails);

//                 }
//                 await _dbContext.SaveChangesAsync();
//             }
//             catch (System.Exception ex)
//             {
//                 throw new AggregateException(ex.Message);
//             }
//         }

//         public  async Task<Order> GetOrderForUserAsync(Guid customerId)
//         {
//             return  await  _dbContext.Orders.FirstOrDefaultAsync(c => c.CustomerId == customerId);
//         }    

//         public  Task<IEnumerable<Order>> GetOrderListAsync(Guid customerId)
//         {

//             // var  customerOrders = _dbContext.Orders.Where(x => x.CustomerId == customerId)
//             //     .Select(x => x.OrderId).ToList();

//             // foreach (var item in customerOrders)
//             // {
//             //     var order = new Order
//             //     {
//             //        ///  OrderId = item..Id,
//             //         CartTotal = _dbContext.OrderItems.FirstOrDefault(x => x.OrderId == item.OrderId).CartTotal,
//             //      OrderDate = _dbContext.Orders.FirstOrDefault(x => x.OrderId == orderid).DateCreated
//             //     };

//             //     List<CustomerOrderDetails> orderDetail = _dbContext.OrderItems.Where(x => x.OrderId == orderid).ToList();

//             //     order.OrderDetails = new List<CartItemModel>();

//             //     foreach (CustomerOrderDetails customerOrder in orderDetail)
//             //     {
//             //         CartItemModel item = new CartItemModel();

//             //         Book book = new Book
//             //         {
//             //             BookId = customerOrder.ProductId,
//             //             Name = _dbContext.Books.FirstOrDefault(x => x.BookId == customerOrder.ProductId && customerOrder.OrderId == orderid).Name,
//             //             PurchasePrice = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && customerOrder.OrderId == orderid).Price
//             //         };

//             //         item.Book = book;
//             //         item.Quantity = _dbContext.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && x.OrderId == orderid).Quantity;

//             //         order.OrderDetails.Add(item);
//             //     }
//             //     userOrders.Add(order);
//             // }
//             // return Orders.OrderByDescending(x => x.OrderDate).ToList();
//             throw new NotImplementedException();

//         }

//         public async Task<bool> SaveChangesAsync()
//         {
//             return (await _dbContext.SaveChangesAsync() >= 0);
//         }
//     }
// }
