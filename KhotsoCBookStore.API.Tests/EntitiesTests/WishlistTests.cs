using System;
using Xunit;
using KhotsoCBookStore.API.Entities;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class WishListTest : IDisposable
    {
        WishList wishList;
        public WishListTest()
        {
            wishList = new WishList
            {
             WishListId = new Guid(),
             CustomerId = new Guid()
            };
        }

        public void Dispose()
        {
            wishList = null;
        }

        [Fact]
        public void CanChangeWishItems()
        {
           //Arrange
            var expected = new List<WishListItem>();
            
            //Act
            wishList.WishListItems = new List<WishListItem>();

            //Assert
            Assert.Equal(expected, wishList.WishListItems);
        }

        [Fact]
        public void CanChangeCustomerId()
        {
               var expected = new Guid();
            
            //Act
            wishList.CustomerId = new Guid();

            //Assert
            Assert.Equal(expected, wishList.CustomerId);
        }       
    }
}
