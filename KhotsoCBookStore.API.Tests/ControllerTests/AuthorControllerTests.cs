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

namespace KhotsoCBookStore.API.Tests.Dtos
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

        [Fact]
        public void GetAuthorItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockRepo.Setup( repo =>
                 repo.GetAllAuthorsAync()).ReturnsAsync(() => null);


            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.GetAuthors();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public void GetAllAuthors_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            // mockRepo.Setup(repo =>
            // repo.GetAllAuthors()).Returns(GetAuthors(1));

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);
            //Act
            //var result = controller.();
            //Assert
            // var okResult = result.Result as OkObjectResult;
            // var authors = okResult.Value as List<AuthorDto>;
            // Assert.Single(authors);
        }

        [Fact]
        public void GetAllAuthors_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            // mockRepo.Setup(repo =>
            // repo.GetAllAuthorsAync()).Returns(GetAllAuthorsAync(1));
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.GetAuthors();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllAuthors_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            //  mockRepo.Setup(repo =>
            // repo.GetAllAuthorsAync()).ReturnsAsync(GetAuthorById(1));
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.GetAuthors();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<AuthorDto>>>(result);
        }

        [Fact]
        public void GetAuthorByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).Returns(() => null);

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.GetAuthorById(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetAuthorByID_Returns200OK__WhenValidIDProvided()
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
            var result = controller.GetAuthorById(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAuthorByID_Returns200OK__WhenValidIDProvided_()
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
            var result = controller.GetAuthorById(id);

            //Assert
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public void CreateAuthor_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.CreateAuthor(new AuthorForCreateDto { });

            //Assert
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public void CreateAuthor_Returns201Created_WhenValidObjectSubmitted()
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
            var result = controller.CreateAuthor(new AuthorForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void UpdateAuthor_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.UpdateAuthor(id, new AuthorForUpdateDto { });

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void UpdateAuthor_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);


            //Act
            var result = controller.UpdateAuthor(id, new AuthorForUpdateDto { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void PartialAuthorUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = controller.PartiallyUpdateAuthor(id,
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<AuthorForUpdateDto>
            { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteAuthor_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(new Author
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });

            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);
            //Act
            var result = controller.DeleteAuthor(id);
            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteAuthor_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {

            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockRepo.Setup(repo =>
            repo.GetAuthorByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new AuthorController(mockRepo.Object, mapper, mockMail.Object);
            
            //Act
            var result = controller.DeleteAuthor(id);
            
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}