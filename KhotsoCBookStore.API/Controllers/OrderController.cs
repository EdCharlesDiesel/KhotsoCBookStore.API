using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Commands;
using KhotsoCBookStore.API.Exceptions;
using KhotsoCBookStore.API.Models;
using KhotsoCBookStore.API.Queries;
using Microsoft.AspNetCore.Mvc;
using StarPeaceAdminHub.Commands;
using StarPeaceAdminHubDomain.IRepositories;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point.</response>
        [HttpOptions]
        public IActionResult GetOrdersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get all customers resources.
        /// </summary>
        /// <returns>An OrdersListViewModel of customers</returns>
        /// <response code="200">Returns the requested customers.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<OrdersListViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrders([FromServices] IOrdersListQuery query)
        {
            try
            {
                var results = await query.GetAllOrders();
                var vm = new OrdersListViewModel { AllOrders = results };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (OrderNotFoundException)
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
        /// <returns>An OrderInfosViewModel of a single customer</returns>
        /// <response code="200">Returns a requested customer.</response>
        [HttpGet("{customerId}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrderInfosViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOrderById([FromServices] IOrdersListQuery query, int customerId)
        {
            try
            {
                var results = await query.GetOrderById(customerId);
                var vm = new OrderInfosViewModel
                {
                    OrderId = results.OrderId,
                    OrderDate = results.OrderDate,
                    RequiredDate = results.RequiredDate,
                    ShippedDate = results.ShippedDate,
                    ShipVia = results.ShipVia,
                    Freight = results.Freight,
                    ShipName = results.ShipName,
                    ShipAddress = results.ShipAddress,
                    ShipCity = results.ShipCity,
                    ShipRegion = results.ShipRegion,
                    ShipPostalCode = results.ShipPostalCode,
                    ShipCountry = results.ShipCountry

                };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (OrderNotFoundException)
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
        [ProducesResponseType(typeof(OrderFullEditViewModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateOrder(OrderFullEditViewModel vm, [FromServices] ICommandHandler<CreateOrderCommand> command)
        {
            try
            {
                await command.HandleAsync(new CreateOrderCommand(vm));
                return CreatedAtRoute("GetOrder", new { customerId = vm.OrderId }, vm);
            }
            catch (OrderNotFoundException)
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
        [ProducesResponseType(typeof(OrderFullEditViewModel), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateOrder(
            int customerId,
            [FromServices] IOrderRepository repo, OrderFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdateOrderCommand> command)
        {
            try
            {
                var aggregate = await repo.Get(customerId);
                if (aggregate == null) return NotFound();

                var viewModel = new OrderFullEditViewModel(aggregate);
                await command.HandleAsync(new UpdateOrderCommand(vm));
                return NoContent();
            }
            catch (OrderNotFoundException)
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
        public async Task<IActionResult> DeleteOrder(
            int customerId,
            [FromServices] ICommandHandler<DeleteOrderCommand> command)
        {
            try
            {
                if (customerId > 0)
                {
                    await command.HandleAsync(new DeleteOrderCommand(customerId));
                }

                return NoContent();
            }
            catch (OrderNotFoundException)
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
