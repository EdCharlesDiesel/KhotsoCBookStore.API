using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Exceptions;
using Microsoft.AspNetCore.Mvc;

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
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
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
                var vm = new CustomersListViewModel { Customers = results };
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
        public async Task<IActionResult> GetCustomerById([FromServices] ICustomerQuery query, int customerId)
        {
            try
            {
                var results = await query.GetCustomerById(customerId);
                var vm = new CustomerInfosViewModel
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
                return CreatedAtRoute("GetCustomer", new { customerId = vm.Id }, vm);
            }
            catch (CustomerNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
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
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
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
        /// <response code="204">Returns the requested employes.</response>
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
                return StatusCode((int)HttpStatusCode.BadRequest, "No customer was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }
    }
}
