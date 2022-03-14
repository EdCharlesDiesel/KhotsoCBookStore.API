using System;
using Xunit;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Tests.Dto
{
    public class RegisterDtoTests : IDisposable
    {
        RegisterDto registerDto;
        public RegisterDtoTests()
        {
            registerDto = new RegisterDto
            {
                UserTypeId = 1,
                Username ="admin",
                Password ="admin",
                FirstName ="Khotso",
                LastName ="Mokhethi",
                EmailAddress = "Mokhetkc@hotmai.com"
            };
        }

        public void Dispose()
        {
           registerDto  = null;
        }

        [Fact]
        public void CanChangeUserTypeId()
        {
            //Arrange
            //Act
            registerDto.UserTypeId = 2;

            //Assert
            Assert.Equal(2, registerDto.UserTypeId);
        }

        [Fact]
        public void CanChangeUsername()
        {
            //Arrange
            //Act
            registerDto.Username = "Admin";

            //Assert
            Assert.Equal("Admin", registerDto.Username);
        }

        [Fact]
        public void CanChangePassword()
        {
            //Arrange
            //Act
            registerDto.Password = "Admin";

            //Assert
            Assert.Equal("Admin", registerDto.Password);
        }

        [Fact]
        public void CanChangeFirstname()
        {
            //Arrange
            //Act
            registerDto.FirstName = "khotso";

            //Assert
            Assert.Equal("khotso", registerDto.FirstName);
        }

        [Fact]
        public void CanChangeLastname()
        {
            //Arrange
            //Act
            registerDto.LastName = "Legwale";

            //Assert
            Assert.Equal("Legwale", registerDto.LastName);
        }  

        [Fact]
        public void CanChangeEmailAddress()
        {
            //Arrange
            //Act
            registerDto.EmailAddress = "Ckhotso@gmail.com";

            //Assert
            Assert.Equal("Ckhotso@gmail.com", registerDto.EmailAddress);
        }
    }
}
    