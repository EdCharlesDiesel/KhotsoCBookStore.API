

// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using AutoMapper;
// using KhotsoCBookStore.API.Dtos;
// using KhotsoCBookStore.API.Helpers;
// using KhotsoCBookStore.API.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.JsonPatch;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;

// namespace KhotsoCBookStore.API.Controllers
// {
//     [Produces("application/json")]
//     [Route("api/[controller]")]
//     public class CustomersController : Controller
//     {
//         readonly ICustomerService _customerService;
//         private readonly IMailService _mailService;
//         private readonly IMapper _mapper;
//         private readonly AppSettings _appSettings;
//         readonly ICartService _cartService;
//         public CustomersController(ICustomerService customerService,
//             IMapper mapper,IMailService mailService, ICartService cartService,IOptions<AppSettings> appSettings)
//         {
//             _customerService = customerService?? throw new ArgumentNullException(nameof(_customerService));
//             _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//             _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
//             _appSettings = appSettings.Value;
//             _cartService = cartService ?? throw new ArgumentNullException(nameof(_cartService));
//         }

//         /// <summary>
//         /// Get supported resource actions
//         /// </summary>
//         /// <returns>API actions allowed</returns>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the list of all requests allowed on this end-point</response>
//         [HttpOptions]
//         public IActionResult GetCustomersAPIOptions()
//         {
//             Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
//             return Ok();
//         }     

//         /// <summary>
//         /// Get all customers resources.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the requested customers.</response>
//         [HttpGet()]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         [ProducesDefaultResponseType]
//         public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
//         { 
//             var customers =  _customerService.GetAllCustomersAync();
//             return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));             
//         }

//         /// <summary>
//         /// Get a single customer resource by customerId.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the requested employes.</response>
//         [HttpGet("{customerId}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<ActionResult<CustomerDto>> GetCustomer(Guid customerId)
//         { 
//             var customer =  _customerService.GetCustomerAsync(customerId);
//             return Ok(_mapper.Map<CustomerDto>(customer));             
//         }

//         /// <summary>
//         /// Create customer resource by customerId.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the requested employes.</response>
//         [HttpPost]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<ActionResult<CustomerForCreateDto>> CreateCustomer(CustomerForCreateDto newCustomer)
//         { 
//             await _customerService.CreateCustomerAsync(newCustomer);
//             await _customerService.SaveChangesAsync();

//             var createdCustomerToReturn = 
//                 _mapper.Map<CustomerForCreateDto>(newCustomer);
            
//             return CreatedAtRoute("GetCustomer",createdCustomerToReturn);             
//         }

//         /// <summary>
//         /// Update customer resource by customerId.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the requested employes.</response>
//         [HttpPut("{customerId}")]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<ActionResult> UpdateCustomer(Guid customerId,
//             CustomerForUpdateDto customerToUpdate)
//         {
//             if (!await _customerService.CustomerIfExistsAsync(customerId))
//             {
//                 return NotFound();
//             }

//             var customerEntity =  _customerService.GetCustomerAsync(customerId);
//             if (customerEntity == null)
//             {
//                 return NotFound();
//             }

//             _mapper.Map(customerToUpdate, customerEntity);

//             await _customerService.SaveChangesAsync();

//             return NoContent();
//         }
     
//         /// <summary>
//         /// Partial update customer resource by customerId.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the requested employes.</response>
//         [HttpPatch("{customerId}")]
//         [ProducesResponseType(StatusCodes.Status200OK)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<ActionResult> PartiallyUpdateCustomer(Guid customerId,
//             JsonPatchDocument<CustomerForUpdateDto> patchDocument)
//         {
//             if (!await _customerService.CustomerIfExistsAsync(customerId))
//             {
//                 return NotFound();
//             }

//             var customerEntity =  _customerService.GetCustomerAsync(customerId);
//             if (customerEntity == null)
//             {
//                 return NotFound();
//             }

//             var customerToPatch = _mapper.Map<CustomerForUpdateDto>(customerEntity);

//             //patchDocument.ApplyTo(customerToPatch, ModelState);

//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             if (!TryValidateModel(customerToPatch))
//             {
//                 return BadRequest(ModelState);
//             }

//             _mapper.Map(customerToPatch, customerEntity);
//             await _customerService.SaveChangesAsync();

//             return NoContent();
//         }

//         /// <summary>
//         /// Delete a single customer resource by customerId.
//         /// </summary>
//         /// <returns>An IActionResult</returns>
//         /// <response code="200">Returns the requested employes.</response>
//         [HttpDelete("{customerId}")]
//         [ProducesResponseType(StatusCodes.Status204NoContent)]
//         [ProducesResponseType(StatusCodes.Status404NotFound)]
//         [ProducesResponseType(StatusCodes.Status400BadRequest)]
//         public async Task<ActionResult> DeleteCustomer(Guid customerId)
//         {
//             if (!await _customerService.CustomerIfExistsAsync(customerId))
//             {
//                 return NotFound();
//             }

//             var customerEntity = _customerService.GetCustomerAsync(customerId);
            
//             if (customerEntity == null)
//             {
//                 return NotFound();
//             }

//             _customerService.DeleteCustomer(customerEntity);
//             await _customerService.SaveChangesAsync();

//             // _mailService.Send(
//             //     "Customer deleted.",
//             //     $"Customer named {customerEntity.FirstName} with id {customerEntity.CustomerId} was deleted.");
         
//             return NoContent();
//         }

//         /// <summary>
//         /// Get the count of item in the shopping cart
//         /// </summary>
//         /// <param name="customerId"></param>
//         /// <returns>The count of items in shopping cart</returns>
//         [HttpGet("{customerId}")]
//         public int Get(Guid customerId)
//         {
//             int cartItemCount = _cartService.GetCartItemCount(customerId);
//             return cartItemCount;
//         }

//         /// <summary>
//         /// Check customername availability. 
//         /// </summary>
//         /// <param name="customerName"></param>
//         /// <returns></returns>
//         [HttpGet]
//         [Route("validateUserName/{customerName}")]
//         public bool ValidateUserName(string customerName)
//         {
//             return _customerService.CheckUserAvailabity(customerName);
//         }

//         /// <summary>
//         /// Register a new customer.
//         /// </summary>
//         /// <param name="newCustomer"></param>
//         [AllowAnonymous]
//         [HttpPost("register")]
//         public IActionResult Register([FromBody]CustomerForCreateDto newCustomer)
//         {
//             var customer = _mapper.Map<CustomerDto>(newCustomer);
//             try
//             {
//                 // create customer
//                 _customerService.RegisterUser(customer, newCustomer.Password);
//                 return Ok();
//             }
//             catch (AppException ex)
//             {
//                 // return error message if there was an exception
//                 return BadRequest(new { message = ex.Message });
//             }
//         }
//     }
// }
