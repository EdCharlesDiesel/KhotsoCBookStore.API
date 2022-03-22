using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class CartItemsTests : IDisposable
    {
        CartItems cartItems;
        public CartItemsTests()
        {
            cartItems = new CartItems
            {
                CartId = "1",
                CartItemId = 1,
                ProductId = 1,
                Quantity = 1
            };
        }

        public void Dispose()
        {
            cartItems = null;
        }

        [Fact]
        public void CanChangeCartId()
        {
            //Arrange
            //Act
            cartItems.CartId = "2";

            //Assert
            Assert.Equal("2", cartItems.CartId);
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            //Act
            cartItems.ProductId = 2;

            //Assert
            Assert.Equal(2, cartItems.ProductId);
        }

        [Fact]
        public void CanChangeQuantity()
        {
            //Arrange
            //Act
            cartItems.Quantity = 2;

            //Assert
            Assert.Equal(2, cartItems.Quantity);
        }
    }
}
