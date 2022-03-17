// using System;
// using Xunit;
// using KhotsoCBookStore.API.Entities;

// namespace KhotsoCBookStore.API.Tests.Entities
// {
//     public class CustomerOrdersTest : IDisposable
//     {
//         CustomerOrders customerOrders;
//         public CustomerOrdersTest()
//         {
//             customerOrders = new CustomerOrders
//             { 
//                 OrderId = "1",
//                 CartTotal = 1,
//                 UserId=1,
//                 DateCreated = new DateTime(2021,12,25)
//             };
//         }

//         public void Dispose()
//         {
//            customerOrders  = null;
//         }

//         [Fact]
//         public void CanChangeOrderId()
//         {
//             //Arrange
//             //Act
//             customerOrders.OrderId = "2";
            
//             //Assert
//             Assert.Equal("2", customerOrders.OrderId);
//         }

//         [Fact]
//         public void CanChangeCartTotal()
//         {
//             //Arrange
//             //Act
//             customerOrders.CartTotal = 2;
            
//             //Assert
//             Assert.Equal(2, customerOrders.CartTotal);
//         }

//         [Fact]
//         public void CanChangeUserId()
//         {
//             //Arrange
//             //Act
//             customerOrders.UserId=2;

//             //Assert
//             Assert.Equal(2, customerOrders.UserId);
//         }

//         [Fact]
//         public void CanChangeDateCreated()
//         {
//             //Arrange
//             //Act
//             customerOrders.DateCreated = new DateTime(2021,02,06);
//             var expected = new DateTime(2021,02,06);
            
//             //Assert
//             Assert.Equal(expected, customerOrders.DateCreated);
//         }


//     }
// }
    