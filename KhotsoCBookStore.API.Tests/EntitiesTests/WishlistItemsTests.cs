using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class WishlistItemsTest : IDisposable
    {
        WishlistItems wishlistItems;
        public WishlistItemsTest()
        {
            wishlistItems = new WishlistItems
            {
                ProductId =1,
                WishlistId = "1",
                WishlistItemId =1
            };
        }

        public void Dispose()
        {
            wishlistItems = null;
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            //Act
            wishlistItems.ProductId = 2;

            //Assert
            Assert.Equal(2, wishlistItems.ProductId);
        }

        [Fact]
        public void CanChangeWishListId()
        {
            //Arrange
            //Act
            wishlistItems.WishlistId = "2";

            //Assert
            Assert.Equal("2", wishlistItems.WishlistId);
        }

        [Fact]
        public void CanChangeWishlistItemId()
        {
            //Arrange
            //Act
            wishlistItems.WishlistItemId = 2;

            //Assert
            Assert.Equal(2, wishlistItems.WishlistItemId);
        }
    }
}
