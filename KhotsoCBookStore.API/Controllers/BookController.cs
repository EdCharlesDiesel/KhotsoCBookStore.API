using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DDD.ApplicationLayer;
using KhotsoCBookStore.API.Commands;
using KhotsoCBookStore.API.Exceptions;
using KhotsoCBookStore.API.Models;
using KhotsoCBookStore.API.Models.Books;
using KhotsoCBookStore.API.Queries;
using Microsoft.AspNetCore.Mvc;
using StarPeaceAdminHubDomain.IRepositories;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point.</response>
        [HttpOptions]
        public IActionResult GetBooksAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }

        /// <summary>
        /// Get all books resources.
        /// </summary>
        /// <returns>An BooksListViewModel of books</returns>
        /// <response code="200">Returns the requested books.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<BooksListViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBooks([FromServices] IBooksListQuery query)
        {
            try
            {
                var results = await query.GetAllBooks();
                var vm = new BooksListViewModel { AllBooks = results };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (BookNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No books were found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Get a single book resource by bookId.
        /// </summary>
        /// <returns>An BookInfosViewModel of a single book</returns>
        /// <response code="200">Returns a requested book.</response>
        [HttpGet("{bookId}", Name = "GetBook")]
        [ProducesResponseType(typeof(IEnumerable<BookInfosViewModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetBookById([FromServices] IBooksListQuery query, int bookId)
        {
            try
            {
                var results = await query.GetBookById(bookId);
                var vm = new BookInfosViewModel
                {

                    BookId = results.BookId,
                    Title = results.Title,
                    ISBN = results.ISBN,
                    Description = results.Description,
                    Cost = results.Cost,
                    PublishingDate= results.PublishingDate,
                    RetailPrice = results.RetailPrice,
                    CoverFileName= results.CoverFileName
                };
                return StatusCode((int)HttpStatusCode.OK, vm);
            }
            catch (BookNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No book was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Create an book resource.
        /// </summary>
        /// <returns>A new book which is just created</returns>
        /// <response code="201">Returns the created book.</response>
        [HttpPost()]
        [ProducesResponseType(typeof(BookFullEditViewModel), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateBook(BookFullEditViewModel vm, [FromServices] ICommandHandler<CreateBookCommand> command)
        {
            try
            {
                await command.HandleAsync(new CreateBookCommand(vm));
                return CreatedAtRoute("GetBook", new { bookId = vm.BookId }, vm);
            }
            catch (BookNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Update book resource by bookId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="204">Returns no content.</response>
        [HttpPut("{bookId}")]
        [ProducesResponseType(typeof(BookFullEditViewModel), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateBook(
            int bookId,
            [FromServices] IBookRepository repo, BookFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdateBookCommand> command)
        {
            try
            {
                var aggregate = await repo.Get(bookId);
                if (aggregate == null) return NotFound();

                var viewModel = new BookFullEditViewModel(aggregate);
                await command.HandleAsync(new UpdateBookCommand(vm));
                return NoContent();
            }
            catch (BookNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "An error occured please validate with the schema");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }

        /// <summary>
        /// Delete a single book resource by bookId.
        /// </summary>
        /// <returns>An ActionResult</returns>
        /// <response code="204">Returns the requested employes.</response>
        [HttpDelete("{bookId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteBook(
            int bookId,
            [FromServices] ICommandHandler<DeleteBookCommand> command)
        {
            try
            {
                if (bookId > 0)
                {
                    await command.HandleAsync(new DeleteBookCommand(bookId));
                }

                return NoContent();
            }
            catch (BookNotFoundException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "No book was found in the database");
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }
    }
}
