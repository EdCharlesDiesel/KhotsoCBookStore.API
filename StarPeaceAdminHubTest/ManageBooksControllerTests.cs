using System;
using Xunit;
using StarPeaceAdminHub.Controllers;
using StarPeaceAdminHub.Models.Categorys;
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
            var vm = new CategoryFullEditViewModel();
            var result = await controller.Edit(vm, null);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(vm, viewResult.Model);
        }
        [Fact]
        public async Task DeletePostSuccessTest()
        {
            var controller = new ManageBooksController();
            var commandDependency =
                new Mock<ICommandHandler<UpdateCategoryCommand>>();
            commandDependency
                .Setup(m => m.HandleAsync(It.IsAny<UpdateCategoryCommand>()))
                .Returns(Task.CompletedTask);
            var vm = new CategoryFullEditViewModel();

            var result = await controller.Edit(vm, 
                commandDependency.Object);
                commandDependency.Verify(m => m.HandleAsync(
                It.IsAny<UpdateCategoryCommand>()), 
                Times.Once);
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
             
            Assert.Equal(nameof(ManageBooksController.Index), 
                redirectResult.ActionName);
            Assert.Null(redirectResult.ControllerName);
        }
    }
}
