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

// namespace KhotsoCBookStore.API.Tests.ControllerTests
// {
//     public class WishListControllerTests : IDisposable
//     {
//         Mock<IWishListService> mockWishListRepo;
//         Mock<IBookService> mockBookRepo;
//         Mock<IMailService> mockMail;
//         Mock<ICustomerService> mockCustomerRepo;
//         WishListMappingProfile realProfile;
//         MapperConfiguration configuration;
//         IMapper mapper;
//         public WishListControllerTests()
//         {
//             mockWishListRepo = new Mock<IWishListService>();
//             mockBookRepo = new Mock<IBookService>();
//             mockMail = new Mock<IMailService>();
//             mockCustomerRepo = new Mock<ICustomerService>();
//             realProfile = new WishListMappingProfile();
//             configuration = new MapperConfiguration(cfg => cfg.
//             AddProfile(realProfile));
//             mapper = new Mapper(configuration);
//         }
//         public void Dispose()
//         {
//             mockMail = null;
//             mockWishListRepo = null;
//             mapper = null;
//             configuration = null;
//             realProfile = null;
//         }

//         private List<WishList> GetWishListsTest(int num)
//         {
//             var authors = new List<WishList>();
//             if (num > 0)
//             {
//                 authors.Add(new WishList
//                 {
//                    WishlistId = Guid.NewGuid(),
//                    //WishListItems = new List<WishListItem>()
//                 });
//             }
//             return  authors;
//         }

//         [Fact]
//         public async Task GetAllWishLists_ReturnsCorrectType_WhenDBHasOneResource()
//         {
//             //Arrange
//             var id = new Guid("00000000-0000-0000-0000-000000000000");
            
          
//            var controller = new WishListController(
//                 mockWishListRepo.Object,
//                 mockBookRepo.Object,
//                 mockCustomerRepo.Object,
//                 mockMail.Object,mapper);
//             //Act
//             var result =await  controller.GetWishListsById(id);

//             //Assert
//             Assert.IsType<ActionResult<IEnumerable<WishListDto>>>(result);
//         }

//         [Fact]
//         public async Task GetWishListsById_Returns404NotFound_WhenNonExistentIDProvided()
//         {
//             //Arrange
//             var id = new Guid("00000000-0000-0000-0000-000000000000");
//             // mockWishListRepo.Setup(repo =>
//             // repo.GetWishListByIdAsync(id)).ReturnsAsync( new WishList
//             // {
                
//             // });

//            var controller = new WishListController(
//                 mockWishListRepo.Object,
//                 mockBookRepo.Object,
//                 mockCustomerRepo.Object,
//                 mockMail.Object,mapper);
//             //Act
//             var result = await controller.GetWishListsById(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }

//         [Fact]
//         public async Task GetWishListsById_Returns200OK__WhenValidIDProvided()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
//             // mockWishListRepo.Setup(repo =>
//             // repo.GetWishListByIdAsync(id)).ReturnsAsync(new WishList
//             // {
//             //     FirstName = "Charles",
//             //     LastName = "Mokhrthi"
//             // });

//            var controller = new WishListController(
//                 mockWishListRepo.Object,
//                 mockBookRepo.Object,
//                 mockCustomerRepo.Object,
//                 mockMail.Object,mapper);
//             //Act
//             var result = await controller.GetWishListsById(id);

//             //Assert
//             Assert.IsType<OkObjectResult>(result);
//         }

//         [Fact]
//         public async Task GetWishListsById_Returns200OK__WhenValidIDProvided_()
//         {
//             //Arrange
//             var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
//             // mockWishListRepo.Setup(repo =>
//             // repo.GetWishListByIdAsync(id)).ReturnsAsync(new WishList
//             // {
//             //     FirstName = "Charles",
//             //     LastName = "Mokhrthi"
//             // });

//            var controller = new WishListController(
//                 mockWishListRepo.Object,
//                 mockBookRepo.Object,
//                 mockCustomerRepo.Object,
//                 mockMail.Object,mapper);
//             //Act
//             var result = await controller.GetWishListsById(id);

//             //Assert
//             Assert.IsType<ActionResult<WishListDto>>(result);
//         }

//         // [Fact]
//         // public  Task ToggleWishList_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
//         // {
//         //     //Arrange
//         //     var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
        
//         //    var controller = new WishListController(
//         //         mockWishListRepo.Object,
//         //         mockBookRepo.Object,
//         //         mockCustomerRepo.Object,
//         //         mockMail.Object,mapper);
//         //     //Act
//         //     var result =   controller.ToggleWishList(id,id);
            
//         //     //Assert
//         //     //Assert.IsType<ActionResult<WishListDto>>(result);
//         //     Assert.IsType<CreatedAtRouteResult>(result);
//         // }

//         // [Fact]
//         // public async Task ToggleWishList_Returns201Created_WhenValidObjectSubmitted()
//         // {
//         //     //Arrange
//         //     var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
//         //     // mockWishListRepo.Setup(repo =>
//         //     // repo.GetWishListByIdAsync(id)).ReturnsAsync(new WishList
//         //     // {
//         //     //     FirstName = "Charles",
//         //     //     LastName = "Mokhrthi"
//         //     // });

//         //    var controller = new WishListController(
//         //         mockWishListRepo.Object,
//         //         mockBookRepo.Object,
//         //         mockCustomerRepo.Object,
//         //         mockMail.Object,mapper);
//         //     //Act
//         //     var result =  controller.ToggleWishList(id,id);

//         //     //Assert
//         //     Assert.IsType<CreatedAtRouteResult>(result);
//         // }

        

//         // [Fact]
//         // public async Task ClearWishList_Returns204NoContent_WhenValidResourceIDSubmitted()
//         // {
//         //     //Arrange
//         //     var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
                
//         //    var controller = new WishListController(
//         //         mockWishListRepo.Object,
//         //         mockBookRepo.Object,
//         //         mockCustomerRepo.Object,
//         //         mockMail.Object,mapper);            
//         //     //Act
//         //     var result =  controller.ClearWishList(id);
            
//         //     //Assert
//         //     Assert.IsType<NoContentResult>(result);
//         // }

//         // [Fact]
//         // public async  Task ClearWishList_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
//         // {

//         //     //Arrange
//         //     var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
//         //     // mockWishListRepo.Setup(repo =>
//         //     // repo.GetWishListByIdAsync(id)).ReturnsAsync(() => null);
//         //    var controller = new WishListController(
//         //         mockWishListRepo.Object,
//         //         mockBookRepo.Object,
//         //         mockCustomerRepo.Object,
//         //         mockMail.Object,mapper);
//         //     //Act
//         //     var result =  controller.ClearWishList(id);

//         //     //Assert
//         //     Assert.IsType<NotFoundResult>(result);
//         // }
//     }
// }