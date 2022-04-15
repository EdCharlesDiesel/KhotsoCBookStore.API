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
    public class OrderControllerTests : IDisposable
    {
        Mock<IOrderService> mockRepo;
        Mock<IMailService> mockMail;
        OrderMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public OrderControllerTests()
        {
            mockRepo = new Mock<IOrderService>();
            mockMail = new Mock<IMailService>();
            realProfile = new OrderMappingProfile();
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

        private List<Order> GetOrdersTest(int num)
        {
            var orders = new List<Order>();
            if (num > 0)
            {
                orders.Add(new Order
                {
                    OrderId = Guid.NewGuid(),
                    BookId= Guid.NewGuid(),
                    CartTotal =22.55M,
                    CustomerId = Guid.NewGuid(),
                    OrderDate= DateTime.Now,
                    ShippingAddress= null,
                    ShipDate = DateTime.Now,
                    OrderItems = new  List<OrderItem>()
                });
            }
            return  orders;
        }



        // [Fact]
        // public async Task GetOrderByID_Returns404NotFound_WhenNonExistentIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("00000000-0000-0000-0000-000000000000");
        //     mockRepo.Setup(repo =>
        //     repo.GetOrderByIdAsync(id)).ReturnsAsync( new Order
        //     {
                
        //     });

        //     var controller = new OrderController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetOrderById(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetOrderByID_Returns200OK__WhenValidIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetOrderByIdAsync(id)).ReturnsAsync(new Order
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new OrderController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetOrderById(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetOrderByID_Returns200OK__WhenValidIDProvided_()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetOrderByIdAsync(id)).ReturnsAsync(new Order
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new OrderController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetOrderById(id);

        //     //Assert
        //     Assert.IsType<ActionResult<OrderDto>>(result);
        // }       
    }
}