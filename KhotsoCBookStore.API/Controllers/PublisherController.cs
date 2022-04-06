using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {

        readonly IPublisherService _publisherRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public PublisherController(IPublisherService publisherService,
            IMapper mapper, IMailService mailService)
        {
            _publisherRepository = publisherService ?? throw new ArgumentNullException(nameof(_publisherRepository));
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
        public IActionResult GetPublishersAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Create a publisher resource.
        /// </summary>
        /// <returns>Publisher resource created</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="201">Returns the created publisher.</response>        
        /// <response code="400">Returns an error if the publisher is in the wrong format.</response>
        [HttpPost(), DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePublisher([FromBody] PublisherForCreateDto newPublisher)
        {
            if (ModelState.IsValid)
            {
                var publisherToCreate = _mapper.Map<Entities.Publisher>(newPublisher);
                await _publisherRepository.CreatePublisherAsync(publisherToCreate);
                await _publisherRepository.SaveChangesAsync();

                var publisherToReturn = _mapper.Map<Publisher>(publisherToCreate);

                return CreatedAtRoute("GetPublisher",
                    new { publisherId = publisherToReturn.PublisherId },
                    publisherToReturn);
            }
            else
                return BadRequest(ModelState);                
        }    

        /// <summary>
        /// Get all publisher resources.
        /// </summary>
        /// <returns>Returns publisher</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetPublishers()
        { 
            var publishers = await _publisherRepository.GetAllPublishersAync();
            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));          
        }

        /// <summary>
        /// Get a single publisher resource by publisherId.
        /// </summary>
        /// <returns>A single publisher</returns>
        /// <response code="200">Returns requested publisher resource by id.</response>
        /// <response code="404">Returns error if the requested publisher resource is not found.</response>
        [HttpGet("{publisherId}", Name = "GetPublisher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PublisherDto>> GetPublisher(Guid publisherId)
        {
            if (publisherId == new Guid())
            {
               return NotFound();
            }          

            var publisher = await _publisherRepository.GetPublisherByIdAsync(publisherId);
            return Ok(_mapper.Map<PublisherDto>(publisher));
        }       

        /// <summary>
        /// Update a publisher resource by publisherId.
        /// </summary>
        /// <returns>Updated publisher resource</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPut("{publisherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdatePublisher(Guid publisherId,[FromBody] PublisherForUpdateDto publisherToUpdate)
        {
            if (!await _publisherRepository.PublisherIfExistsAsync(publisherId))
            {
                return NotFound();
            }

            var publisherEntity =  await _publisherRepository.GetPublisherByIdAsync(publisherId);
            if (publisherEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(publisherToUpdate, publisherEntity);

            await _publisherRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update publisher resource by publisherId.
        /// </summary>
        /// <returns>No content if publisher resource was updated successfully</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPatch("{publisherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> PartiallyUpdatePublisher(Guid publisherId,
            JsonPatchDocument<PublisherForUpdateDto> patchDocument)
        {
            if (!await _publisherRepository.PublisherIfExistsAsync(publisherId))
            {
                return NotFound();
            }

            var publisherEntity =  _publisherRepository.GetPublisherByIdAsync(publisherId);
            if (publisherEntity == null)
            {
                return NotFound();
            }

            var publisherToPatch = _mapper.Map<PublisherForUpdateDto>(publisherEntity);

            //patchDocument.ApplyTo(publisherToPatch, ModelState);
            patchDocument.ApplyTo(publisherToPatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(publisherToPatch))
            {
                return BadRequest(ModelState);
            }

            await _mapper.Map(publisherToPatch, publisherEntity);
            await _publisherRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single publisher resource by publisherId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{publisherId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePublisher(Guid publisherId)
        {
            if (!await _publisherRepository.PublisherIfExistsAsync(publisherId))
            {
                return NotFound();
            }

            var publisherEntity = await  _publisherRepository.GetPublisherByIdAsync(publisherId);
            if (publisherEntity == null)
            {
                return NotFound();
            }

             _publisherRepository.DeletePublisher(publisherEntity);
            await _publisherRepository.SaveChangesAsync();

            var publisher = _mapper.Map<Publisher>(publisherEntity);

            _mailService.Send(
            "Publisher deleted.",
            $"Publisher named {publisher.NameAndSurname} with id {publisher.PublisherId} was deleted.");

            return NoContent();
        }        
    }
}
