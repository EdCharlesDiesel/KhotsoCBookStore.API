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
    public class CustomerControllerTests : IDisposable
    {
        Mock<ICustomerService> mockCustomerRepo;
        Mock<ICartService> mockCartServiceRepo;
        Mock<IMailService> mockMail;
        CustomerMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;

        public CustomerControllerTests()
        {
            mockCustomerRepo = new Mock<ICustomerService>();
            mockMail = new Mock<IMailService>();
            realProfile = new CustomerMappingProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
            mockCartServiceRepo = new Mock<ICartService>();
        }
        public void Dispose()
        {
            mockMail = null;
            mockCustomerRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
            mockCartServiceRepo = null;
        }

        private List<Customer> GetCustomersTest(int num)
        {
            var authors = new List<Customer>();
            if (num > 0)
            {
                authors.Add(new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    FirstName = "Charles",
                    LastName = "Mokhethi"
                });
            }
            return authors;
        }


        // [Fact]
        // public void GetCustomersAPIOptions_Returns200OK_WhenCalled()
        // {
        //     //Arrange
        //     mockCustomerRepo.Setup(repo =>
        //     repo.GetAllCustomersAync()).ReturnsAsync(() => null);
        //     var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

        //     //Act
        //     var result = controller.GetCustomersAPIOptions();

        //     //Assert
        //     Assert.IsType<IActionResult>(result);
        // }

        [Fact]
        public async Task GetCustomerItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockCustomerRepo.Setup(repo =>
            repo.GetAllCustomersAync()).ReturnsAsync(() => null);
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.GetCustomers();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllCustomers_ReturnsOneItem_WhenDBHasOneResource()
        {
            //Arrange
            mockCustomerRepo.Setup(repo =>
            repo.GetAllCustomersAync()).ReturnsAsync(GetCustomersTest(1));
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act            
            var result = await controller.GetCustomers();

            //Assert
            var okResult = result.Result as OkObjectResult;
            var authors = okResult.Value as List<CustomerDto>;
            Assert.Single(authors);
        }

        [Fact]
        public async Task GetAllCustomers_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            mockCustomerRepo.Setup(repo =>
            repo.GetAllCustomersAync()).ReturnsAsync(GetCustomersTest(1));
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.GetCustomers();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAllCustomers_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockCustomerRepo.Setup(repo =>
            repo.GetAllCustomersAync()).ReturnsAsync(GetCustomersTest(1));
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.GetCustomers();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<CustomerDto>>>(result);
        }

        [Fact]
        public async Task GetCustomerByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            var id = new Guid("00000000-0000-0000-0000-000000000000");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(new Customer
            {
                FirstName = "Charles",
                LastName = "Mokhethi"
            });
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.GetCustomer(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetCustomerByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(new Customer
            {
                FirstName = "Charles",
                LastName = "Mokhethi"
            });
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.GetCustomer(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetCustomerByID_Returns200OK__WhenValidIDProvided_()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(new Customer
            {
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.GetCustomer(id);

            //Assert
            Assert.IsType<ActionResult<CustomerDto>>(result);
        }

        [Fact]
        public async Task CreateCustomer_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(new Customer
            {
                CustomerId = id,
                FirstName = "Charles",
                LastName = "Mokhrthi"
            });
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.CreateCustomer(new CustomerForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
            
        }

        [Fact]
        public async Task CreateCustomer_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange
            var newCustomer = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "Khotso",
                LastName = "Mokhethi",
                DateOfBirth = DateTime.Now,
                EmailAddress = "Mokhetkc@hotmail.com",
                Username = "admin",
                Address = "1231 City Place Pretoria 0002",
                City = "Pretoria",
                Province = "Gauteng",
                Postal = 1852,
            };

            mockCustomerRepo.Setup(repo =>
            repo.CustomerIfExistsAsync(newCustomer.CustomerId)).ReturnsAsync(true);            
            
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.CreateCustomer(new CustomerForCreateDto { });

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        // [Fact]
        // public async Task UpdateCustomer_Returns204NoContent_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
        //     mockCustomerRepo.Setup(repo =>
        //     repo.CustomerIfExistsAsync(id)).ReturnsAsync(true);

        //     mockCustomerRepo.Setup(repo =>
        //     repo.GetCustomerByIdAsync(id)).ReturnsAsync(new Customer
        //     {
        //         CustomerId = id,
        //         FirstName = "Khotso",
        //         LastName = "Mokhethi"
        //     });
        //     var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

        //     //Act
        //     var result = await controller.UpdateCustomer(id, new CustomerForUpdateDto { });

        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        [Fact]
        public async Task UpdateCustomer_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.UpdateCustomer(id, new CustomerForUpdateDto { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PartialCustomerUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.PartiallyUpdateCustomer(id,
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<CustomerForUpdateDto>
            { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCustomer_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
            mockCustomerRepo.Setup(repo =>
            repo.CustomerIfExistsAsync(id)).ReturnsAsync(true);

            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(new Customer
            {
                CustomerId = id,
                FirstName = "Khotso",
                LastName = "Mokhethi"
            });
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.DeleteCustomer(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCustomer_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {

            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockCustomerRepo.Setup(repo =>
            repo.GetCustomerByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new CustomerController(mockCustomerRepo.Object, mapper, mockMail.Object, mockCartServiceRepo.Object);

            //Act
            var result = await controller.DeleteCustomer(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}