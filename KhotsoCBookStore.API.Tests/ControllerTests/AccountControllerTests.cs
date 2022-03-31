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
    public class AccountControllerTests : IDisposable
    {
        Mock<IAccountService> mockRepo;
        Mock<IMailService> mockMail;
        AccountMappingProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        public AccountControllerTests()
        {
            mockRepo = new Mock<IAccountService>();
            mockMail = new Mock<IMailService>();
            realProfile = new AccountMappingProfile();
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

        // private List<Account> GetAccountsTest(int num)
        // {
        //     var Accounts = new List<Account>();
        //     if (num > 0)
        //     {
        //         Accounts.Add(new Account
        //         {
        //             AccountId = Guid.NewGuid(),
        //             FirstName = "Charles",
        //             LastName = "Mokhethi"
        //         });
        //     }
        //     return  Accounts;
        // }

        // [Fact]
        // public async Task GetAccountItems_Returns200OK_WhenDBIsEmpty()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllAccountsAync()).ReturnsAsync(() => null);


        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetAccounts();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);

        // }

        // [Fact]
        // public async Task  GetAllAccounts_ReturnsOneItem_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllAccountsAync()).ReturnsAsync(GetAccountsTest(1));
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act            
        //     var result = await controller.GetAccounts();

        //     //Assert
        //     var okResult = result.Result as OkObjectResult;
        //     var Accounts = okResult.Value as List<AccountDto>;
        //     Assert.Single(Accounts);
        // }

        // [Fact]
        // public async Task GetAllAccounts_Returns200OK_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllAccountsAync()).ReturnsAsync(GetAccountsTest(1));
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result =await  controller.GetAccounts();

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetAllAccounts_ReturnsCorrectType_WhenDBHasOneResource()
        // {
        //     //Arrange
        //     mockRepo.Setup(repo =>
        //     repo.GetAllAccountsAync()).ReturnsAsync(GetAccountsTest(1));
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result =await  controller.GetAccounts();

        //     //Assert
        //     Assert.IsType<ActionResult<IEnumerable<AccountDto>>>(result);
        // }

        // [Fact]
        // public async Task GetAccountByID_Returns404NotFound_WhenNonExistentIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("00000000-0000-0000-0000-000000000000");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync( new Account
        //     {
                
        //     });

        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetAccountById(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetAccountByID_Returns200OK__WhenValidIDProvided()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(new Account
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetAccountById(id);

        //     //Assert
        //     Assert.IsType<OkObjectResult>(result.Result);
        // }

        // [Fact]
        // public async Task GetAccountByID_Returns200OK__WhenValidIDProvided_()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52D55B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(new Account
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.GetAccountById(id);

        //     //Assert
        //     Assert.IsType<ActionResult<AccountDto>>(result);
        // }

        // [Fact]
        // public async Task CreateAccount_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-40A0-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(new Account
        //     {
        //         AccountId = id,
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.CreateAccount(new AccountForCreateDto { });

        //     //Assert
        //     //Assert.IsType<ActionResult<AccountDto>>(result);
        //     Assert.IsType<CreatedAtRouteResult>(result);
        // }

        // [Fact]
        // public async Task CreateAccount_Returns201Created_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4242D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(new Account
        //     {
        //         FirstName = "Charles",
        //         LastName = "Mokhrthi"
        //     });

        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.CreateAccount(new AccountForCreateDto { });

        //     //Assert
        //     Assert.IsType<CreatedAtRouteResult>(result);
        // }

        // [Fact]
        // public async Task UpdateAccount_Returns204NoContent_WhenValidObjectSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52888B4278D6");
        //     mockRepo.Setup(repo =>
        //     repo.AccountIfExistsAsync(id)).ReturnsAsync(true);

        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(new Account
        //     {
        //         AccountId= id,
        //         FirstName ="Khotso",
        //         LastName = "Mokhethi"
        //     });

        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.UpdateAccount(id, new AccountForUpdateDto { });

        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        // [Fact]
        // public async Task UpdateAccount_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("687F030A-8566-0025-95F5-52888B4278D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(() => null);
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);


        //     //Act
        //     var result = await controller.UpdateAccount(id, new AccountForUpdateDto { });

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result);
        // }

        // [Fact]
        // public async Task PartialAccountUpdate_Returns404NotFound_WhenNonExistentResourceIDSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("687F030A-8566-0025-36F5-52888B427847");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(() => null);
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.PartiallyUpdateAccount(id,
        //     new Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<AccountForUpdateDto>
        //     { });

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result);
        // }

        // [Fact]
        // public async Task DeleteAccount_Returns204NoContent_WhenValidResourceIDSubmitted()
        // {
        //     //Arrange
        //     var id = new Guid("78f4c5ec-68cb-41bb-4111-08da07eaa3cd");
        //     mockRepo.Setup(repo =>
        //     repo.AccountIfExistsAsync(id)).ReturnsAsync(true);

        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(new Account
        //     {
        //         AccountId= id,
        //         FirstName ="Khotso",
        //         LastName = "Mokhethi"
        //     });

            
                
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);
            
        //     //Act
        //     var result = await controller.DeleteAccount(id);
            
        //     //Assert
        //     Assert.IsType<NoContentResult>(result);
        // }

        // [Fact]
        // public async Task DeleteAccount_Returns_404NotFound_WhenNonExistentResourceIDSubmitted()
        // {

        //     //Arrange
        //     var id = new Guid("300F030A-8566-0025-95F5-52397B4278D6");
        //     mockRepo.Setup(repo =>
        //     repo.GetAccountByIdAsync(id)).ReturnsAsync(() => null);
        //     var controller = new AccountController(mockRepo.Object, mapper, mockMail.Object);

        //     //Act
        //     var result = await controller.DeleteAccount(id);

        //     //Assert
        //     Assert.IsType<NotFoundResult>(result);
        // }
    }
}