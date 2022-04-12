using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class OrderItemsTest : IDisposable
    {
        OrderItem orderItems;
        public OrderItemsTest()
        {
            orderItems = new OrderItem
            {

                OrderItemId = new Guid(),
                OrderId = new Guid(),
                ProductId = new Guid(),
                Price = 33.33M,
                Quantity = 1
            };
        }

        public void Dispose()
        {
            orderItems = null;
        }

        [Fact]
        public void CanChangeOrderItemId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            orderItems.OrderItemId = new Guid();

            //Assert
            Assert.Equal(expected, orderItems.OrderItemId);
        }

        [Fact]
        public void CanChangeOrderId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            orderItems.OrderId = new Guid();

            //Assert
            Assert.Equal(expected, orderItems.OrderId);
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            orderItems.ProductId = new Guid();

            //Assert
            Assert.Equal(expected, orderItems.ProductId);;
        }

        [Fact]
        public void CanChangePrice()
        {
            //Arrange
            var expected = 36.36M;

            //Act
            orderItems.Price = 36.36M;

            //Assert
            Assert.Equal(expected, orderItems.Price);
        }

        [Fact]
        public void CanChangeQuantity()
        {
            //Arrange
            var expected = 2;
            
            //Act
            orderItems.Quantity = 2;

            //Assert
            Assert.Equal(expected, orderItems.Quantity);
        }
    }
}
