// using System;
// using Xunit;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using AutoMapper;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Services;
// using KhotsoCBookStore.API.Profiles;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Controllers;

// namespace KhotsoCProductSubscriptionStore.API.Tests.ControllerTests
// {
//     public class ProductSubscriptionControllerTests : IDisposable
//     {
//         Mock<IProductSubscriptionService> mockRepo;
//         Mock<IMailService> mockMail;
//         ProductSubscriptionMappingProfile realProfile;
//         MapperConfiguration configuration;
//         IMapper mapper;
//         public ProductSubscriptionControllerTests()
//         {
//             mockRepo = new Mock<IProductSubscriptionService>();
//             mockMail = new Mock<IMailService>();
//             realProfile = new ProductSubscriptionMappingProfile();
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

//         private List<ProductSubscription> GetProductSubscriptionsTest(int num)
//         {
//             var productSubscriptions = new List<ProductSubscription>();
//             if (num > 0)
//             {
//                 productSubscriptions.Add(new ProductSubscription
//                 {
//                     ProductSubscriptionId = Guid.NewGuid(),
//                     CustomerId = new Guid(),
//                     DateOfSubscrition = DateTime.Now,
//                     ProductSubscriptionItems = new List<ProductSubscriptionItem>()
//                 });
//             }
//             return  productSubscriptions;
//         }

//         [Fact]
//         public async Task GetProductSubscriptionItems_Returns200OK_WhenDBIsEmpty()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllProductSubscriptionsAync()).ReturnsAsync(() => null);


//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetProductSubscriptions();

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);

//         }

//         [Fact]
//         public async Task  GetAllProductSubscriptions_ReturnsOneItem_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllProductSubscriptionsAync()).ReturnsAsync(GetProductSubscriptionsTest(1));
//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act            
//             var result = await controller.GetProductSubscriptions();

//             //Assert
//             var okResult = result.Result as OkObjectResult;
//             var productSubscriptions = okResult.Value as List<ProductSubscriptionDto>;
//             Assert.Single(productSubscriptions);
//         }

//         [Fact]
//         public async Task GetAllProductSubscriptions_Returns200OK_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllProductSubscriptionsAync()).ReturnsAsync(GetProductSubscriptionsTest(1));
//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result =await  controller.GetProductSubscriptions();

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetAllProductSubscriptions_ReturnsCorrectType_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllProductSubscriptionsAync()).ReturnsAsync(GetProductSubscriptionsTest(1));
//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result =await  controller.GetProductSubscriptions();

//             //Assert
//             Assert.IsType<ActionResult<IEnumerable<ProductSubscriptionDto>>>(result);
//         }

//         [Fact]
//         public async Task GetProductSubscriptionByID_Returns404NotFound_WhenNonExistentIDProvided()
//         {
//             //Arrange
//             var id = new Guid("00000000-0000-0000-0000-000000000000");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync( new ProductSubscription
//             {
                
//             });

//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetProductSubscriptionById(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetProductSubscriptionByID_Returns200OK__WhenValidIDProvided()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(new ProductSubscription
//             {
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetProductSubscriptionById(id);

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetProductSubscriptionByID_Returns200OK__WhenValidIDProvided_()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(new ProductSubscription
//             {
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetProductSubscriptionById(id);

//             //Assert
//             Assert.IsType<ActionResult<ProductSubscriptionDto>>(result);
//         }

//         [Fact]
//         public async Task CreateProductSubscription_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(new ProductSubscription
//             {
//                 ProductSubscriptionId = id,
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.CreateProductSubscription(new ProductSubscriptionForCreateDto { });

//             //Assert
//             //Assert.IsType<ActionResult<ProductSubscriptionDto>>(result);
//             Assert.IsType<CreatedAtRouteResult>(result);
//         }

//         [Fact]
//         public async Task CreateProductSubscription_Returns201Created_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(new ProductSubscription
//             {
//                 FirstName = "Charles",
//                 LastName = "Mokhrthi"
//             });

//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.CreateProductSubscription(new ProductSubscriptionForCreateDto { });

//             //Assert
//             Assert.IsType<CreatedAtRouteResult>(result);
//         }

       
//         [Fact]
//         public async Task PartialProductSubscriptionUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(() => null);
//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.PartiallyUpdateProductSubscription(id,
//             new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<ProductSubscriptionForUpdateDto>
//             { });

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }

//         [Fact]
//         public async Task DeleteProductSubscription_Returns204NoContent_WhenValidResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
//             mockRepo.Setup(repo =>
//             repo.ProductSubscriptionIfExistsAsync(id)).ReturnsAsync(true);

//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(new ProductSubscription
//             {
//                 ProductSubscriptionId= id,
//                 FirstName ="Khotso",
//                 LastName = "Mokhethi"
//             });

            
                
//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);
            
//             //Act
//             var result = await controller.DeleteProductSubscription(id);
            
//             //Assert
//             Assert.IsType<NoContentResult>(result);
//         }

//         [Fact]
//         public async Task DeleteProductSubscription_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
//         {

//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
//             mockRepo.Setup(repo =>
//             repo.GetProductSubscriptionByIdAsync(id)).ReturnsAsync(() => null);
//             var controller = new ProductSubscriptionController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.DeleteProductSubscription(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }
//     }
// }