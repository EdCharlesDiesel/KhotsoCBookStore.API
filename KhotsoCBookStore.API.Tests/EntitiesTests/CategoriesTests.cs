using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class CategoriesTests : IDisposable
    {
        Categories categories;
        public CategoriesTests()
        {
            categories = new Categories
            {
                CategoryId =1,
                CategoryName ="Front-End Development"
            };
        }

        public void Dispose()
        {
           categories  = null;
        }

        [Fact]
        public void CanChangeCategoryId()
        {
            //Arrange
            //Act
            categories.CategoryId= 2;
            
            //Assert
            Assert.Equal(2, categories.CategoryId);
        }

        [Fact]
        public void CanChangeCategoryName()
        {
            //Arrange
            //Act
            categories.CategoryName="Back-End Development";

            //Assert
            Assert.Equal("Back-End Development", categories.CategoryName);
        }
    }
}
    