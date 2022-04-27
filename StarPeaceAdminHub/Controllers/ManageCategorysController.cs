using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHub.Models;
using StarPeaceAdminHub.Models.Categorys;
using StarPeaceAdminHub.Queries;
using StarPeaceAdminHubDomain.IRepositories;

namespace StarPeaceAdminHub.Controllers
{
    [Authorize(Roles= "Admins")]
    public class ManageCategorysController : Controller
    {
        // 1. A controller's action method receives one or more ViewModels and performs validation.
        [HttpGet]
        public async Task<IActionResult> Index(
            // 5. A command handler matching the previous command is retrieved via DI in
            // the controller action method (through the[FromServices]
            [FromServices] ICategorysListQuery query)
        {
            var results = await query.GetAllCategorys();
            var vm = new CategorysListViewModel { Items = results };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            CategoryFullEditViewModel vm,
            [FromServices] ICommandHandler<CreateCategoryCommand> command)
        {
            if (ModelState.IsValid) { 
                await command.HandleAsync(new CreateCategoryCommand(vm));
                return RedirectToAction(
                    nameof(ManageCategorysController.Index));
            }
            else
                return View("Edit", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(
            int id,
            [FromServices] ICategoryRepository repo)
        {
            if (id == 0) return RedirectToAction(
                nameof(ManageCategorysController.Index));
            var aggregate = await repo.Get(id);
            if (aggregate == null) return RedirectToAction(
                nameof(ManageCategorysController.Index));
            var vm = new CategoryFullEditViewModel(aggregate);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(
            CategoryFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdateCategoryCommand> command)
        {
            if (ModelState.IsValid)
            {
                await command.HandleAsync(new UpdateCategoryCommand(vm));
                return RedirectToAction(
                    nameof(ManageCategorysController.Index));
            }
            else
                return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(
            int id,
            [FromServices] ICommandHandler<DeleteCategoryCommand> command)
        {
            if (id>0)
            {
                await command.HandleAsync(new DeleteCategoryCommand(id));
                
            }
            return RedirectToAction(
                    nameof(ManageCategorysController.Index));
        }
    }
}
