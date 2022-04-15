using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class OrderTest : IDisposable
    {
        Order order;
        public OrderTest()
        {
            order = new Order
            {
                OrderId = new Guid(),
                // CartTotal = 1,
                // CustomerId =new Guid(),
                // OrderDate = new DateTime(2021, 12, 25),
                // ShipDate = new DateTime(2021, 12, 25),
                // ShipAddress = "Address"
            };
        }

        public void Dispose()
        {
            order = null;
        }

        [Fact]
        public void CanChangeOrderId()
        {
             //Arrange
            var expected = new Guid();
            
            //Act
            order.OrderId = new Guid();

            //Assert
            Assert.Equal(expected, order.OrderId);
        }

        [Fact]
        public void CanChangeCustomerId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            order.CustomerId = new Guid();

            //Assert
            Assert.Equal(expected, order.CustomerId);
        }

        [Fact]
        public void CanChangeCartTotal()
        {
            //Arrange
            var expected = 223.22M;
            //Act
            order.CartTotal = 223.22M;

            //Assert
            Assert.Equal(expected, order.CartTotal);
        }

        // [Fact]
        // public void CanChangeShipAddress()
        // {
        //     //Arrange
        //     //Act
        //     order.ShipAddress = "sdfsdf";

        //     //Assert
        //     Assert.Equal("sdfsdf", order.ShipAddress);
        // }

        [Fact]
        public void CanChangeShipDate()
        {
              //Arrange
            var expected = new DateTime(2021,05,05);
            //Act
            order.ShipDate =new DateTime(2021,05,05);

            //Assert
            Assert.Equal(expected, order.ShipDate);
        }

           [Fact]
        public void CanChangeOrderDate()
        {
            //Arrange
            var expected = new DateTime(2021,05,05);
            
            //Act
            order.OrderDate =new DateTime(2021,05,05);

            //Assert
            Assert.Equal(expected, order.OrderDate);
        }
    }
}
