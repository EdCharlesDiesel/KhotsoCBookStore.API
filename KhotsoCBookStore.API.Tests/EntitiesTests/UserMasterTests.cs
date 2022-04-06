using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Authentication;
using Xunit;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class UserMasterTests: IDisposable
    {
        UserMaster userMaster;
        public UserMasterTests()
        {
            userMaster = new UserMaster
            {
                UserId = new Guid(),
                Password = "passsword",
                PasswordHash = new byte[]{},
                PasswordSalt = new byte[]{},
                DateOfBirth = DateTime.Now,
                Username ="admin"
            };
        }

        public void Dispose()
        {
           userMaster  = null;
        }

       

        [Fact]
        public void CanChangeUsername()
        {
            //Arrange
            var expected = "Admin";
            
            //Act
            userMaster.Username = "Admin";

            //Assert
            Assert.Equal(expected, userMaster.Username);
        }

        [Fact]
        public void CanChangeDateOfBirth()
        {
            //Arrange
            var expected = DateTime.Today;
            
            //Act
            userMaster.DateOfBirth = DateTime.Today;

            //Assert
            Assert.Equal(expected, userMaster.DateOfBirth);
        }

        [Fact]
        public void CanChangePasswordSalt()
        {
            //Arrange
            var expected = new byte[]{};
            
            //Act
            userMaster.PasswordSalt = new byte[]{};

            //Assert
            Assert.Equal(expected, userMaster.PasswordSalt);
        }

        [Fact]
        public void CanChangePasswordHash()
        {
            //Arrange
            var expected = new byte[]{};
            
            //Act
            userMaster.PasswordHash = new byte[]{};

            //Assert
            Assert.Equal(expected, userMaster.PasswordHash);
        }

        [Fact]
        public void CanChangePassword()
        {
            //Arrange
            var expected = "Password";
            
            //Act
            userMaster.Password = "Password";;

            //Assert
            Assert.Equal(expected, userMaster.Password);
        }

        [Fact]
        public void CanChangeId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            userMaster.UserId = new Guid();

            //Assert
            Assert.Equal(expected, userMaster.UserId);
        }       
    }
}
    