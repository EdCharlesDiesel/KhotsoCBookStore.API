using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class CategoryTests : IDisposable
    {
        Category categories;
        public CategoryTests()
        {
            categories = new Category
            {
                CategoryId = new Guid(),
                CategoryName ="Front-End Development",
                BookId = new Guid()
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
            var expected  = new Guid();
            //Act
            categories.CategoryId = new Guid();
            
            //Assert
            Assert.Equal(expected, categories.CategoryId);
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

        [Fact]
        public void CanChangeBookId()
        {
            //Arrange
            var expected  = new Guid();
            //Act
            categories.CategoryId = new Guid();
            
            //Assert
            Assert.Equal(expected, categories.CategoryId);
        }
    }
}
    