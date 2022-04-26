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
    public class ManageBooksController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ICategorysListQuery query)
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
                    nameof(ManageBooksController.Index));
            }
            else
                return View("Edit", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(
            Guid id,
            [FromServices] ICategoryRepository repo)
        {
            if (id == Guid.Empty) return RedirectToAction(
                nameof(ManageBooksController.Index));
            var aggregate = await repo.Get(id);
            if (aggregate == null) return RedirectToAction(
                nameof(ManageBooksController.Index));
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
                    nameof(ManageBooksController.Index));
            }
            else
                return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(
            Guid id,
            [FromServices] ICommandHandler<DeleteCategoryCommand> command)
        {
            if (id != Guid.Empty)
            {
                await command.HandleAsync(new DeleteCategoryCommand(id));
                
            }
            return RedirectToAction(
                    nameof(ManageBooksController.Index));
        }
    }
}
