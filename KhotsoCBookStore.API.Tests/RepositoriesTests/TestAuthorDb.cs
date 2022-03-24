using AutoMapper;
using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Controllers;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Profiles;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KhotsoCBookStore.API.Tests.RepositoriesTests
{
    public  class TestAuthorDb
    {
        Mock<IAuthorService> mockRepo;
        Mock<IMailService> mockMail;
        AuthorMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        #region Seeding
        public TestAuthorDb(DbContextOptions<KhotsoCBookStoreDbContext> contextOptions,Mock<IAuthorService> mockRepo)
        {          

            ContextOptions = contextOptions;
            Seed();
        }

        protected DbContextOptions<KhotsoCBookStoreDbContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "Charles",
                    LastName = "Mokhethi"
                };

                var two = new Author()
                {
                   AuthorId = Guid.NewGuid(),
                    FirstName = "Charles",
                    LastName = "Mokhethi"
                };

                var three = new Author()
                {
                    AuthorId = Guid.NewGuid(),
                    FirstName = "Charles",
                    LastName = "Mokhethi"
                };
                context.AddRange(one, two, three);
                context.SaveChanges();
            }
        }

        #endregion

        [Fact]
        public void Test_Create_GET_ReturnsViewResultNullModel()
        {
            mockRepo = new Mock<IAuthorService>();
            mockMail = new Mock<IMailService>();
            realProfile = new AuthorMappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);

            var author = new AuthorForCreateDto
            {
                FirstName ="Neil",
                LastName = "Diesel"
            };

            using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
            {
                // Arrange
                var controller = new AuthorController(mockRepo.Object,mapper,mockMail.Object);

                // Act
                var result = controller.CreateAuthor(author);

                // Assert
                Assert.IsType<OkObjectResult>(result.Result);
            }
        }

        // [Fact]
        // public async Task Test_Create_POST_InvalidModelState()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         var r = new Author()
        //         {
        //             Id = 4,
        //             Name = "Test Four",
        //             Age = 59
        //         };
        //         var controller = new AuthorController(context);
        //         controller.ModelState.AddModelError("Name", "Name is required");

        //         // Act
        //         var result = await controller.Create(r);

        //         // Assert
        //         var viewResult = Assert.IsType<ViewResult>(result);
        //         Assert.Null(viewResult.ViewData.Model);
        //     }
        // }

        // [Fact]
        // public async Task Test_Create_POST_ValidModelState()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         var newAuthor = new AuthorForCreateDto()
        //         {
        //             FirstName = "Nikol",
        //             LastName= "Telsa",
        //          };

        //         var controller = new AuthorController(mockRepo.Object,mapper,mockMail.Object);

        //         // Act
        //         var result = await controller.CreateAuthor(newAuthor);

        //         // Assert
        //         var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //         Assert.Null(redirectToActionResult.ControllerName);
        //         Assert.Equal("Read", redirectToActionResult.ActionName);
        //     }
        // }

        // [Fact]
        // public void Test_Read_GET_ReturnsViewResult_WithAListOfAuthors()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         var controller = new AuthorController(context);

        //         // Act
        //         var result = controller.Read();

        //         // Assert
        //         var viewResult = Assert.IsType<ViewResult>(result);
        //         var model = Assert.IsAssignableFrom<IEnumerable<Author>>(viewResult.ViewData.Model);
        //         Assert.Equal(3, model.Count());
        //     }
        // }

        // [Fact]
        // public void Test_Update_GET_ReturnsViewResult_WithSingleAuthor()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         int testId = 2;

        //         var controller = new AuthorController(context);

        //         // Act
        //         var result = controller.Update(testId);

        //         // Assert
        //         var viewResult = Assert.IsType<ViewResult>(result);
        //         var model = Assert.IsAssignableFrom<Author>(viewResult.ViewData.Model);
        //         Assert.Equal(testId, model.Id);
        //         Assert.Equal("Test Two", model.Name);
        //         Assert.Equal(50, model.Age);
        //     }
        // }

        // [Fact]
        // public async Task Test_Update_POST_ReturnsViewResult_InValidModelState()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         int testId = 2;
        //         var r = new Author()
        //         {
        //             Id = 2,
        //             Name = "Test Four",
        //             Age = 59
        //         };
        //         var controller = new AuthorController(context);
        //         controller.ModelState.AddModelError("Name", "Name is required");

        //         // Act
        //         var result = await controller.Update(r);

        //         // Assert
        //         var viewResult = Assert.IsType<ViewResult>(result);
        //         var model = Assert.IsAssignableFrom<Author>(viewResult.ViewData.Model);
        //         Assert.Equal(testId, model.Id);
        //     }
        // }

        // [Fact]
        // public async Task Test_Update_POST_ReturnsViewResult_ValidModelState()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         int testId = 2;
        //         var r = new Author()
        //         {
        //             Id = 2,
        //             Name = "Test Four",
        //             Age = 59
        //         };
        //         var controller = new AuthorController(context);

        //         // Act
        //         var result = await controller.Update(r);

        //         // Assert
        //         var viewResult = Assert.IsType<ViewResult>(result);
        //         var model = Assert.IsAssignableFrom<Author>(viewResult.ViewData.Model);
        //         Assert.Equal(testId, model.Id);
        //         Assert.Equal(r.Name, model.Name);
        //         Assert.Equal(r.Age, model.Age);
        //     }
        // }

        // [Fact]
        // public async Task Test_Delete_POST_ReturnsViewResult_InValidModelState()
        // {
        //     using (var context = new KhotsoCBookStoreDbContext(ContextOptions))
        //     {
        //         // Arrange
        //         int testId = 2;

        //         var controller = new AuthorController(context);

        //         // Act
        //         var result = await controller.Delete(testId);

        //         // Assert
        //         var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //         Assert.Null(redirectToActionResult.ControllerName);
        //         Assert.Equal("Read", redirectToActionResult.ActionName);
        //     }
        // }
    }
}
