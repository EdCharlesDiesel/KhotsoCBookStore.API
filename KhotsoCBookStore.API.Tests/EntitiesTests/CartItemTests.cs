using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class CartItemTests : IDisposable
    {
        CartItem cartItems;
        public CartItemTests()
        {
            cartItems = new CartItem
            {
                CartItemId = new Guid("D5066515-7104-4F85-894C-109BFB651222"),
                CartId = new Guid("D5066515-7104-4F85-894C-109BFB651111"),
                ProductId = new Guid("D5066515-7104-4F85-894C-109BFB651333"),
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
            var expected = new Guid("D5066515-1478-4F85-894C-109BFB651444");
            
            //Act
            cartItems.CartId = new Guid("D5066515-1478-4F85-894C-109BFB651444");

            //Assert
            Assert.Equal(expected, cartItems.CartId);
        }

           [Fact]
        public void CanChangeCartItemId()
        {
            //Arrange
            var expected = new Guid("D5066515-1478-ZZZZ-894C-109BFB651444");
            
            //Act
            cartItems.CartItemId = new Guid("D5066515-1478-ZZZZ-894C-109BFB651444");

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
