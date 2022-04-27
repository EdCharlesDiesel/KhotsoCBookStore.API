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
using StarPeaceAdminHub.Models.Books;
using StarPeaceAdminHub.Queries;
using StarPeaceAdminHubDomain.IRepositories;

namespace StarPeaceAdminHub.Web.Controllers
{
    [Authorize(Roles= "Admins")]
    public class SettingsController: Controller
    {
         public async Task<IActionResult> Index()
         {
             return View();
         }
//          // 1. A controller's action method receives one or more ViewModels and performs validation.
//         [HttpGet]
//         public async Task<IActionResult> Index(
//             // 5. A command handler matching the previous command is retrieved via DI in
//             // the controller action method (through the[FromServices]
//              [FromServices] IBookListQuery query)
//         {
//             // var results = await query.Fake();            
//             // var vm = new BooksListViewModel { Items = results };
//             // return View(vm);  
//               return View();          
//         }

//         [HttpGet]
//         public IActionResult Create()
//         {
//             return View("Edit");
//         }

//         // It has a constructor that accepts an IBook aggregate. This way, package data is
//         // copied into the ViewModel that is used to populate the edit view. It implements the
//         // IBookFullEditDTO DTO interface defined in the domain layer. This way, it can be
//         // directly used to send IBook updates to the domain layer.
//         [HttpPost]
//         public async Task<IActionResult> Create(
//             BookFullEditViewModel vm,
//             [FromServices] ICommandHandler<CreateBookCommand> command)
//         {
//             if (ModelState.IsValid) { 
//                 await command.HandleAsync(new CreateBookCommand(vm));
//                 return RedirectToAction(
//                     nameof(ManageBooksController.Index));
//             }
//             else
//                 return View("Edit", vm);
//         }
//         [HttpGet]
//         public async Task<IActionResult> Edit(
//             int id,
//             [FromServices] IBookRepository repo)
//         {
//             if (id == 0) return RedirectToAction(
//                 nameof(ManageBooksController.Index));
//             var aggregate = await repo.Get(id);
//             if (aggregate == null) return RedirectToAction(
//                 nameof(ManageBooksController.Index));
//             var vm = new BookFullEditViewModel(aggregate);
//             return View(vm);
//         }
//         [HttpPost]
//         public async Task<IActionResult> Edit(
//             BookFullEditViewModel vm,
//             [FromServices] ICommandHandler<UpdateBookCommand> command)
//         {
//             if (ModelState.IsValid)
//             {
//                 await command.HandleAsync(new UpdateBookCommand(vm));
//                 return RedirectToAction(
//                     nameof(ManageBooksController.Index));
//             }
//             else
//                 return View(vm);
//         }

//         [HttpGet]
//         public async Task<IActionResult> Delete(
//             int id,
//             [FromServices] ICommandHandler<DeleteBookCommand> command)
//         {
//             if (id>0)
//             {
//                 await command.HandleAsync(new DeleteBookCommand(id));
                
//             }
//             return RedirectToAction(
//                     nameof(ManageBooksController.Index));
//         }
     }
 }