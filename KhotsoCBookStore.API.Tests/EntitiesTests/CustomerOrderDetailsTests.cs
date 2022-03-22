using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class CustomerOrderDetailsTest : IDisposable
    {
        CustomerOrderDetails customerOrderDetails;
        public CustomerOrderDetailsTest()
        {
            customerOrderDetails = new CustomerOrderDetails
            {
                OrderDetailsId =1,
                OrderId ="1",
                Price = 33.33M,
                ProductId =1,
                Quantity = 1
            };
        }

        public void Dispose()
        {
           customerOrderDetails  = null;
        }

        [Fact]
        public void CanChangeOrderId()
        {
            //Arrange
            //Act
            customerOrderDetails.OrderId = "2";
            
            //Assert
            Assert.Equal("2", customerOrderDetails.OrderId);
        }

        [Fact]
        public void CanChangeOrderDetailId()
        {
            //Arrange
            //Act
            customerOrderDetails.OrderDetailsId=2;

            //Assert
            Assert.Equal(2, customerOrderDetails.OrderDetailsId);
        }

        [Fact]
        public void CanChangeProductId()
        {
            //Arrange
            //Act
            customerOrderDetails.ProductId=2;

            //Assert
            Assert.Equal(2, customerOrderDetails.ProductId);
        }

        [Fact]
        public void CanChangePrice()
        {
            //Arrange
            //Act
            customerOrderDetails.Price = 36.36M;

            //Assert
            Assert.Equal(36.36M, customerOrderDetails.Price);
        }

         [Fact]
        public void CanChangeQuantity()
        {
            //Arrange
            //Act
            customerOrderDetails.Quantity =2;

            //Assert
            Assert.Equal(2, customerOrderDetails.Quantity);
        }
    }
}
    