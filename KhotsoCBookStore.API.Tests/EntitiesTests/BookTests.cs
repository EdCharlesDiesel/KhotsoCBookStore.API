using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.EntitiesTests
{
    public class BookTests : IDisposable
    {
        Book book;
        public BookTests()
        {
            book = new Book
            {
                BookId = new Guid("F6F0FB84-3ABB-45AE-BFCD-C30014A40AF3"),
                Title="Data Structures And Algorithms",
                Cost = 33.44M,
                RetailPrice = 65.25M,
                CoverFileName ="Default-Image",
                PublishingDate = DateTime.Now,
                PublisherId = Guid.NewGuid()
            };
        }

        public void Dispose()
        {
           book  = null;
        }

        [Fact]
        public void CanChangeId()
        {
            //Arrange
            var expected = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");
            //Act
            book.BookId = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");

            //Assert
            Assert.Equal(expected, book.BookId);
        }

        [Fact]
        public void CanChangeName()
        {
            //Arrange
            //Act
            book.Title = "Data Structures And Algotithms";

            //Assert
            Assert.Equal("Data Structures And Algotithms", book.Title);
        }

        [Fact]
        public void CanChangeCoverFileName()
        {
            //Arrange
            //Act
            book.CoverFileName = "Default image";

            //Assert
            Assert.Equal("Default image", book.CoverFileName);
        }

        [Fact]
        public void CanChangePublishingDate()
        {
            //Arrange
            var expected = new DateTime(2021,05,05);
            
            //Act
            book.PublishingDate = new DateTime(2021,05,05);

            //Assert
            Assert.Equal(expected, book.PublishingDate);
        }

        [Fact]
        public void CanChangePublisherId()
        {
            //Arrange
            var expected = new Guid();
            
            //Act
            book.PublisherId = new Guid();

            //Assert
            Assert.Equal(expected, book.PublisherId);
        }
    }
}
    