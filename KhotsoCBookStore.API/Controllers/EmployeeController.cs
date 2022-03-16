using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        readonly IEmployeeService _employeeService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService,
            IMapper mapper,IMailService mailService)
        {
            _employeeService = employeeService?? throw new ArgumentNullException(nameof(_employeeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetEmployeesAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }     

        /// <summary>
        /// Get all employees resources.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employees.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        { 
            var employees = await _employeeService.GetAllEmployeesAync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));             
        }

        /// <summary>
        /// Get a single employee resource by employeeId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid employeeId)
        { 
            var employee = await _employeeService.GetEmployeeAsync(employeeId);
            return Ok(_mapper.Map<EmployeeDto>(employee));             
        }

        /// <summary>
        /// Create employee resource by employeeId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateEmployeeDto>> CreateEmployee(CreateEmployeeDto newEmployee)
        { 
            await _employeeService.CreateEmployeeAsync(newEmployee);
            await _employeeService.SaveChangesAsync();

            var createdEmployeeToReturn = 
                _mapper.Map<CreateEmployeeDto>(newEmployee);
            
            return CreatedAtRoute("GetEmployee",createdEmployeeToReturn);             
        }

        /// <summary>
        /// Update employee resource by employeeId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPut("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateEmployee(Guid employeeId,
            EmployeeForUpdateDto employeeToUpdate)
        {
            if (!await _employeeService.EmployeeIfExistsAsync(employeeId))
            {
                return NotFound();
            }

            var employeeEntity = await _employeeService.GetEmployeeAsync(employeeId);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeToUpdate, employeeEntity);

            await _employeeService.SaveChangesAsync();

            return NoContent();
        }
     
        /// <summary>
        /// Partial update employee resource by employeeId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPatch("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateEmployee(Guid employeeId,
            JsonPatchDocument<EmployeeForUpdateDto> patchDocument)
        {
            if (!await _employeeService.EmployeeIfExistsAsync(employeeId))
            {
                return NotFound();
            }

            var employeeEntity = await _employeeService.GetEmployeeAsync(employeeId);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            //patchDocument.ApplyTo(employeeToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(employeeToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeEntity);
            await _employeeService.SaveChangesAsync();

            return NoContent();
        }

         /// <summary>
        /// Delete a single employee resource by employeeId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteEmployee(Guid employeeId)
        {
            if (!await _employeeService.EmployeeIfExistsAsync(employeeId))
            {
                return NotFound();
            }

            var employeeEntity = await _employeeService.GetEmployeeAsync(employeeId);
            
            if (employeeEntity == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(employeeEntity);
            await _employeeService.SaveChangesAsync();

            _mailService.Send(
                "Employee deleted.",
                $"Employee named {employeeEntity.FirstName} with id {employeeEntity.Id} was deleted.");
         
            return NoContent();
        }
    }
}
