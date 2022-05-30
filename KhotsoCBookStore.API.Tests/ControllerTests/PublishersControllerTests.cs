// using System;
// using Xunit;
// using KhotsoCBookStore.API.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using AutoMapper;
// using KhotsoCBookStore.API.Services;
// using KhotsoCBookStore.API.Profiles;
// using System.Collections.Generic;
// using KhotsoCBookStore.API.Dtos;
// using KhotsoCBookStore.API.Entities;
// using System.Threading.Tasks;

// namespace KhotsoCBookStore.API.Tests.Dtos
// {
//     public class PublisherControllerTests : IDisposable
//     {
//         Mock<IPublisherService> mockRepo;
//         Mock<IMailService> mockMail;
//         PublisherMappingProfile realProfile;
//         MapperConfiguration configuration;
//         IMapper mapper;
//         public PublisherControllerTests()
//         {
//             mockRepo = new Mock<IPublisherService>();
//             mockMail = new Mock<IMailService>();
//             realProfile = new PublisherMappingProfile();
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

//         private List<Publisher> GetPublishersTest(int num)
//         {
//             var authors = new List<Publisher>();
//             if (num > 0)
//             {
//                 authors.Add(new Publisher
//                 {
//                     PublisherId = Guid.NewGuid(),
//                    EmailAddress = "Mokhethi@gmail.com",
//                    Name="Mokhethi",
//                    PhoneNumber=01452
//                 });
//             }
//             return  authors;
//         }

//         [Fact]
//         public async Task GetPublisherItems_Returns200OK_WhenDBIsEmpty()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).Returns(() => null);


//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPublishers();

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);

//         }

//         [Fact]
//         public async Task  GetAllPublishers_ReturnsOneItem_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});
            
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act            
//             var result = await controller.GetPublishers();

//             //Assert
//             var okResult = result.Result as OkObjectResult;
//             var authors = okResult.Value as List<PublisherDto>;
//             Assert.Single(authors);
//         }

//         [Fact]
//         public async Task GetAllPublishers_Returns200OK_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync(GetPublishersTest(1));
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result =await  controller.GetPublishers();

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetAllPublishers_ReturnsCorrectType_WhenDBHasOneResource()
//         {
//             //Arrange
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync(GetPublishersTest(1));
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result =await  controller.GetPublishers();

//             //Assert
//             Assert.IsType<ActionResult<IEnumerable<PublisherDto>>>(result);
//         }

//         [Fact]
//         public async Task GetPublisherByID_Returns404NotFound_WhenNonExistentIDProvided()
//         {
//             //Arrange
//             var id = new Guid("00000000-0000-0000-0000-000000000000");
//             mockRepo.Setup(repo =>
//            repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPublisher(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetPublisherByID_Returns200OK__WhenValidIDProvided()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPublisher(id);

//             //Assert
//             Assert.IsType<OkObjectResult>(result.Result);
//         }

//         [Fact]
//         public async Task GetPublisherByID_Returns200OK__WhenValidIDProvided_()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
//             mockRepo.Setup(repo =>
//            repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.GetPublisher(id);

//             //Assert
//             Assert.IsType<ActionResult<PublisherDto>>(result);
//         }

//         [Fact]
//         public async Task CreatePublisher_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.CreatePublisher(new PublisherForCreateDto { });

//             //Assert
//             //Assert.IsType<ActionResult<PublisherDto>>(result);
//             Assert.IsType<CreatedAtRouteResult>(result);
//         }

//         [Fact]
//         public async Task CreatePublisher_Returns201Created_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
//             mockRepo.Setup(repo =>
//            repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.CreatePublisher(new PublisherForCreateDto { });

//             //Assert
//             Assert.IsType<CreatedAtRouteResult>(result);
//         }

//         [Fact]
//         public async Task UpdatePublisher_Returns204NoContent_WhenValidObjectSubmitted()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
//             mockRepo.Setup(repo =>
//             repo.PublisherIfExistsAsync(id)).ReturnsAsync(true);

//             mockRepo.Setup(repo =>
//            repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.UpdatePublisher(id, new PublisherForUpdateDto { });

//             //Assert
//             Assert.IsType<NoContentResult>(result);
//         }

//         [Fact]
//         public async Task UpdatePublisher_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);


//             //Act
//             var result = await controller.UpdatePublisher(id, new PublisherForUpdateDto { });

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }

//         [Fact]
//         public async Task PartialPublisherUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync(() => null);
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.PartiallyUpdatePublisher(id,
//             new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<PublisherForUpdateDto>
//             { });

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }

//         [Fact]
//         public async Task DeletePublisher_Returns204NoContent_WhenValidResourceIDSubmitted()
//         {
//             //Arrange
//             var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
//             mockRepo.Setup(repo =>
//             repo.PublisherIfExistsAsync(id)).ReturnsAsync(true);

//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});

            
                
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);
            
//             //Act
//             var result = await controller.DeletePublisher(id);
            
//             //Assert
//             Assert.IsType<NoContentResult>(result);
//         }

//         [Fact]
//         public async Task DeletePublisher_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
//         {

//             //Arrange
//             var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
//             mockRepo.Setup(repo =>
//             repo.GetAllPublishersAync()).ReturnsAsync( new List< Publisher>
//             {
//                 new Publisher{

//                 Name = "Dude",
//                 EmailAddress="Mokhethi@hotmia.com",
//                 PhoneNumber = 0214,
//                 PublisherId = Guid.NewGuid()
//             }});
//             var controller = new PublisherController(mockRepo.Object, mapper, mockMail.Object);

//             //Act
//             var result = await controller.DeletePublisher(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }
//     }
// }