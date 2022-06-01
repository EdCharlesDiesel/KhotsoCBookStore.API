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
//                 ProductSubscriptionId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"),
//                 ProductSubscriptionItemId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"),
//                 ProductId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ")
//             };
//         }

//         public void Dispose()
//         {
//            productSubscriptionItem  = null;
//         }

//         [Fact]
//         public void CanChangeProductSubscriptionItemId()
//         {
//             //Arrange
//             var expected = new Guid("D5066515-7104-4F85-894C-109BFB651111");
            
//             //Act
//             productSubscriptionItem.ProductSubscriptionItemId = new Guid("D5066515-7104-4F85-894C-109BFB651111");

//             //Assert
//             Assert.Equal(expected, productSubscriptionItem.ProductSubscriptionItemId);
//         }

        
//         [Fact]
//         public void CanChangeProductSubscription()
//         {
//             //Arrange
//             //Act
//             productSubscriptionItem.ProductSubscription = new ProductSubscription();

//             //Assert
//             Assert.IsType<ProductSubscription>(productSubscriptionItem.ProductSubscription);
//         }

//         [Fact]
//         public void CanChangeProductSubscriptionItems()
//         {
//                 //Arrange
//             var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
//             //Act
//             productSubscriptionItem.ProductSubscriptionId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

//             //Assert
//             Assert.Equal(expected, productSubscriptionItem.ProductSubscriptionId);
//         }

//         [Fact]
//         public void CanChangeProductId()
//         {
//              //Arrange
//             var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
//             //Act
//             productSubscriptionItem.ProductId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

//             //Assert
//             Assert.Equal(expected, productSubscriptionItem.ProductId);
//         }
//     }
// }
    