using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KhotsoCBookStore.API.Models.Packages;
using KhotsoCBookStore.API.Queries;
using System.Net;


namespace StarPeaceAdminHub.Controllers
{
    //[Authorize(Roles= "Admins")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ManagePackagesController : ControllerBase
    {
          [HttpGet()]
        public async Task<IActionResult> Allpackages([FromServices] IPackagesListQuery query)
        {
            var results = await query.GetAllPackages();
            var vm = new PackagesListViewModel { Items = results };
            //return View(vm);
            //return Ok(vm);

            return StatusCode((int)HttpStatusCode.OK, vm);
        }
        // [HttpGet]
        // public async Task<IActionResult> Index([FromServices] IPackagesListQuery query)
        // {`
        //     var results = await query.GetAllPackages();
        //     var vm = new PackagesListViewModel { Items = results };
        //     //return View(vm);
        //     //return Ok(vm);

        //     return StatusCode((int)HttpStatusCode.OK, vm);
        // }
        // [HttpGet]
        // public IActionResult Create()
        // {
        //     return View("Edit");
        // }
        // [HttpPost]
        // public async Task<IActionResult> Create(
        //     PackageFullEditViewModel vm,
        //     [FromServices] ICommandHandler<CreatePackageCommand> command)
        // {
        //     if (ModelState.IsValid) { 
        //         await command.HandleAsync(new CreatePackageCommand(vm));
        //         return RedirectToAction(
        //             nameof(ManagePackagesController.Index));
        //     }
        //     else
        //         return View("Edit", vm);
        // }
        // [HttpGet]
        // public async Task<IActionResult> Edit(
        //     int id,
        //     [FromServices] IPackageRepository repo)
        // {
        //     if (id == 0) return RedirectToAction(
        //         nameof(ManagePackagesController.Index));
        //     var aggregate = await repo.Get(id);
        //     if (aggregate == null) return RedirectToAction(
        //         nameof(ManagePackagesController.Index));
        //     var vm = new PackageFullEditViewModel(aggregate);
        //     return View(vm);
        // }
        // [HttpPost]
        // public async Task<IActionResult> Edit(
        //     PackageFullEditViewModel vm,
        //     [FromServices] ICommandHandler<UpdatePackageCommand> command)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         await command.HandleAsync(new UpdatePackageCommand(vm));
        //         return RedirectToAction(
        //             nameof(ManagePackagesController.Index));
        //     }
        //     else
        //         return View(vm);
        // }

        // [HttpGet]
        // public async Task<IActionResult> Delete(
        //     int id,
        //     [FromServices] ICommandHandler<DeletePackageCommand> command)
        // {
        //     if (id>0)
        //     {
        //         await command.HandleAsync(new DeletePackageCommand(id));
                
        //     }
        //     return RedirectToAction(
        //             nameof(ManagePackagesController.Index));
        // }
    }
}
