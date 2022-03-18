// using System;
// using Xunit;
// using KhotsoCPromotionStore.API.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using AutoMapper;
// using KhotsoCPromotionStore.API.Services;
// using KhotsoCPromotionStore.API.Profiles;
// using System.Collections.Generic;
// using KhotsoCPromotionStore.API.Dtos;
// using KhotsoCPromotionStore.API.Entities;
// using System.Threading.Tasks;

// namespace KhotsoCPromotionStore.API.Tests.ControllerTests
// {
//     public class PromotionControllerTests : IDisposable
//     {
//         Mock<IPromotionService> mockRepo;
//         Mock<IMailService> mockMail;
//         PromotionMappingProfile realProfile;
//         MapperConfiguration configuration;
//         IMapper mapper;
//         public PromotionControllerTests()
//         {
//             mockRepo = new Mock<IPromotionService>();
//             mockMail = new Mock<IMailService>();
//             realProfile = new PromotionMappingProfile();
//             configuration = new MapperConfiguration(cfg => cfg.
//             AddProfile(realProfile));
//             mapper = new Mapper(configuration);
//         }
//         public void Dispose()
//         {
//             mockMail = null;
//             mockRepo = null;
//             mapper = null;
//             configuration = null;
//             realProfile = null;
//         }

//         private List<Promotion> GetPromotionsTest(int num)
//         {
//             var authors = new List<Promotion>();
//             if (num > 0)
//             {
//                 authors.Add(new Promotion
//                 {
//                     PromotionId = Guid.NewGuid(),
//                     FirstName = "Charles",
//                     LastName = "Mokhethi"
//                 });
//             }
//             return  authors;
//         }

//         [Fact]
//         public async Task GetPromotionItems_Returns200OK_WhenDBIsEmpty()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPromotionsAync()).ReturnsAsync(() => null);


//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPromotions();

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);

//         }

//         [Fact]
//         public async Task  GetAllPromotions_ReturnsOneItem_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPromotionsAync()).ReturnsAsync(GetPromotionsTest(1));
//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act            
//             var result = await controller.GetPromotions();

//             //Assert
//             var okResult = result.Result as OkObjectResult;
//             var authors = okResult.Value as List<PromotionDto>;
//             Assert.Single(authors);
//         }

//         [Fact]
//         public async Task GetAllPromotions_Returns200OK_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPromotionsAync()).ReturnsAsync(GetPromotionsTest(1));
//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result =await  controller.GetPromotions();

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetAllPromotions_ReturnsCorrectType_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPromotionsAync()).ReturnsAsync(GetPromotionsTest(1));
//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result =await  controller.GetPromotions();

//             //Assert
//             Assert.IsType<ActionResult<IEnumerable<PromotionDto>>>(result);
//         }

//         [Fact]
//         public async Task GetPromotionByID_Returns404NotFound_WhenNonExistentIDProvided()
//         {
//             //Arrange
//             var id = new Guid("00000000-0000-0000-0000-000000000000");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync( new Promotion
//             {
                
//             });

//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPromotionById(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetPromotionByID_Returns200OK__WhenValidIDProvided()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(new Promotion
//             {
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPromotionById(id);

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetPromotionByID_Returns200OK__WhenValidIDProvided_()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(new Promotion
//             {
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPromotionById(id);

//             //Assert
//             Assert.IsType<ActionResult<PromotionDto>>(result);
//         }

//         [Fact]
//         public async Task CreatePromotion_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(new Promotion
//             {
//                 PromotionId = id,
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.CreatePromotion(new PromotionForCreateDto { });

//             //Assert
//             //Assert.IsType<ActionResult<PromotionDto>>(result);
//             Assert.IsType<CreatedAtRouteResult>(result);
//         }

//         [Fact]
//         public async Task CreatePromotion_Returns201Created_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(new Promotion
//             {
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.CreatePromotion(new PromotionForCreateDto { });

//             //Assert
//             Assert.IsType<CreatedAtRouteResult>(result);
//         }

       
//         [Fact]
//         public async Task PartialPromotionUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(() => null);
//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.PartiallyUpdatePromotion(id,
//             new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<PromotionForUpdateDto>
//             { });

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }

//         [Fact]
//         public async Task DeletePromotion_Returns204NoContent_WhenValidResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
//             mockRepo.Setup(repo =>
//             repo.PromotionIfExistsAsync(id)).ReturnsAsync(true);

//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(new Promotion
//             {
//                 PromotionId= id,
//                 FirstName ="Khotso",
//                 LastName = "Mokhethi"
//             });

            
                
//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);
            
//             //Act
//             var result = await controller.DeletePromotion(id);
            
//             //Assert
//             Assert.IsType<NoContentResult>(result);
//         }

//         [Fact]
//         public async Task DeletePromotion_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
//         {

//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
//             mockRepo.Setup(repo =>
//             repo.GetPromotionByIdAsync(id)).ReturnsAsync(() => null);
//             var controller = new PromotionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.DeletePromotion(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }
//     }
// }