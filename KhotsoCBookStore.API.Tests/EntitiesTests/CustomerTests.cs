using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class CustomerTests : IDisposable
    {
        Customer customer;
        public CustomerTests() => customer = new Customer
        {
            CustomerId = new Guid(),
            FirstName = "Khotso",
            LastName = "Mokhethi",
            EmailAddress = "Mokhetkc@hotmail.com",
            Address = "Mandela Street Sandton Drive",
            City = "Sandton",
            Province = "Gauteng",
            Postal = 2007,
            CreatedBy = "system",
            CreatedOn = DateTime.Now            
        };

        public void Dispose()
        {
           customer  = null;
        }

        [Fact]
        public void CanChangePostal()
        {
            //Arrange
            var expected = 18521;

            //Act
            customer.Postal = 18521;

            //Assert
            Assert.Equal(expected, customer.Postal);
        }

        [Fact]
        public void CanChangeProvince()
        {
            //Arrange
            var expected = "North West";

            //Act
            customer.Province = "North West";

            //Assert
            Assert.Equal(expected, customer.Province);
        }

        [Fact]
        public void CanChangeCity()
        {
            //Arrange
            var expected = "Sandton";

            //Act
            customer.City = "Sandton";

            //Assert
            Assert.Equal(expected, customer.City);
        }

        [Fact]
        public void CanChangeAddress()
        {
            //Arrange
            var expected = "Mandela Street Sandton Drive Gauteng";

            //Act
            customer.Address = "Mandela Street Sandton Drive Gauteng";

            //Assert
            Assert.Equal(expected, customer.Address);
        }

        [Fact]
        public void CanChangeEmailAddress()
        {
            //Arrange
            var customer = new Customer();
            
            //Act
            customer.EmailAddress = "Mokhetkc1@hotmail.com";

            //Assert
            Assert.Equal("Mokhetkc1@hotmail.com", customer.EmailAddress);
        }

        [Fact]
        public void CanChangeFirstName()
        {
            //Arrange
            var customer = new Customer();
            
            //Act
            customer.FirstName = "Data Structures And Algotithms";

            //Assert
            Assert.Equal("Data Structures And Algotithms", customer.FirstName);
        }

        [Fact]
        public void CanChangeId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            customer.CustomerId = new Guid();

            //Assert
            Assert.Equal(expected, customer.CustomerId);
        }

        [Fact]
        public void CanChangeLastName()
        {
            //Arrange
            var customer = new Customer();
            
            //Act
            customer.LastName = "Data Structures And Algotithms";

            //Assert
            Assert.Equal("Data Structures And Algotithms", customer.LastName);
        }       
    }
}
    