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

namespace KhotsoCBookStore.API.Tests.ControllerTests
{
    public class AuthorControllerTests : IDisposable
    {
        Mock<IAuthorService> mockRepo;
        Mock<IMailService> mockMail;
        AuthorMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public AuthorControllerTests()
        {
            mockRepo = new Mock<IAuthorService>();
            mockMail = new Mock<IMailService>();
            realProfile = new AuthorMappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }
        public void Dispose()
        {
            mockMail = null;
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        private List<Author> GetAuthorsTest(int num)
        {
            var authors = new List<Author>();
            if (num > 0)
            {
                authors.Add(new Author
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "Charles",
                    LastName = "Mokhethi"
                });
            }
            return  authors;
        }

        [Fact]
        public async Task GetAuthorItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllAuthorsAync()).ReturnsAsync(() => null);


            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.GetAuthors();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task  GetAllAuthors_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllAuthorsAync()).ReturnsAsync(GetAuthorsTest(1));
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act            
            var result = await controller.GetAuthors();

            //Assert
            var okResult = result.Result as OkObjectResult;
            var authors = okResult.Value as List<AuthorDto>;
            Assert.Single(authors);
        }

        [Fact]
        public async Task GetAllAuthors_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllAuthorsAync()).ReturnsAsync(GetAuthorsTest(1));
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result =await  controller.GetAuthors();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllAuthors_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllAuthorsAync()).ReturnsAsync(GetAuthorsTest(1));
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result =await  controller.GetAuthors();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<AuthorDto>>>(result);
        }

        [Fact]
        public async Task GetAuthorByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            var id = new Guid("00000000-0000-0000-0000-000000000000");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync( new Author
            {
                
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.GetAuthorById(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAuthorByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.GetAuthorById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAuthorByID_Returns200OK__WhenValidIDProvided_()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.GetAuthorById(id);

            //Assert
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public async Task CreateAuthor_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                AuthorId = id,
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.CreateAuthor(new AuthorForCreateDto { });

            //Assert
            //Assert.IsType<ActionResult<AuthorDto>>(result);
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task CreateAuthor_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.CreateAuthor(new AuthorForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task UpdateAuthor_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
            mockRepo.Setup(repo =>
            repo.AuthorIfExistsAsync(id)).ReturnsAsync(true);

            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                AuthorId= id,
                FirstName ="Khotso",
                LastName = "Mokhethi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.UpdateAuthor(id, new AuthorForUpdateDto { });

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateAuthor_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);


            //Act
            var result = await controller.UpdateAuthor(id, new AuthorForUpdateDto { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PartialAuthorUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.PartiallyUpdateAuthor(id,
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<AuthorForUpdateDto>
            { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAuthor_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
            mockRepo.Setup(repo =>
            repo.AuthorIfExistsAsync(id)).ReturnsAsync(true);

            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                AuthorId= id,
                FirstName ="Khotso",
                LastName = "Mokhethi"
            });

            
                
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);
            
            //Act
            var result = await controller.DeleteAuthor(id);
            
            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAuthor_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {

            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.DeleteAuthor(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}