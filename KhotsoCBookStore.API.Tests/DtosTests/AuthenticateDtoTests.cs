using System;
using Xunit;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Tests.Dtos
{
    public class AuthenticateDtoTests : IDisposable
    {
        AuthenticateDto authenticateDto;
        public AuthenticateDtoTests()
        {
            authenticateDto = new AuthenticateDto
            {
                Username = "admin",
                Password = "admin" 
            };
        }

        public void Dispose()
        {
           authenticateDto  = null;
        }

        [Fact]
        public void CanChangeUsername()
        {
            //Arrange
            //Act
            authenticateDto.Username = "Admin";

            //Assert
            Assert.Equal("Admin", authenticateDto.Username);
        }

        [Fact]
        public void CanChangePassword()
        {
            //Arrange
            //Act
            authenticateDto.Password = "Admin";

            //Assert
            Assert.Equal("Admin", authenticateDto.Password);
        }
    }
}
    