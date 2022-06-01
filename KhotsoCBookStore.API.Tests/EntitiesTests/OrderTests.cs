// using System;
// using Xunit;
// using KhotsoCBookStore.API.Entities;

// namespace KhotsoCBookStore.API.Tests.Entities
// {
//     public class OrderTest : IDisposable
//     {
//         Order order;
//         public OrderTest()
//         {
//             order = new Order
//             {
//                 OrderId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"),
//                 CartTotal = 1,
//                 CustomerId =new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"),
//                 OrderDate = new DateTime(2021, 12, 25),
//                 ShipDate = new DateTime(2021, 12, 25),
//                 ShipAddress = "Address"
//             };
//         }

//         public void Dispose()
//         {
//             order = null;
//         }

//         [Fact]
//         public void CanChangeOrderId()
//         {
//              //Arrange
//             var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
//             //Act
//             order.OrderId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

//             //Assert
//             Assert.Equal(expected, order.OrderId);
//         }

//         [Fact]
//         public void CanChangeCustomerId()
//         {
//             //Arrange
//             var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
//             //Act
//             order.CustomerId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

//             //Assert
//             Assert.Equal(expected, order.CustomerId);
//         }

//         [Fact]
//         public void CanChangeCartTotal()
//         {
//             //Arrange
//             //Act
//             order.CartTotal = 2;

//             //Assert
//             Assert.Equal(2, order.CartTotal);
//         }

//         [Fact]
//         public void CanChangeShipAddress()
//         {
//             //Arrange
//             //Act
//             order.ShipAddress = "sdfsdf";

//             //Assert
//             Assert.Equal("sdfsdf", order.ShipAddress);
//         }

//         [Fact]
//         public void CanChangeShipDate()
//         {
//               //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             order.ShipDate =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, order.ShipDate);
//         }

//            [Fact]
//         public void CanChangeOrderDate()
//         {
//               //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             order.OrderDate =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, order.OrderDate);
//         }
//     }
// }
