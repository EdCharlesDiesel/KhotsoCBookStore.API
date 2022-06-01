using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using KhotsoCBookStore.API.Exceptions;
using KhotsoCBookStore.API.Queries;
using KhotsoCBookStore.API.Models.Authors;
using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Commands;
using Microsoft.AspNetCore.JsonPatch;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetAuthorsAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get all authors resources.
        /// </summary>
        /// <returns>An AuthorsListViewModel of authors</returns>
        /// <response code="200">Returns the requested authors.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<AuthorsListViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAuthors([FromServices] IAuthorsListQuery query)
        {
            try
            {
                var results = await query.GetAllAuthors();
                var vm = new AuthorsListViewModel { Authors = results };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (AuthorNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No authors were found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }


        /// <summary>
        /// Get a single author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="201">Returns the requested employes.</response>
        [HttpGet("{authorId}", Name = "GetAuthor")]
        [ProducesResponseType(typeof(IEnumerable<AuthorInfosViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAuthorById([FromServices] IAuthorQuery query, int authorId)
        {
            try
            {
                var results = await query.GetAuthorById(authorId);
                var vm = new AuthorInfosViewModel
                {
                    Id = results.Id,
                    FirstName = results.FirstName,
                    // LastName = results.LastName,
                    BookStartPrice = results.BookStartPrice,
                    StartPublishingDate = results.StartPublishingDate,
                    EndPublishingDate = results.EndPublishingDate
                };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (AuthorNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No author was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        // /// <summary>
        // /// Create an author resource.
        // /// </summary>
        // /// <returns>A new author which is just created</returns>
        // /// <response code="201">Returns the created author.</response>
        // [HttpPost()]
        // [ProducesResponseType(typeof(AuthorFullEditViewModel), 201)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<ActionResult> CreateAuthor(AuthorFullEditViewModel vm, [FromServices] ICommandHandler<CreateAuthorCommand> command)
        // {
        //     try
        //     {

        //         // await command.HandleAsync(new CreateAuthorCommand(vm));

        //         // return CreatedAtRoute("GetAuthor",
        //         //         new { authorId = vm.Id },
        //         //         vm);
        //         throw new NotImplementedException();

        //     }
        //     catch (AuthorNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No author was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }

        // /// <summary>
        // /// Update author resource by authorId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="204">Returns no content.</response>
        // [HttpPut("{authorId}")]
        // [ProducesResponseType(typeof(AuthorFullEditViewModel), 204)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(500)]
        // public async Task<ActionResult> UpdateAuthor(AuthorFullEditViewModel vm
        //     // ,
        //     //     [FromServices] ICommandHandler<UpdateAuthorCommand> command

        //     )
        // {
        //     try
        //     {

        //         // await command.HandleAsync(new CreateAuthorCommand(vm));

        //         // return CreatedAtRoute("GetAuthor",
        //         //         new { authorId = vm.Id },
        //         //         vm);await command.HandleAsync(new UpdateAuthorCommand(vm)); 
        //         return NoContent();
        //         throw new NotImplementedException();

        //     }
        //     catch (AuthorNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No author was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }

        // /// <summary>
        // /// Partial update author resource by authorId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="200">Returns no content.</response>
        // [HttpPatch("{authorId}")]
        // [ProducesResponseType(typeof(AuthorFullEditViewModel), 204)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(405)]
        // public async Task<ActionResult> PartiallyUpdateAuthor(Guid authorId,
        //     JsonPatchDocument<AuthorForUpdateDto> patchDocument)
        // {

        //     try
        //     {
        //         //      if (!ModelState.IsValid)
        //         //             {
        //         //                 return BadRequest(ModelState);
        //         //             }

        //         //             if (!TryValidateModel(authorToPatch))
        //         //             {
        //         //                 return BadRequest(ModelState);
        //         //             }
        //         //             await command.HandleAsync(new UpdateAuthorCommand(vm));
        //         // //                 return RedirectToAction(
        //         // //                     nameof(ManageAuthorsController.Index));
        //         //             //patchDocument.ApplyTo(authorToPatch, ModelState);
        //         //             patchDocument.ApplyTo(authorToPatch);
        //         // await command.HandleAsync(new CreateAuthorCommand(vm));

        //         // return CreatedAtRoute("GetAuthor",
        //         //         new { authorId = vm.Id },
        //         //         vm);await command.HandleAsync(new UpdateAuthorCommand(vm)); 
        //         // return NoContent();
        //         throw new NotImplementedException();

        //     }
        //     catch (AuthorNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No author was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }

        // /// <summary>
        // /// Delete a single author resource by authorId.
        // /// </summary>
        // /// <returns>An ActionResult</returns>
        // /// <response code="204">Returns the requested employes.</response>
        // [HttpDelete("{authorId}")]
        // [ProducesResponseType(typeof(AuthorFullEditViewModel), 204)]
        // [ProducesResponseType(404)]
        // [ProducesResponseType(400)]
        // public async Task<ActionResult> DeleteAuthor(int authorId
        // // , [FromServices] ICommandHandler<DeleteAuthorCommand> command
        // )
        // {
        //     try
        //     {
        //         // if (authorId>0)
        //         // {
        //         //     await command.HandleAsync(new DeleteAuthorCommand(authorId));

        //         // }
        //         // return RedirectToAction(
        //         //         nameof(ManageAuthorsController.Index));

        //         // //  _mailService.Send(
        //         // //      "Author deleted.",
        //         // //   $"Author named {authorEntity.FirstName} with id {authorEntity.AuthorId} was deleted.");

        //         // return NoContent();
        //         throw new NotImplementedException();
        //     }
        //     catch (AuthorNotFoundException)
        //     {
        //         return StatusCode((int)HttpStatusCode.BadRequest, "No author was found in the database");
        //     }
        //     catch (Exception)
        //     {
        //         return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
        //     }
        // }
    }
}
