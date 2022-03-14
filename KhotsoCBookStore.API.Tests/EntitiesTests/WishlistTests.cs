using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class WishlistTest : IDisposable
    {
        Wishlist wishlist;
        public WishlistTest()
        {
            wishlist = new Wishlist
            {
                WishlistId = "1",
                UserId = 1,
                DateCreated = new DateTime()

            };
        }

        public void Dispose()
        {
            wishlist = null;
        }
    

    [Fact]
    public void CanChangeWishlistId()
    {
        //Arrange
        //Act
        wishlist.WishlistId = "2";

        //Assert
        Assert.Equal("2", wishlist.WishlistId);
    }

    [Fact]
    public void CanChangeUserId()
    {
        //Arrange
        //Act
        wishlist.UserId = 2;

        //Assert
        Assert.Equal(2, wishlist.UserId);
    }

    [Fact]
    public void CanChangeDateCreated()
    {
        //Arrange
        //Act
        wishlist.DateCreated = new DateTime(2021, 02, 06);
        var expected = new DateTime(2021, 02, 06);

        //Assert
        Assert.Equal(expected, wishlist.DateCreated);
    }
}
}
    