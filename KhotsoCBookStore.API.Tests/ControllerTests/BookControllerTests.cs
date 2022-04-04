using System;
using Xunit;
using KhotsoCBookStore.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using AutoMapper;
using KhotsoCBookStore.API.Services;
using KhotsoCBookStore.API.Profiles;
using System.Collections.Generic;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KhotsoCBookStore.API.Tests.ControllerTests
{
    public class BookControllerTests : IDisposable
    {
        Mock<IBookService> mockBookRepo;
        Mock<IMailService> mockMail;
        BookMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        Mock<IWebHostEnvironment> mockWeHost;
        Mock<IConfiguration> mockConfig;

         string coverImageFolderPath = string.Empty;

        public BookControllerTests()
        {
            mockBookRepo = new Mock<IBookService>();
            mockMail = new Mock<IMailService>();
            mockConfig = new Mock<IConfiguration>();
            mockWeHost = new Mock<IWebHostEnvironment>();
            realProfile = new BookMappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
           
           ;
        }
        public void Dispose()
        {
            
            mockMail = null;
            mockBookRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        

        private List<Book> GetBooksTest(int num)
        {
            var book = new List<Book>();
            if (num > 0)
            {
                book.Add(new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "Algo Expext",
                    RetailPrice = 36.25M,
                    PublisherId = new Guid(),
                    Cost =1.25M,
                    CoverFileName = "Defauly",
                    CreatedBy = "system",
                }
               // book.Add
                // ,
                //  new Book{
                //     BookId = Guid.NewGuid(),
                //     Title = "Algo Expext",
                //     RetailPrice = 36.25M,
                //     PublisherId = new Guid(),
                //     Cost =1.25M,
                //     CoverFileName = "Defauly",
                //     CreatedBy = "system",
                // },
                // new Book{                    BookId = Guid.NewGuid(),
                //     Title = "Algo Expext",
                //     RetailPrice = 36.25M,
                //     PublisherId = new Guid(),
                //     Cost =1.25M,
                //     CoverFileName = "Defauly",
                //     CreatedBy = "system"
                // }
                );
            }
            return  book;
        }

        [Fact]
        public async Task GetAllBooks_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockBookRepo.Setup(repo =>
            repo.GetAllBooksAync())
            .ReturnsAsync(() => null);


            var controller = new BookController(mockBookRepo.Object,
                                                mockMail.Object,
                                                mockConfig.Object,
                                                mockWeHost.Object,
                                                mapper);

            //Act
            var result = await controller.GetBooks();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }        

        [Fact]
        public async Task  GetAllBooks_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            mockBookRepo.Setup(repo =>
            repo.GetAllBooksAync()).ReturnsAsync(GetBooksTest(1));
                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act            
            var result = await controller.GetBooks();

            //Assert
            var okResult = result.Result as OkObjectResult;
            var book = okResult.Value as List<BookDto>;
            Assert.Single(book);
        }

        [Fact]
        public async Task GetAllBooks_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            mockBookRepo.Setup(repo =>
            repo.GetAllBooksAync()).ReturnsAsync(GetBooksTest(1));
                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result =await  controller.GetBooks();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllBooks_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockBookRepo.Setup(repo =>
            repo.GetAllBooksAync()).ReturnsAsync(GetBooksTest(1));
                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result =await  controller.GetBooks();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<BookDto>>>(result);
        }

        [Fact]
        public async Task GetBookByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            var id = new Guid("00000000-0000-0000-0000-000000000000");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync( new Book
            {
                
            });

                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.GetBook(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetBookByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(new Book
            {
                
            });

                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.GetBook(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetBookByID_Returns200OK__WhenValidIDProvided_()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(new Book
            {
                
            });

                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.GetBook(id);

            //Assert
            Assert.IsType<ActionResult<BookDto>>(result);
        }

        [Fact]
        public async Task CreateBook_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(new Book
            {
                BookId = id,
              
            });

                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.CreateBook(new BookForCreateDto { });

            //Assert
            //Assert.IsType<ActionResult<BookDto>>(result);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task CreateBook_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(new Book
            {
                
            });

                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.CreateBook(new BookForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        // [Fact]
        // public async Task UpdateBook_Returns204NoContent_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
        //     mockBookRepo.Setup(repo =>
        //     repo.BookIfExistsAsync(id)).ReturnsAsync(true);

        //     mockBookRepo.Setup(repo =>
        //     repo.GetBookByIdAsync(id)).ReturnsAsync(new Book
        //     {
        //         BookId= id,
              
        //     });

        //         var controller = new BookController(
        //    mockBookRepo.Object,
        //     mockMail.Object ,
        //     mockConfig.Object,
        //     mockWeHost.Object,
        //                mapper
        //     );

        //     //Act
        //     var result = await controller.UpdateBook(id, new BookForUpdateDto { });

        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        [Fact]
        public async Task UpdateBook_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(() => null);
                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);


            //Act
            var result = await controller.UpdateBook(id, new BookForUpdateDto { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PartialBookUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(() => null);
                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.PartiallyUpdateBook(id,
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<BookForUpdateDto>
            { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteBook_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
            mockBookRepo.Setup(repo =>
            repo.BookIfExistsAsync(id)).ReturnsAsync(true);

            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(new Book
            {
                BookId= id,
               
            });            
                
                var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);
            
            //Act
            var result = await controller.DeleteBook(id);
            
            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteBook_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {

            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockBookRepo.Setup(repo =>
            repo.GetBookByIdAsync(id)).ReturnsAsync(() => null);
            
            var controller = new BookController(mockBookRepo.Object,
                                                    mockMail.Object,
                                                    mockConfig.Object,
                                                    mockWeHost.Object,
                                                    mapper);

            //Act
            var result = await controller.DeleteBook(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}