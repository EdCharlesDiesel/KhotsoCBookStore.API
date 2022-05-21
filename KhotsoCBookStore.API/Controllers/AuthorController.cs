using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.DTOs;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Queries;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMailService _mailService;
        public AuthorController(IMailService mailService)
        {
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
        [ProducesResponseType(typeof(IEnumerable<AuthorsListDTO>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAuthors([FromServices] MainDbContext ctx)
        {
            try
            {
                var response = await ctx.Authors
                    .Select(m => new AuthorsListDTO
                    {
                        Id = m.BookId,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        StartPublishingDate = m.StartPublishingDate,
                        EndPublishingDate = m.EndPublishingDate
                    })
                    .ToListAsync();
                return Ok(response);
            }
            catch (Exception err)
            {
                return StatusCode(500, err);
            }
        }

        //  public async Task<IActionResult> GetAllAuthors([FromServices] IAuthorsListQuery query)
        // {
        //      try
        //     {
        //     var results = await query.GetAllAuthors();
        //     var response = new AuthorsListViewModel { Items = results };
        //     return Ok(response);
        //     }
        //      catch (Exception err)
        //     {
        //         return StatusCode(500, err);
        //     }
        // }

        /// <summary>
        /// Get a single author resource by authorId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{authorId}", Name = "GetAuthor")]
        [ProducesResponseType(typeof(IEnumerable<AuthorDTO>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AuthorDTO>> GetAuthorById([FromServices] MainDbContext ctx, int authorId)
        {
            try
            {
                if (authorId == 0)
                {
                    return NotFound();
                }

                var response = await ctx.Authors
                       .Where(m => m.Id == authorId)
                        .Select(m => new AuthorDTO
                        {
                            Id = m.BookId,
                            FirstName = m.FirstName,
                            LastName = m.LastName,
                            StartPublishingDate = m.StartPublishingDate,
                            EndPublishingDate = m.EndPublishingDate
                        }).FirstOrDefaultAsync();

                return Ok(response);
            }
            catch (Exception err)
            {
                return StatusCode(500, err);
            }
        }

        // /// <summary>
        // /// Create an author resource.
        // /// </summary>
        // /// <returns>A new author which is just created</returns>
        // /// <response code="201">Returns the created author.</response>
        // [HttpPost()]
        // [ProducesResponseType(201)]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(500)]
        // public async Task<ActionResult> CreateAuthor([FromServices] MainDbContext ctx,[FromBody] AuthorForCreateDTO newAuthor)
        // {

        //     try
        //     {

        //           var authorToCreate = _mapper.Map<Entities.Author>(newAuthor);
        //     await _authorRepository.CreateAuthorAsync(authorToCreate);
        //     await _authorRepository.SaveChangesAsync();

        //     var authorToReturn = _mapper.Map<Author>(authorToCreate);

            


        //         if (newAuthor != null)
        //         {
        //             return NotFound();
        //         }

        //         var response = await ctx.Authors.AddAsync(newAuthor);
             

        //         return CreatedAtRoute("GetAuthor",
        //         new { authorId = response.AuthorId },
        //         authorToReturn);
        //     }
        //     catch (Exception err)
        //     {
        //         return StatusCode(500, err);
        //     }
          
        // }

        // /// <summary>
        // /// Update author resource by authorId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="200">Returns no content.</response>
        // [HttpPut("{authorId}")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        // public async Task<ActionResult> UpdateAuthor(Guid authorId,AuthorForUpdateDto authorToUpdate)
        // {
        //     if (!await _authorRepository.AuthorIfExistsAsync(authorId))
        //     {
        //         return NotFound();
        //     }

        //     var authorEntity =  await _authorRepository.GetAuthorByIdAsync(authorId);
        //     if (authorEntity == null)
        //     {
        //         return NotFound();
        //     }

        //     _mapper.Map(authorToUpdate, authorEntity);

        //     await _authorRepository.SaveChangesAsync();

        //     return NoContent();
        // }

        // /// <summary>
        // /// Partial update author resource by authorId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="200">Returns no content.</response>
        // [HttpPatch("{authorId}")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult> PartiallyUpdateAuthor(Guid authorId,
        //     JsonPatchDocument<AuthorForUpdateDto> patchDocument)
        // {
        //     if (!await _authorRepository.AuthorIfExistsAsync(authorId))
        //     {
        //         return NotFound();
        //     }

        //     var authorEntity =  _authorRepository.GetAuthorByIdAsync(authorId);
        //     if (authorEntity == null)
        //     {
        //         return NotFound();
        //     }

        //     var authorToPatch = _mapper.Map<AuthorForUpdateDto>(authorEntity);

        //     //patchDocument.ApplyTo(authorToPatch, ModelState);
        //     patchDocument.ApplyTo(authorToPatch);

        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     if (!TryValidateModel(authorToPatch))
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     await _mapper.Map(authorToPatch, authorEntity);
        //     await _authorRepository.SaveChangesAsync();

        //     return NoContent();
        // }

        // /// <summary>
        // /// Delete a single author resource by authorId.
        // /// </summary>
        // /// <returns>An IActionResult</returns>
        // /// <response code="200">Returns the requested employes.</response>
        // [HttpDelete("{authorId}")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult> DeleteAuthor(Guid authorId)
        // {
        //     if (!await _authorRepository.AuthorIfExistsAsync(authorId))
        //     {
        //         return NotFound();
        //     }

        //     var authorEntity = await  _authorRepository.GetAuthorByIdAsync(authorId);

        //     if (authorEntity == null)
        //     {
        //         return NotFound();
        //     }

        //     _authorRepository.DeleteAuthor(authorEntity.AuthorId);
        //     await _authorRepository.SaveChangesAsync();

        //      _mailService.Send(
        //          "Author deleted.",
        //       $"Author named {authorEntity.FirstName} with id {authorEntity.AuthorId} was deleted.");

        //     return NoContent();
        // }
    }
}


//  [HttpGet]
//         public async Task<IActionResult> Index([FromServices] IAuthorsListQuery query)
//         {
//             var results = await query.GetAllAuthors();
//             var vm = new AuthorsListViewModel { Items = results };
//             return View(vm);
//         }
//         [HttpGet]
//         public IActionResult Create()
//         {
//             return View("Edit");
//         }
//         [HttpPost]
//         public async Task<IActionResult> Create(
//             AuthorFullEditViewModel vm,
//             [FromServices] ICommandHandler<CreateAuthorCommand> command)
//         {
//             if (ModelState.IsValid) { 
//                 await command.HandleAsync(new CreateAuthorCommand(vm));
//                 return RedirectToAction(
//                     nameof(ManageAuthorsController.Index));
//             }
//             else
//                 return View("Edit", vm);
//         }
//         [HttpGet]
//         public async Task<IActionResult> Edit(
//             int id,
//             [FromServices] IAuthorRepository repo)
//         {
//             if (id == 0) return RedirectToAction(
//                 nameof(ManageAuthorsController.Index));
//             var aggregate = await repo.Get(id);
//             if (aggregate == null) return RedirectToAction(
//                 nameof(ManageAuthorsController.Index));
//             var vm = new AuthorFullEditViewModel(aggregate);
//             return View(vm);
//         }
//         [HttpPost]
//         public async Task<IActionResult> Edit(
//             AuthorFullEditViewModel vm,
//             [FromServices] ICommandHandler<UpdateAuthorCommand> command)
//         {
//             if (ModelState.IsValid)
//             {
//                 await command.HandleAsync(new UpdateAuthorCommand(vm));
//                 return RedirectToAction(
//                     nameof(ManageAuthorsController.Index));
//             }
//             else
//                 return View(vm);
//         }

//         [HttpGet]
//         public async Task<IActionResult> Delete(
//             int id,
//             [FromServices] ICommandHandler<DeleteAuthorCommand> command)
//         {
//             if (id>0)
//             {
//                 await command.HandleAsync(new DeleteAuthorCommand(id));
                
//             }
//             return RedirectToAction(
//                     nameof(ManageAuthorsController.Index));
//         }