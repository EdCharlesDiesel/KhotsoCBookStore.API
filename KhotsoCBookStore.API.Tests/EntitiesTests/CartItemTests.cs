using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class CartItemTests : IDisposable
    {
        CartItem cartItems;
        public CartItemTests()
        {
            cartItems = new CartItem
            {
                CartItemId = new Guid(),
                CartId = new Guid(),
                ProductId = new Guid(),
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
            var expected = new Guid();
            
            //Act
            cartItems.CartId = new Guid();

            //Assert
            Assert.Equal(expected, cartItems.CartId);
        }

        [Fact]
        public void CanChangeCartItemId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            cartItems.CartItemId = new Guid();

            //Assert
            Assert.Equal(expected, cartItems.CartItemId);
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            var expected = new Guid("D5066515-1478-4F85-AAAA-109BFB651444");
            
            //Act
            cartItems.ProductId = new Guid("D5066515-1478-4F85-AAAA-109BFB651444");

            //Assert
            Assert.Equal(expected, cartItems.ProductId);
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
