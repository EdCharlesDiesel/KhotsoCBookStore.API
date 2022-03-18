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
    public class PublisherController : Controller
    {

        readonly IPublisherService _publisherService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public PublisherController(IPublisherService publisherService,
            IMapper mapper, IMailService mailService)
        {
            _publisherService = publisherService ?? throw new ArgumentNullException(nameof(_publisherService));
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
        /// Get all publishers resources.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested publishers.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PublisherDto>>> GetPublishers()
        {
            var publishers = _publisherService.GetAllPublishersAync();
            return Ok(_mapper.Map<IEnumerable<PublisherDto>>(publishers));
        }

        /// <summary>
        /// Get a single publisher resource by publisherId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{publisherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublisherDto>> GetPublisher(Guid publisherId)
        {
            var publisher =  _publisherService.GetPublisherByIdAsync(publisherId);
            return Ok(_mapper.Map<PublisherDto>(publisher));
        }

        /// <summary>
        /// Create publisher resource by publisherId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PublisherForCreateDto>> CreatePublisher(PublisherForCreateDto publisher)
        {
            var newPublisher =_mapper.Map<Entities.Publisher>(publisher);
            await _publisherService.CreatePublisherAsync(newPublisher);
            await _publisherService.SaveChangesAsync();

            var createdPublisherToReturn =
                _mapper.Map<PublisherForCreateDto>(newPublisher);

            return CreatedAtRoute("GetPublisher", createdPublisherToReturn);
        }

        /// <summary>
        /// Update publisher resource by publisherId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPut("{publisherId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePublisher(Guid publisherId,
            PublisherForUpdateDto publisherToUpdate)
        {
            if (!await _publisherService.PublisherIfExistsAsync(publisherId))
            {
                return NotFound();
            }

            var publisherEntity = _publisherService.GetPublisherByIdAsync(publisherId);
            if (publisherEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(publisherToUpdate, publisherEntity);

            await _publisherService.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partial update publisher resource by publisherId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPatch("{publisherId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdatePublisher(Guid publisherId,
            JsonPatchDocument<PublisherForUpdateDto> patchDocument)
        {
            if (!await _publisherService.PublisherIfExistsAsync(publisherId))
            {
                return NotFound();
            }

            var publisherEntity =  _publisherService.GetPublisherByIdAsync(publisherId);
            if (publisherEntity == null)
            {
                return NotFound();
            }

            var publisherToPatch = _mapper.Map<PublisherForUpdateDto>(publisherEntity);

            //patchDocument.ApplyTo(publisherToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(publisherToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(publisherToPatch, publisherEntity);
            await _publisherService.SaveChangesAsync();

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
            // if (!await _publisherService.PublisherIfExistsAsync(publisherId))
            // {
            //     return NotFound();
            // }

            // var publisherEntity =  _publisherService.GetPublisherAsync(publisherId);

            // if (publisherEntity == null)
            // {
            //     return NotFound();
            // }

            // _publisherService.DeletePublisher(publisherEntity);
            // await _publisherService.SaveChangesAsync();

            // _mailService.Send(
            //     "Publisher deleted.",
            //     $"Publisher named {publisherEntity.} with id {publisherEntity.PublisherId} was deleted.");

            return NoContent();
        }
    }
}
