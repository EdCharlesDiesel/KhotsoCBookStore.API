// using System;
// using Xunit;
// using KhotsoCBookStore.API.Entities;

// namespace KhotsoCBookStore.API.Tests.Entities
// {
//     public class ProductSubscriptionItemTests : IDisposable
//     {
//         ProductSubscriptionItem productSubscriptionItem;
//         public ProductSubscriptionItemTests()
//         {
//             productSubscriptionItem = new ProductSubscriptionItem
//             {
//                 ProductSubscriptionId = "1",
//                 ProductSubscriptionItemId = 1,
//                 ProductId = 1
//             };
//         }

//         public void Dispose()
//         {
//            productSubscriptionItem  = null;
//         }

//         [Fact]
//         public void CanChangeProductItemId()
//         {
//             //Arrange
//             //Act
//             productSubscriptionItem.ProductSubscriptionId = "2";

//             //Assert
//             Assert.Equal("2", productSubscriptionItem.ProductSubscriptionId);
//         }

//         [Fact]
//         public void CanChangeProductSubscriptionItems()
//         {
//             //Arrange
//             //Act
//             productSubscriptionItem.ProductSubscriptionItemId = 3;

//             //Assert
//             Assert.Equal(3, productSubscriptionItem.ProductSubscriptionItemId);
//         }

//         [Fact]
//         public void CanChangeProductId()
//         {
//             //Arrange
//             //Act
//             productSubscriptionItem.ProductId = 2;
            
//             //Assert
//             Assert.Equal(2, productSubscriptionItem.ProductId);
//         }
//     }
// }
    