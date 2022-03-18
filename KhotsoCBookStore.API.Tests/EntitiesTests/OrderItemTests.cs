using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class OrderItemsTest : IDisposable
    {
        OrderItem orderItems;
        public OrderItemsTest()
        {
            orderItems = new OrderItem
            {

                OrderItemId = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ"),
                OrderId = new Guid("D5066515-RRRR-4F85-894C-109BFB65QQQQ"),
                ProductId = new Guid("D5066515-PPPP-4F85-894C-109BFB65QQQQ"),
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
            var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
            //Act
            orderItems.OrderItemId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

            //Assert
            Assert.Equal(expected, orderItems.OrderItemId);
        }

        [Fact]
        public void CanChangeOrderId()
        {
             //Arrange
            var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
            //Act
            orderItems.OrderId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

            //Assert
            Assert.Equal(expected, orderItems.OrderId);
        }

        [Fact]
        public void CanChangeProductId()
        {
             //Arrange
            var expected = new Guid("D5066515-7104-4F85-HHHH-109BFB65QQQQ");
            
            //Act
            orderItems.ProductId = new Guid("D5066515-7104-4F85-ZORO-109BFB65QQQQ");

            //Assert
            Assert.Equal(expected, orderItems.ProductId);;
        }

        [Fact]
        public void CanChangePrice()
        {
            //Arrange
            //Act
            orderItems.Price = 36.36M;

            //Assert
            Assert.Equal(36.36M, orderItems.Price);
        }

        [Fact]
        public void CanChangeQuantity()
        {
            //Arrange
            //Act
            orderItems.Quantity = 2;

            //Assert
            Assert.Equal(2, orderItems.Quantity);
        }
    }
}
