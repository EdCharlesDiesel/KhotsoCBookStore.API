using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class WishTest : IDisposable
    {
        CustomerOrders customerOrder;
        public WishTest()
        {
            customerOrder = new CustomerOrders
            {
                CartTotal = 1,
                UserId = 1,
                DateCreated = new DateTime(2021, 12, 25)
            };
        }

        public void Dispose()
        {
            customerOrder = null;
        }

        [Fact]
        public void CanChangeCartTotal()
        {
            //Arrange
            //Act
            customerOrder.CartTotal = 2;

            //Assert
            Assert.Equal(2, customerOrder.CartTotal);
        }

        [Fact]
        public void CanChangeUserId()
        {
            //Arrange
            //Act
            customerOrder.UserId = 2;

            //Assert
            Assert.Equal(2, customerOrder.UserId);
        }

        [Fact]
        public void CanChangeDateCreated()
        {
            //Arrange
            //Act
            customerOrder.DateCreated = new DateTime(2021, 02, 06);
            var expected = new DateTime(2021, 02, 06);

            //Assert
            Assert.Equal(expected, customerOrder.DateCreated);
        }
    }
}
