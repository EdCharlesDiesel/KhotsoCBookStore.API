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
    public class CheckOutControllerTests : IDisposable
    {
        IMapper mapper;
        Mock<IOrderService> mockOrderRepo;
        Mock<ICartService> mockCartRepo;
        OrderMappingProfile realProfile;
        MapperConfiguration configuration;

        public CheckOutControllerTests()
        {
            realProfile = new OrderMappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
            mockOrderRepo = new Mock<IOrderService>();
            mockCartRepo = new Mock<ICartService>();           

        }
        public void Dispose()
        {
            mapper = null;
            configuration = null;
            mockOrderRepo = null;
            mockCartRepo = null;
            realProfile = null;
        }

        [Fact]
        public async Task CreateCheckOut_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            var newOrder = new Order
            {
                CustomerId = id,
                OrderId =Guid.NewGuid(),
                CartTotal = 36.96M
            };

            mockOrderRepo.Setup(repo =>
            repo.CreateOrderAsync(id,newOrder)).Returns(()=>null);

            var controller = new CheckOutController(
                mapper,
                mockOrderRepo.Object,
                mockCartRepo.Object );

            //Act
            var result = await controller.CreateOrder(id,new OrderForCreateDto { });

            //Assert
            Assert.IsType<ActionResult<OrderDto>>(result);
        }

        [Fact]
        public async Task CreateCheckOut_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            var newOrder = new Order
            {
                CustomerId = id,
                OrderId =Guid.NewGuid(),
                CartTotal = 36.96M
            };

            mockOrderRepo.Setup(repo =>
            repo.CreateOrderAsync(id,newOrder)).Returns(()=>null);

            var controller = new CheckOutController(
                mapper,
                mockOrderRepo.Object,
                mockCartRepo.Object );

            //Act
            var result = await controller.CreateOrder(id,new OrderForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

    }
}