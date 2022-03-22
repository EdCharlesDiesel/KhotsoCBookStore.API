using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class WishListItemTest : IDisposable
    {
        WishListItem wishListItem;
        public WishListItemTest()
        {
            wishListItem = new WishListItem
            {
                ProductId =1,
                WishListId = "1",
                WishListItemId =1
            };
        }

        public void Dispose()
        {
            wishListItem = null;
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            //Act
            wishListItem.ProductId = 2;

            //Assert
            Assert.Equal(2, wishListItem.ProductId);
        }

        [Fact]
        public void CanChangeWishListId()
        {
            //Arrange
            //Act
            wishListItem.WishListId = "2";

            //Assert
            Assert.Equal("2", wishListItem.WishListId);
        }

        [Fact]
        public void CanChangeWishlistItemId()
        {
            //Arrange
            //Act
            wishListItem.WishListItemId = 2;

            //Assert
            Assert.Equal(2, wishListItem.WishListItemId);
        }
    }
}
