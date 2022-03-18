using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class ProductSubscriptionTests : IDisposable
    {
        ProductSubscription bookSubscription;
        public ProductSubscriptionTests()
        {
            bookSubscription = new ProductSubscription
            {
                ProductSubscriptionId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"),
                CustomerId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ")              
            };
        }

        public void Dispose()
        {
           bookSubscription  = null;
        }

        [Fact]
        public void CanChangeId()
        {
            //Arrange
            //Act
            bookSubscription.ProductSubscriptionId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");

            //Assert
            Assert.Equal(new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"), bookSubscription.ProductSubscriptionId);
        }

        [Fact]
        public void CanChangeCustomerId()
        {
            //Arrange
            //Act
            bookSubscription.CustomerId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");;

            //Assert
            Assert.Equal(new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"), bookSubscription.CustomerId);
        }

    }
}
    