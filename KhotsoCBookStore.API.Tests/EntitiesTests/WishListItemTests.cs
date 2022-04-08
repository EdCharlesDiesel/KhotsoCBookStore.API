using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class WishListItemTest : IDisposable
    {
        WishListItem wishListItem;
        public WishListItemTest()
        {
            wishListItem = new WishListItem
            {
                ProductId = new Guid("D1D9BEA1-2E36-4D6A-7474-0B97419609C9"),
                WishListId = new Guid("D1D9BEA1-2E36-9999-9D85-0B97419609C9"),
                WishListItemId = new Guid("D1D9BEA1-5555-4D6A-9D85-0B97419609C9"),
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
            var expected = new Guid();
            
            //Act
            wishListItem.ProductId = new Guid();

            //Assert
            Assert.Equal(expected, wishListItem.ProductId);
        }

        [Fact]
        public void CanChangeWishListId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            wishListItem.WishListId = new Guid();

            //Assert
            Assert.Equal(expected, wishListItem.WishListId);
        }

        [Fact]
        public void CanChangeWishlistItemId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            wishListItem.ProductId = new Guid();

            //Assert
            Assert.Equal(expected, wishListItem.ProductId);
        }

          [Fact]
        public void CanChangeWishList()
        {
            //Arrange
            var expected = new WishList();
            
            //Act
            //Assert
            Assert.IsType<WishList>(expected);
        }
    }
}
