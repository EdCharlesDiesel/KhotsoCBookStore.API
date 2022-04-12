using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class ProductSubscriptionItemTests : IDisposable
    {
        ProductSubscriptionItem productSubscriptionItem;
        public ProductSubscriptionItemTests()
        {
            productSubscriptionItem = new ProductSubscriptionItem
            {
                ProductSubscriptionId = new Guid(),
                ProductSubscriptionItemId = new Guid(),
                ProductId = new Guid()
            };
        }

        public void Dispose()
        {
           productSubscriptionItem  = null;
        }

        [Fact]
        public void CanChangeProductSubscriptionItemId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            productSubscriptionItem.ProductSubscriptionItemId = new Guid();

            //Assert
            Assert.Equal(expected, productSubscriptionItem.ProductSubscriptionItemId);
        }

        [Fact]
        public void CanChangeProductSubscriptionItems()
        {
                //Arrange
            var expected = new Guid();
            
            //Act
            productSubscriptionItem.ProductSubscriptionId = new Guid();

            //Assert
            Assert.Equal(expected, productSubscriptionItem.ProductSubscriptionId);
        }

        [Fact]
        public void CanChangeProductId()
        {
             //Arrange
            var expected = new Guid();
            
            //Act
            productSubscriptionItem.ProductId = new Guid();

            //Assert
            Assert.Equal(expected, productSubscriptionItem.ProductId);
        }
    }
}
    