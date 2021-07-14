using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace KhotsoCBookStore.API.Tests
{
    public class BookRespositoryTests
    {
        private readonly ITestOutputHelper _output;
        public BookRespositoryTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void GetBooks_That_ReturnsThreeBooks()
        {
            // Arrange

            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<KhotsoCBookStoreDbContext>()
                .UseSqlite(connection)
                .Options;


            using (var context = new KhotsoCBookStoreDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();


                context.Books.Add(new Entities.Book()
                { 
                    Name = "How To write CSS",
                    PurchasePrice = 350,
                    Author = "Charles Dickenson",
                    Category = "Web Developement",
                    CoverFileName ="",
                    Text="This is a book about summer"});



                context.SaveChanges();
            }

            using (var context = new KhotsoCBookStoreDbContext(options))
            {
                var bookRepository = new BookRepository(context);

                // Act
                var books = bookRepository.GetAllBooks();

                // Assert
                Assert.Equal(3, books.Count());
            }
        }

    }
}
