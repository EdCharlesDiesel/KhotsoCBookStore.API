using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class BookSubscriptionItemsTests : IDisposable
    {
        BookSubscriptionItems bookSubscriptionItems;
        public BookSubscriptionItemsTests()
        {
            bookSubscriptionItems = new BookSubscriptionItems
            {
                BookSubscriptionId = "1",
                BookSubscriptionItemId = 1,
                ProductId = 1
            };
        }

        public void Dispose()
        {
           bookSubscriptionItems  = null;
        }

        [Fact]
        public void CanChangeBookItemId()
        {
            //Arrange
            //Act
            bookSubscriptionItems.BookSubscriptionId = "2";

            //Assert
            Assert.Equal("2", bookSubscriptionItems.BookSubscriptionId);
        }

        [Fact]
        public void CanChangeBookSubscriptionItems()
        {
            //Arrange
            //Act
            bookSubscriptionItems.BookSubscriptionItemId = 3;

            //Assert
            Assert.Equal(3, bookSubscriptionItems.BookSubscriptionItemId);
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            //Act
            bookSubscriptionItems.ProductId = 2;
            
            //Assert
            Assert.Equal(2, bookSubscriptionItems.ProductId);
        }
    }
}
    