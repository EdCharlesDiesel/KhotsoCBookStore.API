using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
     [Produces("application/json")]
    [Route("api/[controller]")]
    public class MemberOrderController : Controller
    {

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetMemberOrdersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        // /// <summary>
        // /// Get all memberOrders resources.
        // /// </summary>
        // /// <returns>An MemberOrdersListViewModel of memberOrders</returns>
        // /// <response code="200">Returns the requested memberOrders.</response>
        // [HttpGet()]
        // [ProducesResponseType(typeof(IEnumerable<MemberOrdersListViewModel>), 200)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetMemberOrders([FromServices] IMemberOrdersListQuery query)
        // {
        //     try
        //     {
        //         var results = await query.GetAllMemberOrders();
        //         var vm = new MemberOrdersListViewModel { MemberOrders = results };
        //         return StatusCode((int)HttpStatusCode.OK, vm);
        //     }
        //     catch (MemberOrderNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.NotFound, "No memberOrders were found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }


        // /// <summary>
        // /// Get a single memberOrder resource by memberOrderId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="201">Returns the requested employes.</response>
        // [HttpGet("{memberOrderId}", Name = "GetMemberOrder")]
        // [ProducesResponseType(typeof(IEnumerable<MemberOrderInfosViewModel>), 200)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetMemberOrderById([FromServices] IMemberOrderQuery query, int memberOrderId)
        // {
        //     try
        //     {
        //         var results = await query.GetMemberOrderById(memberOrderId);
        //         var vm = new MemberOrderInfosViewModel
        //         {
        //             Id = results.Id,
        //             FirstName = results.FirstName,
        //             // LastName = results.LastName,
        //             BookStartPrice = results.BookStartPrice,
        //             StartPublishingDate = results.StartPublishingDate,
        //             EndPublishingDate = results.EndPublishingDate
        //         };
        //         return StatusCode((int)HttpStatusCode.OK, vm);
        //     }
        //     catch (MemberOrderNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.NotFound, "No memberOrder was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }

        // /// <summary>
        // /// Create an memberOrder resource.
        // /// </summary>
        // /// <returns>A new memberOrder which is just created</returns>
        // /// <response code="201">Returns the created memberOrder.</response>
        // [HttpPost()]
        // [ProducesResponseType(typeof(MemberOrderFullEditViewModel), 201)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<ActionResult> CreateMemberOrder(MemberOrderFullEditViewModel vm, [FromServices] ICommandHandler<CreateMemberOrderCommand> command)
        // {
        //     try
        //     {

        //         await command.HandleAsync(new CreateMemberOrderCommand(vm));

        //         return CreatedAtRoute("GetMemberOrder",
        //                 new { memberOrderId = vm.Id },
        //                 vm);
        //         // throw new NotImplementedException();

        //     }
        //     catch (MemberOrderNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No memberOrder was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }

        // }

        // /// <summary>
        // /// Update memberOrder resource by memberOrderId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="204">Returns no content.</response>
        // [HttpPut("{memberOrderId}")]
        // [ProducesResponseType(typeof(MemberOrderFullEditViewModel), 204)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> Edit(
        //     int memberOrderId,
        //     [FromServices] IMemberOrderRepository repo, MemberOrderFullEditViewModel vm,
        //     [FromServices] ICommandHandler<UpdateMemberOrderCommand> command)
        // {
        //     try
        //     {
        //         var aggregate = await repo.Get(memberOrderId);
        //         if (aggregate == null) return NotFound();


        //         var viewModel = new MemberOrderFullEditViewModel(aggregate);
        //         await command.HandleAsync(new UpdateMemberOrderCommand(vm));
        //         return NoContent();
        //     }
        //     catch (MemberOrderNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No memberOrder was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }

        // }

        // /// <summary>
        // /// Partial update memberOrder resource by memberOrderId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="200">Returns no content.</response>
        // [HttpPatch("{memberOrderId}")]
        // [ProducesResponseType(typeof(MemberOrderFullEditViewModel), 204)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(405)]
        // public async Task<ActionResult> PartiallyUpdateMemberOrder(Guid memberOrderId,
        //     JsonPatchDocument<MemberOrderForUpdateDto> patchDocument)
        // {
        //     try
        //     {
        //         // await command.HandleAsync(new UpdateMemberOrderCommand(vm));
        //         // return RedirectToAction(
        //         // nameof(ManageMemberOrdersController.Index));      

        //         //         patchDocument.ApplyTo(memberOrderToPatch);
        //         //          if (!ModelState.IsValid)
        //         // {
        //         //     return BadRequest(ModelState);
        //         // }

        //         // if (!TryValidateModel(memberOrderToPatch))
        //         // {
        //         //     return BadRequest(ModelState);
        //         // }

        //         throw new NotImplementedException();
        //     }
        //     catch (MemberOrderNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No memberOrder was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }


        // /// <summary>
        // /// Delete a single memberOrder resource by memberOrderId.
        // /// </summary>
        // /// <returns>An ActionResult</returns>
        // /// <response code="204">Returns the requested employes.</response>
        // [HttpDelete("{memberOrderId}")]
        // [ProducesResponseType(204)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> DeleteMemberOrder(
        //     int memberOrderId,
        //     [FromServices] ICommandHandler<DeleteMemberOrderCommand> command)
        // {
        //     try
        //     {
        //         if (memberOrderId > 0)
        //         {
        //             await command.HandleAsync(new DeleteMemberOrderCommand(memberOrderId));
        //         }
        //         // return RedirectToAction(
        //         //         nameof(ManageMemberOrdersController.Index));
        //         return NoContent();
        //     }
        //     catch (MemberOrderNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No memberOrder was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }
    }
}
