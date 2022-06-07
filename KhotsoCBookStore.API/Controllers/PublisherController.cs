using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Commands;
using KhotsoCBookStore.API.Exceptions;
using KhotsoCBookStore.API.Models.Books;
using KhotsoCBookStore.API.Models.Publishers;
using KhotsoCBookStore.API.Queries;
using Microsoft.AspNetCore.Mvc;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;


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
        /// <response code="200">Returns the list of all requests allowed on this end-point.</response>
        [HttpOptions]
        public IActionResult GetPublishersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get all publishers resources.
        /// </summary>
        /// <returns>An PublishersListViewModel of publishers</returns>
        /// <response code="200">Returns the requested publishers.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<PublishersListViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPublishers([FromServices] IPublishersListQuery query)
        {
            try
            {
                var results = await query.GetAllPublishers();
                var vm = new PublishersListViewModel { AllPublishers = results };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (PublisherNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No publishers were found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Get a single publisher resource by publisherId.
        /// </summary>
        /// <returns>An PublisherInfosViewModel of a single publisher</returns>
        /// <response code="200">Returns a requested publisher.</response>
        [HttpGet("{publisherId}", Name = "GetPublisher")]
        [ProducesResponseType(typeof(IEnumerable<PublisherInfosViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPublisherById([FromServices] IPublishersListQuery query, int publisherId)
        {
            try
            {
                var results = await query.GetPublisherById(publisherId);
                var vm = new PublisherInfosViewModel
                {
                   // Id = results.Id,
                    PublisherId = results.PublisherId,
                    CompanyName = results.CompanyName,
                    ContactName = results.ContactName,
                    ContactTitle = results.ContactTitle,
                    Address = results.Address,
                    City = results.City,
                    Region = results.Region,
                    PostalCode = results.PostalCode,
                    Country = results.Country,
                    Phone = results.Phone,
                    Fax = results.Fax,
                    HomePage = results.HomePage

                };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (PublisherNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No publisher was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Create an publisher resource.
        /// </summary>
        /// <returns>A new publisher which is just created</returns>
        /// <response code="201">Returns the created publisher.</response>
        [HttpPost()]
        [ProducesResponseType(typeof(PublisherFullEditViewModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreatePublisher(PublisherFullEditViewModel vm, [FromServices] ICommandHandler<CreatePublisherCommand> command)
        {
            try
            {
                await command.HandleAsync(new CreatePublisherCommand(vm));
                return CreatedAtRoute("GetPublisher", new { publisherId = vm.PublisherId }, vm);
            }
            catch (CouldNotAddPublisherToDatabaseException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured while adding please validate with the schema");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Update publisher resource by publisherId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="204">Returns no content.</response>
        [HttpPut("{publisherId}")]
        [ProducesResponseType(typeof(PublisherFullEditViewModel), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePublisher(
            int publisherId,
            [FromServices] IPublisherRepository repo, PublisherFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdatePublisherCommand> command)
        {
            try
            {
                var aggregate = await repo.Get(publisherId);
                if (aggregate == null) return NotFound();

                var viewModel = new PublisherFullEditViewModel(aggregate);
                await command.HandleAsync(new UpdatePublisherCommand(vm));
                return NoContent();
            }
            catch (PublisherNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }

        }

        /// <summary>
        /// Delete a single publisher resource by publisherId.
        /// </summary>
        /// <returns>An ActionResult</returns>
        /// <response code="204">Returns the requested publishers.</response>
        [HttpDelete("{publisherId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePublisher(
            int publisherId,
            [FromServices] ICommandHandler<DeletePublisherCommand> command)
        {
            try
            {
                if (publisherId > 0)
                {
                    await command.HandleAsync(new DeletePublisherCommand(publisherId));
                }

                return NoContent();
            }
            catch (PublisherNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "No publisher was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }
    }
}
