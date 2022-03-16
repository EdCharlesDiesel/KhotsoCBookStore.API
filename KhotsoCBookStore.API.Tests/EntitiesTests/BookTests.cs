using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests.Entities
{
    public class BookTests : IDisposable
    {
        Book book;
        public BookTests()
        {
            book = new Book
            {
                BookId = new Guid("F6F0FB84-3ABB-45AE-BFCD-C30014A40AF3"),
                Name ="Data Structures And Algorithms",
                Text ="Data Structures are really important",
                Author = "EdCharlesDiesel",
                Category="Back-End Development",
                PurchasePrice=33.50M,
                CoverFileName ="Default-Image"
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
            book.Name = "Data Structures And Algotithms";

            //Assert
            Assert.Equal("Data Structures And Algotithms", book.Name);
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
    }
}
    