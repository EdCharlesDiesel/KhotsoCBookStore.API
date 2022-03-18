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
using KhotsoCBookStore.API.Authentication;

namespace KhotsoCBookStore.API.Tests.ControllerTests
{
    public class LoginControllerTests : IDisposable
    {
        Mock<IAuthorService> mockRepo;
        Mock<IMailService> mockMail;
        AuthorMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public LoginControllerTests()
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

        private List<UserMaster> GetAuthorsTest(int num)
        {
            var users = new List<UserMaster>();
            if (num > 0)
            {
                users.Add(new UserMaster
                {
                    
                });
            }
            return  users;
        }
       
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
    }
}