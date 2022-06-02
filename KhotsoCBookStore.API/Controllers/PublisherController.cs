using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetPublishersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        // /// <summary>
        // /// Get all publishers resources.
        // /// </summary>
        // /// <returns>An PublishersListViewModel of publishers</returns>
        // /// <response code="200">Returns the requested publishers.</response>
        // [HttpGet()]
        // [ProducesResponseType(typeof(IEnumerable<PublishersListViewModel>), 200)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetPublishers([FromServices] IPublishersListQuery query)
        // {
        //     try
        //     {
        //         var results = await query.GetAllPublishers();
        //         var vm = new PublishersListViewModel { Publishers = results };
        //         return StatusCode((int)HttpStatusCode.OK, vm);
        //     }
        //     catch (PublisherNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.NotFound, "No publishers were found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }


        // /// <summary>
        // /// Get a single publisher resource by publisherId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="201">Returns the requested employes.</response>
        // [HttpGet("{publisherId}", Name = "GetPublisher")]
        // [ProducesResponseType(typeof(IEnumerable<PublisherInfosViewModel>), 200)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> GetPublisherById([FromServices] IPublisherQuery query, int publisherId)
        // {
        //     try
        //     {
        //         var results = await query.GetPublisherById(publisherId);
        //         var vm = new PublisherInfosViewModel
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
        //     catch (PublisherNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.NotFound, "No publisher was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }

        // /// <summary>
        // /// Create an publisher resource.
        // /// </summary>
        // /// <returns>A new publisher which is just created</returns>
        // /// <response code="201">Returns the created publisher.</response>
        // [HttpPost()]
        // [ProducesResponseType(typeof(PublisherFullEditViewModel), 201)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<ActionResult> CreatePublisher(PublisherFullEditViewModel vm, [FromServices] ICommandHandler<CreatePublisherCommand> command)
        // {
        //     try
        //     {

        //         await command.HandleAsync(new CreatePublisherCommand(vm));

        //         return CreatedAtRoute("GetPublisher",
        //                 new { publisherId = vm.Id },
        //                 vm);
        //         // throw new NotImplementedException();

        //     }
        //     catch (PublisherNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No publisher was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }

        // }

        // /// <summary>
        // /// Update publisher resource by publisherId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="204">Returns no content.</response>
        // [HttpPut("{publisherId}")]
        // [ProducesResponseType(typeof(PublisherFullEditViewModel), 204)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> Edit(
        //     int publisherId,
        //     [FromServices] IPublisherRepository repo, PublisherFullEditViewModel vm,
        //     [FromServices] ICommandHandler<UpdatePublisherCommand> command)
        // {
        //     try
        //     {
        //         var aggregate = await repo.Get(publisherId);
        //         if (aggregate == null) return NotFound();


        //         var viewModel = new PublisherFullEditViewModel(aggregate);
        //         await command.HandleAsync(new UpdatePublisherCommand(vm));
        //         return NoContent();
        //     }
        //     catch (PublisherNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No publisher was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }

        // }

        // /// <summary>
        // /// Partial update publisher resource by publisherId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="200">Returns no content.</response>
        // [HttpPatch("{publisherId}")]
        // [ProducesResponseType(typeof(PublisherFullEditViewModel), 204)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(405)]
        // public async Task<ActionResult> PartiallyUpdatePublisher(Guid publisherId,
        //     JsonPatchDocument<PublisherForUpdateDto> patchDocument)
        // {
        //     try
        //     {
        //         // await command.HandleAsync(new UpdatePublisherCommand(vm));
        //         // return RedirectToAction(
        //         // nameof(ManagePublishersController.Index));      

        //         //         patchDocument.ApplyTo(publisherToPatch);
        //         //          if (!ModelState.IsValid)
        //         // {
        //         //     return BadRequest(ModelState);
        //         // }

        //         // if (!TryValidateModel(publisherToPatch))
        //         // {
        //         //     return BadRequest(ModelState);
        //         // }

        //         throw new NotImplementedException();
        //     }
        //     catch (PublisherNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No publisher was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }


        // /// <summary>
        // /// Delete a single publisher resource by publisherId.
        // /// </summary>
        // /// <returns>An ActionResult</returns>
        // /// <response code="204">Returns the requested employes.</response>
        // [HttpDelete("{publisherId}")]
        // [ProducesResponseType(204)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<IActionResult> DeletePublisher(
        //     int publisherId,
        //     [FromServices] ICommandHandler<DeletePublisherCommand> command)
        // {
        //     try
        //     {
        //         if (publisherId > 0)
        //         {
        //             await command.HandleAsync(new DeletePublisherCommand(publisherId));
        //         }
        //         // return RedirectToAction(
        //         //         nameof(ManagePublishersController.Index));
        //         return NoContent();
        //     }
        //     catch (PublisherNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No publisher was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }
    }
}
