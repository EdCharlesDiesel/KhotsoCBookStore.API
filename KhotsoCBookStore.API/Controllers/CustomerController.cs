

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using KhotsoCBookStore.API.Entities;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerService _customerRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        readonly ICartService _cartService;
        public CustomerController(ICustomerService customerRepository,
            IMapper mapper, IMailService mailService, ICartService cartService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(_customerRepository));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _cartService = cartService ?? throw new ArgumentNullException(nameof(_cartService));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetCustomersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get all customers resources.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested customers.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _customerRepository.GetAllCustomersAync();
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        /// <summary>
        /// Get a single customer resource by customerId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerDto>> GetCustomer(Guid customerId)
        {
            if (customerId == new Guid())
            {
                return NotFound();
            }
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        /// <summary>
        /// Create customer resource by customerId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerForCreateDto>> CreateCustomer([FromBody] CustomerForCreateDto customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            await _customerRepository.CreateCustomerAsync(newCustomer);
            await _customerRepository.SaveChangesAsync();


            var customerToReturn = _mapper.Map<Customer>(newCustomer);

            return CreatedAtRoute("GetCustomer",
                new { customerId = customerToReturn.CustomerId },
                customerToReturn);
                     
        }


        /// <summary>
        /// Update customer resource by customerId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCustomer(Guid customerId,
            CustomerForUpdateDto customerToUpdate)
        {
            if (!await _customerRepository.CustomerIfExistsAsync(customerId))
            {
                return NotFound();
            }

            var customerEntity = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customerEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(customerToUpdate, customerEntity);

            await _customerRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partial update customer resource by customerId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPatch("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateCustomer(Guid customerId,
            JsonPatchDocument<CustomerForUpdateDto> patchDocument)
        {
            if (!await _customerRepository.CustomerIfExistsAsync(customerId))
            {
                return NotFound();
            }

            var customerEntity = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customerEntity == null)
            {
                return NotFound();
            }

            var customerToPatch = _mapper.Map<CustomerForUpdateDto>(customerEntity);

            patchDocument.ApplyTo(customerToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(customerToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(customerToPatch, customerEntity);
            await _customerRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single customer resource by customerId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{customerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCustomer(Guid customerId)
        {

            var customerEntity = await _customerRepository.GetCustomerByIdAsync(customerId);

            if (customerEntity == null)
            {
                return NotFound();
            }

            _customerRepository.DeleteCustomer(customerEntity.CustomerId);
            await _customerRepository.SaveChangesAsync();

            _mailService.Send(
                "Customer deleted.",
                $"Customer named {customerEntity.FirstName} with id {customerEntity.CustomerId} was deleted.");

            return NoContent();
        }
    }
}
