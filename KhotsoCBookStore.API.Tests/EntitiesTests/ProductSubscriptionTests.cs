using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class ProductSubscriptionTests : IDisposable
    {
        ProductSubscription productSubscription;
        public ProductSubscriptionTests()
        {
            productSubscription = new ProductSubscription
            {
                ProductSubscriptionId = new Guid(),
                CustomerId = new Guid()              
            };
        }

        public void Dispose()
        {
           productSubscription  = null;
        }

        [Fact]
        public void CanChangeId()
        {
            //Arrange
            //Act
            productSubscription.ProductSubscriptionId = new Guid();

            //Assert
            Assert.Equal(new Guid(), productSubscription.ProductSubscriptionId);
        }

        [Fact]
        public void CanChangeCustomerId()
        {
            //Arrange
            //Act
            productSubscription.CustomerId = new Guid();

            //Assert
            Assert.Equal(new Guid(), productSubscription.CustomerId);
        }

    }
}
    