using System;
using StarPeace.Admin;
using Xunit;

namespace StarPeace.Admin.Tests
{
    
    public class ProgramTest
    {
        [Fact]
        public void IndexMultipliedByFiveTest()
        {
            //Arrange           
            var expectedArray = new int[] { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 
            50, 55, 60, 65, 70, 75, 80, 85, 90, 95 };
            int[] arr = new int[expectedArray.Length];
            
            //Act
            var actual = arr.IndexMultipliedByFive();
            
            //Assert
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.Equal(expectedArray[i], actual[i]);    
            }            
        }
    }
}
