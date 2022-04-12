using System.Collections.Generic;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PromotionController : Controller
    {
        private readonly IPromotionService _promotionRepository;
         private readonly IMailService _mailService;
        private readonly IBookService _bookService;
        private IMapper _mapper;

        public PromotionController(IPromotionService promotionRepository,
            IBookService bookService,
            IMailService mailService,
            IMapper mapper)
        {
            _mailService = mailService?? throw new ArgumentNullException(nameof(_mailService));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
            _promotionRepository = promotionRepository?? throw new ArgumentNullException(nameof(_promotionRepository));
            _bookService = bookService?? throw new ArgumentNullException(nameof(_bookService));
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetPromotionAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Create a promotion resource.
        /// </summary>
        /// <returns>Promotion resource created</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="201">Returns the created promotion.</response>        
        /// <response code="400">Returns an error if the promotion is in the wrong format.</response>
        [HttpPost(), DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePromotion([FromBody] PromotionForCreateDto newPromotion)
        {
            if (ModelState.IsValid)
            {
                var promotionToCreate = _mapper.Map<Entities.Promotion>(newPromotion);
                await _promotionRepository.CreatePromotionAsync(promotionToCreate);
                await _promotionRepository.SaveChangesAsync();

                var promotionToReturn = _mapper.Map<Promotion>(promotionToCreate);

                return CreatedAtRoute("GetPromotion",
                    new { promotionId = promotionToReturn.PromotionId },
                    promotionToReturn);
            }
            else
                return BadRequest(ModelState);                
        }    

        /// <summary>
        /// Get all promotion resources.
        /// </summary>
        /// <returns>Returns promotion</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<PromotionDto>>> GetPromotions()
        { 
            var promotions = await _promotionRepository.GetAllPromotionsAync();
            return Ok(_mapper.Map<IEnumerable<PromotionDto>>(promotions));          
        }

        /// <summary>
        /// Get a single promotion resource by promotionId.
        /// </summary>
        /// <returns>A single promotion</returns>
        /// <response code="200">Returns requested promotion resource by id.</response>
        /// <response code="404">Returns error if the requested promotion resource is not found.</response>
        [HttpGet("{promotionId}", Name = "GetPromotion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PromotionDto>> GetPromotion(Guid promotionId)
        {
            if (promotionId == new Guid())
            {
               return NotFound();
            }          

            var promotion = await _promotionRepository.GetPromotionByIdAsync(promotionId);
            return Ok(_mapper.Map<PromotionDto>(promotion));
        }       

        /// <summary>
        /// Update a promotion resource by promotionId.
        /// </summary>
        /// <returns>Updated promotion resource</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPut("{promotionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdatePromotion(Guid promotionId,[FromBody] PromotionForUpdateDto promotionToUpdate)
        {
            if (!await _promotionRepository.PromotionIfExistsAsync(promotionId))
            {
                return NotFound();
            }

            var promotionEntity =  await _promotionRepository.GetPromotionByIdAsync(promotionId);
            if (promotionEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(promotionToUpdate, promotionEntity);

            await _promotionRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update promotion resource by promotionId.
        /// </summary>
        /// <returns>No content if promotion resource was updated successfully</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPatch("{promotionId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> PartiallyUpdatePromotion(Guid promotionId,
            JsonPatchDocument<PromotionForUpdateDto> patchDocument)
        {
            if (!await _promotionRepository.PromotionIfExistsAsync(promotionId))
            {
                return NotFound();
            }

            var promotionEntity =  _promotionRepository.GetPromotionByIdAsync(promotionId);
            if (promotionEntity == null)
            {
                return NotFound();
            }

            var promotionToPatch = _mapper.Map<PromotionForUpdateDto>(promotionEntity);

            //patchDocument.ApplyTo(promotionToPatch, ModelState);
            patchDocument.ApplyTo(promotionToPatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(promotionToPatch))
            {
                return BadRequest(ModelState);
            }

            await _mapper.Map(promotionToPatch, promotionEntity);
            await _promotionRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single promotion resource by promotionId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{promotionId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePromotion(Guid promotionId)
        {
            if (!await _promotionRepository.PromotionIfExistsAsync(promotionId))
            {
                return NotFound();
            }

            var promotionEntity = await  _promotionRepository.GetPromotionByIdAsync(promotionId);
            if (promotionEntity == null)
            {
                return NotFound();
            }

             _promotionRepository.DeletePromotion(promotionEntity);
            await _promotionRepository.SaveChangesAsync();

            var promotion = _mapper.Map<Promotion>(promotionEntity);

            _mailService.Send(
            "Promotion deleted.",
            $"Promotion with id {promotion.PromotionId} was deleted.");

            return NoContent();
        }    

        /// <summary>
        /// Get the list of orders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBooksAvailableInPromotion")]
        public Task<IEnumerable<BookDto>> GetBooksAvailableInPromotion()
        {
            // // var categories = _mapper.Map<Promotion>(PromotionDto);
             //return await _bookRepository.GetBooksAvailableInPromotionAsync

            throw new NotImplementedException();
        }
    }
}
