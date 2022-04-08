
using KhotsoCBookStore.API.Helpers;
using Xunit;

namespace KhotsoCBookStore.API.Tests
{
    public class AppSettingsTests
    {
        AppSettings appSettings;
        
        public AppSettingsTests()
        {
            appSettings = new AppSettings
            {
                Secret = "victoria's secret"
            };
        }

        [Fact]
        public void CanChangeSecret()
        {
            //Arrange
            var expected = "Victoria's secret";
            
            //Act
            appSettings.Secret = "Victoria's secret";

            //Assert
            Assert.Equal(expected, appSettings.Secret);
        }
    }
}