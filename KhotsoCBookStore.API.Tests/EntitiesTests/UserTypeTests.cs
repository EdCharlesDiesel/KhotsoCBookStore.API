using System;
using KhotsoCBookStore.API.Authentication;
using Xunit;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class UserTypeTests: IDisposable
    {
        UserType userType;
        public UserTypeTests()
        {
            userType = new UserType
            {
                
                UserTypeId = new Guid(),
                UserTypeName = "Developer"              
            };
        }

        public void Dispose()
        {
           userType  = null;
        }

        [Fact]
        public void CanChangeUserTypeName()
        {
            //Arrange
            var expected = "Lead Developer";
            
            //Act
            userType.UserTypeName = "Lead Developer";

            //Assert
            Assert.Equal(expected, userType.UserTypeName);
        } 

        [Fact]
        public void CanChangeUserTypeId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            userType.UserTypeId = new Guid();

            //Assert
            Assert.Equal(expected, userType.UserTypeId);
        }             
    }
}
    