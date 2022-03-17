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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorRepository,
            IMapper mapper, IMailService mailService)
        {
            _authorRepository = authorRepository ?? throw new ArgumentNullException(nameof(_authorRepository));
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
        public IActionResult GetAuthorsAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get all authors resources.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested authors.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAuthorsAync();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        /// <summary>
        /// Get a single author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{authorId}", Name = "GetAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(Guid authorId)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(authorId);
            return Ok(_mapper.Map<AuthorDto>(author));
        }

        /// <summary>
        /// Create an author resource.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the created author.</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorForCreateDto newAuthor)
        {
            var authorToCreate = _mapper.Map<Entities.Author>(newAuthor);
            await _authorRepository.CreateAuthorAsync(authorToCreate);
            await _authorRepository.SaveChangesAsync();

            var authorToReturn = _mapper.Map<Author>(authorToCreate);

            return CreatedAtRoute("GetAuthor",
                new { authorId = authorToReturn.AuthorId },
                authorToReturn);
        }

        /// <summary>
        /// Update author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns no content.</response>
        [HttpPut("{authorId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdateAuthor(Guid authorId,
            AuthorForUpdateDto authorToUpdate)
        {
            if (!await _authorRepository.AuthorIfExistsAsync(authorId))
            {
                return NotFound();
            }

            var authorEntity =  await _authorRepository.GetAuthorByIdAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(authorToUpdate, authorEntity);

            await _authorRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partial update author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns no content.</response>
        [HttpPatch("{authorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateAuthor(Guid authorId,
            JsonPatchDocument<AuthorForUpdateDto> patchDocument)
        {
            if (!await _authorRepository.AuthorIfExistsAsync(authorId))
            {
                return NotFound();
            }

            var authorEntity =  _authorRepository.GetAuthorByIdAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            var authorToPatch = _mapper.Map<AuthorForUpdateDto>(authorEntity);

            //patchDocument.ApplyTo(authorToPatch, ModelState);
            patchDocument.ApplyTo(authorToPatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(authorToPatch))
            {
                return BadRequest(ModelState);
            }

            await _mapper.Map(authorToPatch, authorEntity);
            await _authorRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{authorId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAuthor(Guid authorId)
        {
            if (!await _authorRepository.AuthorIfExistsAsync(authorId))
            {
                return NotFound();
            }

            var authorEntity = await  _authorRepository.GetAuthorByIdAsync(authorId);

            if (authorEntity == null)
            {
                return NotFound();
            }

            _authorRepository.DeleteAuthor(authorEntity);
            await _authorRepository.SaveChangesAsync();

             _mailService.Send(
                 "Author deleted.",
              $"Author named {authorEntity.FirstName} with id {authorEntity.AuthorId} was deleted.");

            return NoContent();
        }
    }
}
