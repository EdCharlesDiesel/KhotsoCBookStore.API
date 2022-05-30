// using System;
// using Xunit;
// using KhotsoCBookStore.API.Entities;

// namespace KhotsoCBookStore.API.Tests.Entities
// {
//     public class CartTests : IDisposable
//     {
//         Cart cart;
//         public CartTests()
//         {
//             cart = new Cart
//             {
//                 CartId = new Guid("D5066515-7104-4F85-894C-109BFB651444"),
//                 CustomerId = new Guid("6C7BDF4F-1F95-46DB-973B-D1A45FF7E36F"),
//                 CreatedOn = new DateTime(2021,10,08),
//                 CartTotal = 69.55M
//             };
//         }

//         public void Dispose()
//         {
//            cart  = null;
//         }

//         [Fact]
//         public void CanChangeCartId()
//         {
//             //Arrange
//             var expected = new Guid("83982410-2B1F-42C6-8BC1-ED7747BEE55E");
//             //Act
//             cart.CartId = new Guid("83982410-2B1F-42C6-8BC1-ED7747BEE55E");

//             //Assert
//             Assert.Equal(expected, cart.CartId);
//         }

//         [Fact]
//         public void CanChangeUserId()
//         {
//             //Arrange
//             var expected = new Guid("FA77A292-A9C9-4BAA-9E74-83C3F96AD1BA");
//             //Act
//             cart.CartId = new Guid("FA77A292-A9C9-4BAA-9E74-83C3F96AD1BA");

//             //Assert
//             Assert.Equal(expected, cart.CartId);
//         }

//         [Fact]
//         public void CanChangeCreatedOn()
//         {
//             //Arrange
//             var expected = new DateTime(2021,05,18);
//             //Act
//             cart.CreatedOn = new DateTime(2021,05,18);
            
//             //Assert
//             Assert.Equal(expected, cart.CreatedOn);
//         }

//           [Fact]
//         public void CanChangeCartTotal()
//         {
//             //Arrange            
//             var expected = 99.85M;
//             //Act
//             cart.CartTotal = 99.85M;
            
//             //Assert
//             Assert.Equal(expected, cart.CartTotal);
//         }        
//     }
// }
    