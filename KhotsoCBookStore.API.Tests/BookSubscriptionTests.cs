using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests
{
    public class BookSubscriptionTests : IDisposable
    {
        BookSubscription bookSubscription;
        public BookSubscriptionTests()
        {
            bookSubscription = new BookSubscription
            {
                BookSubscriptionId = "1",
                UserId = 3
               // DateCreated = "1988/08/05"
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
            bookSubscription.BookSubscriptionId = "2";

            //Assert
            Assert.Equal("2", bookSubscription.BookSubscriptionId);
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

        // [Fact]
        // public void CanChangeDateCreated()
        // {
        //     //Arrange
        //     //Act
        //     bookSubscription.DateCreated = "1988-08-05";

        //     //Assert
        //     Assert.Equal("1988/08/05", bookSubscription.DateCreated);
        // }
    }
}
    