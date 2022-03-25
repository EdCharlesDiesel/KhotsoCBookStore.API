using System;
using Xunit;
using KhotsoCBookStore.API.Entities;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class WishListTest : IDisposable
    {
        WishList wishList;
        public WishListTest()
        {
            wishList = new WishList
            {
             WishlistId = new Guid(),
             CustomerId = new Guid(),
            //  WishListItems = new List<WishListItem>(),
            //  Customer = new Customer()
            };
        }

        public void Dispose()
        {
            wishList = null;
        }

        // [Fact]
        // public void CanChangeWishItems()
        // {
        //    //Arrange
        //     var expected = new List<WishListItem>();
            
        //     //Act
        //     wishList.WishListItems = new List<WishListItem>();;

        //     //Assert
        //     Assert.Equal(expected, wishList.WishListItems);
        // }

        [Fact]
        public void CanChangeCustomerId()
        {
               var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
            //Act
            wishList.CustomerId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

            //Assert
            Assert.Equal(expected, wishList.CustomerId);
        }

        // [Fact]
        // public void CanChangeDateCreated()
        // {
        //     //Arrange
        //     //Act
        //     customerOrder.DateCreated = new DateTime(2021, 02, 06);
        //     var expected = new DateTime(2021, 02, 06);

        //     //Assert
        //     Assert.Equal(expected, customerOrder.DateCreated);
        // }
    }
}
