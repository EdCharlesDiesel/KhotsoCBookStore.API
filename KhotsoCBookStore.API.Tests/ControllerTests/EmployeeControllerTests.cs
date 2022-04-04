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
    public class EmployeeControllerTests : IDisposable
    {
        Mock<IEmployeeService> mockRepo;
        Mock<IMailService> mockMail;
        EmployeeMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public EmployeeControllerTests()
        {
            mockRepo = new Mock<IEmployeeService>();
            mockMail = new Mock<IMailService>();
            realProfile = new EmployeeMappingProfile();
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

        private List<Employee> GetEmployeesTest(int num)
        {
            var employees = new List<Employee>();
            if (num > 0)
            {
                employees.Add(new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = "Charles",
                    LastName = "Mokhethi",
                    DateOfStartEmployment = DateTime.Now,
                    EmployeeNumber = "EMP-007",
                    DateOfBirth = DateTime.Today
                });
            }
            return employees;
        }

        //[Fact]
        // public void GetEmployeesAPIOptions_All_ActionsAvailable()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(() => null);

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = controller.GetEmployeesAPIOptions();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result);

        // }

        // [Fact]
        // public async Task GetEmployeeItems_Returns200OK_WhenDBIsEmpty()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(() => null);


        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetEmployees();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);

        // }

        // [Fact]
        // public async Task GetAllEmployees_ReturnsOneItem_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(new List<EmployeeDto>
        //    {
        //     new EmployeeDto{
        //         EmployeeId = Guid.NewGuid(),
        //         FirstName = "Charles",
        //         LastName = "Mokhethi",
        //         DateOfStartEmployment = DateTime.Now,
        //         EmployeeNumber ="EMP-007"
        //     }
        //       });

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act            
        //     var result = await controller.GetEmployees();

        //     //Assert
        //     var okResult = result.Result as OkObjectResult;
        //     var employees = okResult.Value as List<EmployeeDto>;
        //     Assert.Single(employees);
        // }

        // [Fact]
        // public async Task GetAllEmployees_Returns200OK_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(new List<EmployeeDto>
        //     {
        //         new EmployeeDto{
        //             EmployeeId = Guid.NewGuid(),
        //             FirstName = "Charles",
        //             LastName = "Mokhethi",
        //             DateOfStartEmployment = DateTime.Now,
        //             EmployeeNumber ="EMP-007"
        //         }});

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetEmployees();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetAllEmployees_ReturnsCorrectType_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(new List<EmployeeDto>
        //     {
        //         new EmployeeDto{
        //             EmployeeId = Guid.NewGuid(),
        //             FirstName = "Charles",
        //             LastName = "Mokhethi",
        //             DateOfStartEmployment = DateTime.Now,
        //             EmployeeNumber ="EMP-007"
        //     }});

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetEmployees();

        //     //Assert
        //     Assert.IsType<ActionResult<IEnumerable<EmployeeDto>>>(result);
        // }

        // [Fact]
        // public async Task GetEmployeeByID_Returns404NotFound_WhenNonExistentIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("00000000-0000-0000-0000-000000000000");
        //     mockRepo.Setup(repo =>
        //     repo.GetEmployeeByIdAsync(id)).ReturnsAsync(new Employee
        //     {
        //         EmployeeId = id,
        //         FirstName = "",
        //         LastName = "",
        //         DateOfStartEmployment = DateTime.Now,
        //         EmployeeNumber = ""
        //     });

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetEmployee(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetEmployeeByID_Returns200OK__WhenValidIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(new List<EmployeeDto>
        //     {
        //         new EmployeeDto{
        //             EmployeeId = id,
        //             FirstName = "Charles",
        //             LastName = "Mokhethi",
        //             DateOfStartEmployment = DateTime.Now,
        //             EmployeeNumber ="EMP-007",
        //             DateOfEndEmployment = DateTime.Now
        //     }});


        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetEmployee(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetEmployeeByID_Returns200OK__WhenValidIDProvided_()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAllEmployeesAync()).ReturnsAsync(new List<EmployeeDto>
        //     {
        //         new EmployeeDto{
        //             EmployeeId = id,
        //             FirstName = "Charles",
        //             LastName = "Mokhethi",
        //             DateOfStartEmployment = DateTime.Now,
        //             EmployeeNumber ="EMP-007"
        //     }});

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetEmployee(id);

        //     //Assert
        //     Assert.IsType<ActionResult<EmployeeDto>>(result);
        // }

        // [Fact]
        // public async Task CreateEmployee_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetEmployeeByIdAsync(id)).ReturnsAsync(new Employee
        //     {
        //         EmployeeId = id,
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi",
        //         EmployeeNumber = "EMP:885"
        //     });

        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.CreateEmployee(new EmployeeForCreateDto { });

        //     //Assert
        //     Assert.IsType<ActionResult<EmployeeForCreateDto>>(result);
        // }

        // [Fact]
        // public async Task CreateEmployee_Returns201Created_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //    repo.GetEmployeeByIdAsync(id)).ReturnsAsync(() => null);


        //     var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.CreateEmployee(new EmployeeForCreateDto
        //     {
        //         FirstName = "Khotso",
        //         LastName = "Mokhethi",
        //         EmployeeNumber = "EMP:002",
        //         DateOfBirth = DateTime.Now,
        //         DateOfStartEmployment = DateTime.Today
        //     });

        //     //Assert
        //     Assert.IsType<ActionResult<EmployeeForCreateDto>>(resCreateEmployee_ReturnsCorrectResourceType_WhenValidObjectSubmittedult);
        // }

        [Fact]
        public async Task UpdateEmployee_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
            mockRepo.Setup(repo =>
            repo.EmployeeIfExistsAsync(id)).ReturnsAsync(true);

            mockRepo.Setup(repo =>
            repo.GetEmployeeByIdAsync(id)).ReturnsAsync(new Employee
            {
                EmployeeId = id,
                FirstName = "Charles",
                LastName = "Mokhrthi",
                EmployeeNumber = "EMP:885"
            });

            var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.UpdateEmployee(id, new EmployeeForUpdateDto { });

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateEmployee_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
            mockRepo.Setup(repo =>
            repo.GetEmployeeByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);


            //Act
            var result = await controller.UpdateEmployee(id, new EmployeeForUpdateDto { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PartialEmployeeUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
            mockRepo.Setup(repo =>
            repo.GetEmployeeByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.PartiallyUpdateEmployee(id,
            new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<EmployeeForUpdateDto>
            { });

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
            mockRepo.Setup(repo =>
            repo.EmployeeIfExistsAsync(id)).ReturnsAsync(true);

            mockRepo.Setup(repo =>

           repo.GetEmployeeByIdAsync(id)).ReturnsAsync(new Employee
           {
               EmployeeId = id,
               FirstName = "Charles",
               LastName = "Mokhrthi",
               EmployeeNumber = "EMP:885"
           });

            var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.DeleteEmployee(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteEmployee_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        {
            //Arrange
            var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
            mockRepo.Setup(repo =>
            repo.GetEmployeeByIdAsync(id)).ReturnsAsync(() => null);
            var controller = new EmployeeController(mockRepo.Object, mapper, mockMail.Object);

            //Act
            var result = await controller.DeleteEmployee(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}