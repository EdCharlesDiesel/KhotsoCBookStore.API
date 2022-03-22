using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class CartTests : IDisposable
    {
        Cart cart;
        public CartTests()
        {
            cart = new Cart
            {
                CartId = "1",
                UserId = 1,
                DateCreated = new DateTime(2021,10,08)
            };
        }

        public void Dispose()
        {
           cart  = null;
        }

        [Fact]
        public void CanChangeCartId()
        {
            //Arrange
            //Act
            cart.CartId = "33";

            //Assert
            Assert.Equal("33", cart.CartId);
        }

        [Fact]
        public void CanChangeDateCreated()
        {
            //Arrange
            //Act
            cart.DateCreated = new DateTime(2021,05,18);
            var expected = new DateTime(2021,05,18);
            //Assert
            Assert.Equal(expected, cart.DateCreated);
        }
    }
}
    