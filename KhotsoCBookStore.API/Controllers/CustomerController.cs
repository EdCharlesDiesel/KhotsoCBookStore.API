using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Commands;
using KhotsoCBookStore.API.Exceptions;
using KhotsoCBookStore.API.Models;
using KhotsoCBookStore.API.Models.Books;
using KhotsoCBookStore.API.Queries;
using Microsoft.AspNetCore.Mvc;
using StarPeaceAdminHubDomain.IRepositories;

namespace KhotsoCBookStore.API.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point.</response>
        [HttpOptions]
        public IActionResult GetCustomersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT");
            return Ok();
        }

        /// <summary>
        /// Get all customers resources.
        /// </summary>
        /// <returns>An CustomersListViewModel of customers</returns>
        /// <response code="200">Returns the requested customers.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<CustomersListViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCustomers([FromServices] ICustomersListQuery query)
        {
            try
            {
                var results = await query.GetAllCustomers();
                var vm = new CustomersListViewModel { AllCustomers = results };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (CustomerNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No customers were found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Get a single customer resource by customerId.
        /// </summary>
        /// <returns>An CustomerInfosViewModel of a single customer</returns>
        /// <response code="200">Returns a requested customer.</response>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(IEnumerable<CustomerInfosViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCustomerById([FromServices] ICustomersListQuery query, int customerId)
        {
            try
            {
                var results = await query.GetCustomerById(customerId);
                var vm = new CustomerInfosViewModel
                {
                    CustomerId = results.CustomerId,
                    FirstName = results.FirstName,
                    LastName = results.LastName,
                    DateOfBirth = results.DateOfBirth,
                    IdNumber = results.IdNumber,
                    ContactTitle = results.ContactTitle,
                    Address = results.Address,
                    City = results.City,
                    Region = results.Region,
                    PostalCode = results.PostalCode,
                    Country = results.Country,
                    Phone = results.Phone,

                };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (CustomerNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No customer was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Create an customer resource.
        /// </summary>
        /// <returns>A new customer which is just created</returns>
        /// <response code="201">Returns the created customer.</response>
        [HttpPost()]
        [ProducesResponseType(typeof(CustomerFullEditViewModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateCustomer(CustomerFullEditViewModel vm, [FromServices] ICommandHandler<CreateCustomerCommand> command)
        {
            try
            {
                await command.HandleAsync(new CreateCustomerCommand(vm));
                return CreatedAtRoute("GetCustomer", new { customerId = vm.CustomerId }, vm);
            }
            catch (CouldNotAddCustomerToDatabaseException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured while adding please validate with the schema");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Update customer resource by customerId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="204">Returns no content.</response>
        [HttpPut("{customerId}")]
        [ProducesResponseType(typeof(CustomerFullEditViewModel), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateCustomer(
            int customerId,
            [FromServices] ICustomerRepository repo, CustomerFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdateCustomerCommand> command)
        {
            try
            {
                var aggregate = await repo.Get(customerId);
                if (aggregate == null) return NotFound();

                var viewModel = new CustomerFullEditViewModel(aggregate);
                await command.HandleAsync(new UpdateCustomerCommand(vm));
                return NoContent();
            }
            catch (CustomerNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured while updating please validate with the schema");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }

        }

        /// <summary>
        /// Delete a single customer resource by customerId.
        /// </summary>
        /// <returns>An ActionResult</returns>
        /// <response code="204">Returns no content.</response>
        [HttpDelete("{customerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteCustomer(
            int customerId,
            [FromServices] ICommandHandler<DeleteCustomerCommand> command)
        {
            try
            {
                if (customerId > 0)
                {
                    await command.HandleAsync(new DeleteCustomerCommand(customerId));
                }

                return NoContent();
            }
            catch (CustomerNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No customer was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }
    }
}
