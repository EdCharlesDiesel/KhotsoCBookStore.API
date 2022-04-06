using System;
using KhotsoCBookStore.API.Entities;
using Xunit;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class PublisherTests : IDisposable
    {
        Publisher promotion;
        public PublisherTests()
        {
            promotion = new Publisher
            {
                PublisherId = new Guid(),
                EmailAddress = "Mokhetkc@hotmail.com",
                NameAndSurname = "Charles Disckinson",
                PhoneNumber = 012302455
            };
        }

        public void Dispose()
        {
            promotion = null;
        }

         [Fact]
        public void CanChangePhoneNumber()
        {
            //Arrange
            var expected = 33658; 

            //Act
            promotion.PhoneNumber = 33658;

            //Assert
            Assert.Equal(expected, promotion.PhoneNumber);
        }

        [Fact]
        public void CanChangeNameAndSurname()
        {
            //Arrange
            var expected = "West";

            //Act
            promotion.NameAndSurname = "West";

            //Assert
            Assert.Equal(expected, promotion.NameAndSurname);
        }

        [Fact]
        public void CanChangeEmailAddress()
        {
            //Arrange
            var expected = "Ckhotso@gmail.com";
            
            //Act
            promotion.EmailAddress = "Ckhotso@gmail.com";;

            //Assert
            Assert.Equal(expected, promotion.EmailAddress);
        }

        [Fact]
        public void CanChangePublisherId()
        {
            //Arrange
            var expected = new Guid();

            //Act
            promotion.PublisherId = new Guid();

            //Assert
            Assert.Equal(expected, promotion.PublisherId);
        }       


        [Fact]
        public void CanChangeUpdatedBy()
        {
            //Arrange
            //Act
            promotion.UpdatedBy = "MKBay";

            //Assert
            Assert.Equal("MKBay", promotion.UpdatedBy);
        }


        [Fact]
        public void CanChangeUpdatedOn()
        {
            //Arrange
            var expected = new DateTime(2021, 05, 05);

            //Act
            promotion.UpdatedOn = new DateTime(2021, 05, 05);

            //Assert
            Assert.Equal(expected, promotion.UpdatedOn);
        }
    }
}
