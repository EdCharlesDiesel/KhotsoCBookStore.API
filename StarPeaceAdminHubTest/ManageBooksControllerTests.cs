using System;
using Xunit;
using StarPeaceAdminHub.Controllers;
using StarPeaceAdminHub.Models.Books;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using StarPeaceAdminHub.Commands;
using System.Linq;

namespace StarPeaceAdminHubTest
{
    public class ManageBooksControllerTests
    {
        [Fact]
        public async Task DeletePostValidationFailedTest()
        {
            var controller = new ManageBooksController();
            controller.ModelState
                .AddModelError("Name", "fake error");
            var vm = new BookFullEditViewModel();
            var result = await controller.Edit(vm, null);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(vm, viewResult.Model);
        }
        [Fact]
        public async Task DeletePostSuccessTest()
        {
            var controller = new ManageBooksController();
            var commandDependency =
                new Mock<ICommandHandler<UpdateBookCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<UpdateBookCommand>()))
                .Returns(Task.CompletedTask);
            var vm = new BookFullEditViewModel();

            var result = await controller.Edit(vm, 
                commandDependency.Object);
                commandDependency.Verify(m => m.HandleAsync(
                It.IsAny<UpdateBookCommand>()), 
                Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
             
            Assert.Equal(nameof(ManageBooksController.Index), 
                redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
        }
    }
}
