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
    public class AuthorsController : Controller
    {

        readonly IAuthorService _authorService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService authorService,
            IMapper mapper, IMailService mailService)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(_authorService));
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
            var authors = await _authorService.GetAllAuthorsAync();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authors));
        }

        /// <summary>
        /// Get a single author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{authorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorDto>> GetAuthor(Guid authorId)
        {
            var author =  _authorService.GetAuthorAsync(authorId);
            return Ok(_mapper.Map<AuthorDto>(author));
        }

        /// <summary>
        /// Create author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorForCreateDto>> CreateAuthor(AuthorForCreateDto newAuthor)
        {
            await _authorService.CreateAuthorAsync(newAuthor);
            await _authorService.SaveChangesAsync();

            var createdAuthorToReturn =
                _mapper.Map<AuthorForCreateDto>(newAuthor);

            return CreatedAtRoute("GetAuthor", createdAuthorToReturn);
        }

        /// <summary>
        /// Update author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPut("{authorId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAuthor(Guid authorId,
            AuthorForUpdateDto authorToUpdate)
        {
            if (!await _authorService.AuthorIfExistsAsync(authorId))
            {
                return NotFound();
            }

            var authorEntity =  _authorService.GetAuthorAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(authorToUpdate, authorEntity);

            await _authorService.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partial update author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpPatch("{authorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateAuthor(Guid authorId,
            JsonPatchDocument<AuthorForUpdateDto> patchDocument)
        {
            if (!await _authorService.AuthorIfExistsAsync(authorId))
            {
                return NotFound();
            }

            var authorEntity =  _authorService.GetAuthorAsync(authorId);
            if (authorEntity == null)
            {
                return NotFound();
            }

            var authorToPatch = _mapper.Map<AuthorForUpdateDto>(authorEntity);

            //patchDocument.ApplyTo(authorToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(authorToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(authorToPatch, authorEntity);
            await _authorService.SaveChangesAsync();

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
            if (!await _authorService.AuthorIfExistsAsync(authorId))
            {
                return NotFound();
            }

            var authorEntity =  _authorService.GetAuthorAsync(authorId);

            if (authorEntity == null)
            {
                return NotFound();
            }

            _authorService.DeleteAuthor(authorEntity);
            await _authorService.SaveChangesAsync();

            // _mailService.Send(
            //     "Author deleted.",
            //     $"Author named {authorEntity.} with id {authorEntity.AuthorId} was deleted.");

            return NoContent();
        }
    }
}
