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
    public class CartControllerTests : IDisposable
    {
        Mock<ICartService> mockRepo;
        Mock<IMailService> mockMail;
        CartMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public CartControllerTests()
        {
            mockRepo = new Mock<ICartService>();
            mockMail = new Mock<IMailService>();
            realProfile = new CartMappingProfile();
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

        private List<Cart> GetCartsTest(int num)
        {
            var Carts = new List<Cart>();
            if (num > 0)
            {
                Carts.Add(new Cart
                {
                    CartId = Guid.NewGuid(),
                    CartTotal =52.96M,
                    CustomerId = Guid.NewGuid(),
                });
            }
            return  Carts;
        }

        // [Fact]
        // public async Task AddItemToCart_CreatesCorrectResourceType_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
        //     var customerId = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
        //     var bookId = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");

        //     mockRepo.Setup(repo =>
        //     repo.AddBookToCartAsync(customerId,bookId)).ReturnsAsync<Cart>(new Cart
        //     {
        //         CartId = id,
        //         CartTotal = 23.25M,
        //         CustomerId = new Guid("300F030A-8566-40A0-95F5-52888B4242D6"),
        //     });

        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.CreateCart(new CartForCreateDto { });

        //     //Assert
        //     //Assert.IsType<ActionResult<CartDto>>(result);
        //     Assert.IsType<OkObjectResult>(result);
        // }

        // [Fact]
        // public async Task CreateCart_Returns201Created_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetCartByIdAsync(id)).ReturnsAsync(new Cart
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.CreateCart(new CartForCreateDto { });

        //     //Assert
        //     Assert.IsType<CreatedAtRouteResult>(result);
        // }

        // [Fact]
        // public async Task GetCartItems_Returns200OK_WhenDBIsEmpty()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllCartsAync()).ReturnsAsync(() => null);


        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetCarts();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);

        // }

        // [Fact]
        // public async Task  GetAllCarts_ReturnsOneItem_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllCartsAync()).ReturnsAsync(GetCartsTest(1));
        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act            
        //     var result = await controller.GetCarts();

        //     //Assert
        //     var okResult = result.Result as OkObjectResult;
        //     var Carts = okResult.Value as List<CartDto>;
        //     Assert.Single(Carts);
        // }

        // [Fact]
        // public async Task GetAllCarts_Returns200OK_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllCartsAync()).ReturnsAsync(GetCartsTest(1));
        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result =await  controller.GetCarts();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetAllCarts_ReturnsCorrectType_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllCartsAync()).ReturnsAsync(GetCartsTest(1));
        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result =await  controller.GetCarts();

        //     //Assert
        //     Assert.IsType<ActionResult<IEnumerable<CartDto>>>(result);
        // }

        // [Fact]
        // public async Task GetCartByID_Returns404NotFound_WhenNonExistentIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("00000000-0000-0000-0000-000000000000");
        //     mockRepo.Setup(repo =>
        //     repo.GetCartByIdAsync(id)).ReturnsAsync( new Cart
        //     {
                
        //     });

        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetCartById(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetCartByID_Returns200OK__WhenValidIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetCartByIdAsync(id)).ReturnsAsync(new Cart
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetCartById(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetCartByID_Returns200OK__WhenValidIDProvided_()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetCartByIdAsync(id)).ReturnsAsync(new Cart
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetCartById(id);

        //     //Assert
        //     Assert.IsType<ActionResult<CartDto>>(result);
        // }

        

        // [Fact]
        // public async Task DeleteCart_Returns204NoContent_WhenValidResourceIDSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
        //     mockRepo.Setup(repo =>
        //     repo.CartIfExistsAsync(id)).ReturnsAsync(true);

        //     mockRepo.Setup(repo =>
        //     repo.GetCartByIdAsync(id)).ReturnsAsync(new Cart
        //     {
        //         CartId= id,
        //         FirstName ="Khotso",
        //         LastName = "Mokhethi"
        //     });

            
                
        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);
            
        //     //Act
        //     var result = await controller.DeleteCart(id);
            
        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        // [Fact]
        // public async Task DeleteCart_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        // {

        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetCartByIdAsync(id)).ReturnsAsync(() => null);
        //     var controller = new CartController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.DeleteCart(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result);
        // }
    }
}