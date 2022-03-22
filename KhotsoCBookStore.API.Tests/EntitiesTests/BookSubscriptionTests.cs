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
                ProductSubscriptionId = "1",
                UserId = 3,
               DateCreated = new DateTime(2012, 02, 27, 17, 30, 22)
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
            bookSubscription.ProductSubscriptionId = "2";

            //Assert
            Assert.Equal("2", bookSubscription.ProductSubscriptionId);
        }

        [Fact]
        public void CanChangeUserId()
        {
            //Arrange
            //Act
            bookSubscription.UserId = 3;

            //Assert
            Assert.Equal(3, bookSubscription.UserId);
        }

        [Fact]
        public void CanChangeDateCreated()
        {
            //Arrange
            //Act
            bookSubscription.DateCreated = new DateTime(2012, 02, 27, 17, 30, 22);;
            var expected = new DateTime(2012, 02, 27, 17, 30, 22);
            //Assert
            Assert.Equal(expected, bookSubscription.DateCreated);
        }
    }
}
    