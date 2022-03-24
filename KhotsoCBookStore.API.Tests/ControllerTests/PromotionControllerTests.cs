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

namespace KhotsoCBookStore.API.Tests.Dtos
{
    public class PromotionControllerTests : IDisposable
    {
        Mock<IPromotionService> mockRepo;
        Mock<IBookService> mockBookRepo;
        Mock<ICustomerService> mockCustomerRepo;
        Mock<IMailService> mockMail;
        PromotionMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public PromotionControllerTests()
        {
             mockBookRepo = new Mock<IBookService>();
              mockCustomerRepo = new Mock<ICustomerService>();
            mockRepo = new Mock<IPromotionService>();
            mockMail = new Mock<IMailService>();
            realProfile = new PromotionMappingProfile();
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

        private List<Promotion> GetPromotionsTest(int num)
        {
            var promotions = new List<Promotion>();
            if (num > 0)
            {
                promotions.Add(new Promotion
                {
                    MinimumRetail =33.00M,
                    MaximumRetail=69.22M
                });
            }
            return  promotions;
        }

        // [Fact]
        // public async Task GetPromotionItems_Returns200OK_WhenDBIsEmpty()
        // {
        //     //Arrange
        //     var id = new Guid();
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);


        //     var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result);

        // }

        // [Fact]
        // public async Task  GetAllPromotions_ReturnsOneItem_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     var id = new Guid();
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);


        //     var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     // var okResult = result.Result as OkObjectResult;
        //     // var promotions = okResult.Value as List<PromotionDto>;
        //     //Assert.Single(result);
        //     //Assert.IsNotType(result);
        // }

        // [Fact]
        // public async Task GetAllPromotions_Returns200OK_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     var id = new Guid();
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);
        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result =await  controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result);
        // }

        // [Fact]
        // public async Task GetAllPromotions_ReturnsCorrectType_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     var id = new Guid();
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);
        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result =await  controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<ActionResult<IEnumerable<Promotion>>>(result);
        // }

        // [Fact]
        // public async Task GetPromotionByID_Returns404NotFound_WhenNonExistentIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("00000000-0000-0000-0000-000000000000");
        //     mockRepo.Setup(repo =>
        //   repo.GetAllPromotionsAync()).ReturnsAsync(() => null);

        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result);
        // }

        // [Fact]
        // public async Task GetPromotionByID_Returns200OK__WhenValidIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //    repo.GetAllPromotionsAync()).ReturnsAsync(() => null);

        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result);
        // }

        // [Fact]
        // public async Task GetPromotionByID_Returns200OK__WhenValidIDProvided_()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);

        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<ActionResult<Promotion>>(result);
        // }

        // [Fact]
        // public async Task CreatePromotion_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);

        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     //Assert.IsType<ActionResult<PromotionDto>>(result);
        //     Assert.IsType<CreatedAtRouteResult>(result);
        // }

        // [Fact]
        // public async Task CreatePromotion_Returns201Created_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);

        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<CreatedAtRouteResult>(result);
        // }

        // [Fact]
        // public async Task DeletePromotion_Returns204NoContent_WhenValidResourceIDSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
        //     mockRepo.Setup(repo =>
        //    repo.GetAllPromotionsAync()).ReturnsAsync(() => null);

        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );
            
        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);
            
        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        // [Fact]
        // public async Task DeletePromotion_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        // {

        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAllPromotionsAync()).ReturnsAsync(() => null);
        //      var controller = new PromotionsController(
                 
        //          mockRepo.Object,
        //         mockBookRepo.Object,
        //         mockCustomerRepo.Object,
        //         mapper
        //         );

        //     //Act
        //     var result = await controller.GetCustomerPromotions(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result);
        // }
    }
}