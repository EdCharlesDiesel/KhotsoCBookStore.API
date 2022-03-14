using System;
using Xunit;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Tests
{
    public class BookTests : IDisposable
    {
        Book book;
        public BookTests()
        {
            book = new Book
            {
                BookId = 1,
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
            //Act
            book.BookId = 2;

            //Assert
            Assert.Equal(2, book.BookId);
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
    }
}
    