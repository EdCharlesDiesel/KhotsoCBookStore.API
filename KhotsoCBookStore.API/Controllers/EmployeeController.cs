// using System;
// using System.Collections.Generic;
// using System.Net;
// using System.Threading.Tasks;
// using KhotsoCBookStore.API.Models;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.JsonPatch;
// using Microsoft.AspNetCore.Mvc;

// namespace KhotsoCBookStore.API.Controllers
// {

//     [Produces("application/json")]
//     [Route("api/[controller]")]
//     public class EmployeeController : ControllerBase
//     {
//        /// <summary>
//         /// Get supported resource actions
//         /// </summary>
//         /// <returns>API actions allowed</returns>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the list of all requests allowed on this end-point.</response>
//         [HttpOptions]
//         public IActionResult GetEmployeesAPIOptions()
//         {
//             Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
//             return Ok();
//         }

//         /// <summary>
//         /// Get all employees resources.
//         /// </summary>
//         /// <returns>An EmployeesListViewModel of employees</returns>
//         /// <response code="200">Returns the requested employees.</response>
//         [HttpGet()]
//         [ProducesResponseType(typeof(IEnumerable<EmployeesListViewModel>), 200)]
//         [ProducesResponseType(404)]
//         [ProducesResponseType(500)]
//         public async Task<IActionResult> GetEmployees([FromServices] IEmployeesListQuery query)
//         {
//             try
//             {
//                 var results = await query.GetAllEmployees();
//                 var vm = new EmployeesListViewModel { Employees = results };
//                 return StatusCode((int)HttpStatusCode.OK, vm);
//             }
//             catch (EmployeeNotFoundException)
//             {
//                 return StatusCode((int)HttpStatusCode.NotFound, "No employees were found in the database");
//             }
//             catch (Exception)
//             {
//                 return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
//             }
//         }

//         /// <summary>
//         /// Get a single employee resource by employeeId.
//         /// </summary>
//         /// <returns>An EmployeeInfosViewModel of a single employee</returns>
//         /// <response code="200">Returns a requested employee.</response>
//         [HttpGet("{employeeId}", Name = "GetEmployee")]
//         [ProducesResponseType(typeof(IEnumerable<EmployeeInfosViewModel>), 200)]
//         [ProducesResponseType(404)]
//         [ProducesResponseType(400)]
//         [ProducesResponseType(500)]
//         public async Task<IActionResult> GetEmployeeById([FromServices] IEmployeeQuery query, int employeeId)
//         {
//             try
//             {
//                 var results = await query.GetEmployeeById(employeeId);
//                 var vm = new EmployeeInfosViewModel
//                 {
//                     Id = results.Id,
//                     FirstName = results.FirstName,
//                     // LastName = results.LastName,
//                     BookStartPrice = results.BookStartPrice,
//                     StartPublishingDate = results.StartPublishingDate,
//                     EndPublishingDate = results.EndPublishingDate
//                 };
//                 return StatusCode((int)HttpStatusCode.OK, vm);
//             }
//             catch (EmployeeNotFoundException)
//             {
//                 return StatusCode((int)HttpStatusCode.NotFound, "No employee was found in the database");
//             }
//             catch (Exception)
//             {
//                 return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
//             }
//         }

//         /// <summary>
//         /// Create an employee resource.
//         /// </summary>
//         /// <returns>A new employee which is just created</returns>
//         /// <response code="201">Returns the created employee.</response>
//         [HttpPost()]
//         [ProducesResponseType(typeof(EmployeeFullEditViewModel), 201)]
//         [ProducesResponseType(400)]
//         [ProducesResponseType(500)]
//         public async Task<ActionResult> CreateEmployee(EmployeeFullEditViewModel vm, [FromServices] ICommandHandler<CreateEmployeeCommand> command)
//         {
//             try
//             {
//                 await command.HandleAsync(new CreateEmployeeCommand(vm));
//                 return CreatedAtRoute("GetEmployee", new { employeeId = vm.Id }, vm);
//             }
//             catch (EmployeeNotFoundException)
//             {
//                 return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
//             }
//             catch (Exception)
//             {
//                 return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
//             }
//         }

//         /// <summary>
//         /// Update employee resource by employeeId.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="204">Returns no content.</response>
//         [HttpPut("{employeeId}")]
//         [ProducesResponseType(typeof(EmployeeFullEditViewModel), 204)]
//         [ProducesResponseType(400)]
//         [ProducesResponseType(404)]
//         [ProducesResponseType(500)]
//         public async Task<IActionResult> UpdateEmployee(
//             int employeeId,
//             [FromServices] IEmployeeRepository repo, EmployeeFullEditViewModel vm,
//             [FromServices] ICommandHandler<UpdateEmployeeCommand> command)
//         {
//             try
//             {
//                 var aggregate = await repo.Get(employeeId);
//                 if (aggregate == null) return NotFound();

//                 var viewModel = new EmployeeFullEditViewModel(aggregate);
//                 await command.HandleAsync(new UpdateEmployeeCommand(vm));
//                 return NoContent();
//             }
//             catch (EmployeeNotFoundException)
//             {
//                 return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
//             }
//             catch (Exception)
//             {
//                 return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
//             }

//         }

//         /// <summary>
//         /// Delete a single employee resource by employeeId.
//         /// </summary>
//         /// <returns>An ActionResult</returns>
//         /// <response code="204">Returns the requested employes.</response>
//         [HttpDelete("{employeeId}")]
//         [ProducesResponseType(204)]
//         [ProducesResponseType(404)]
//         [ProducesResponseType(400)]
//         [ProducesResponseType(500)]
//         public async Task<IActionResult> DeleteEmployee(
//             int employeeId,
//             [FromServices] ICommandHandler<DeleteEmployeeCommand> command)
//         {
//             try
//             {
//                 if (employeeId > 0)
//                 {
//                     await command.HandleAsync(new DeleteEmployeeCommand(employeeId));
//                 }

//                 return NoContent();
//             }
//             catch (EmployeeNotFoundException)
//             {
//                 return StatusCode((int)HttpStatusCode.BadRequest, "No employee was found in the database");
//             }
//             catch (Exception)
//             {
//                 return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
//             }
//         }
//     }
// }
