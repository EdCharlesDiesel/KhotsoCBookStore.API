using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Dtos;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Microsoft.Net.Http.Headers;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : Controller
    {        
        private readonly IBookService _bookRepository;
        private readonly IMailService _mailService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        
        //private readonly string _coverImageFolderPath = string.Empty;

        public BookController( 
            IBookService bookRepository,         
            IMailService mailService,
            IConfiguration config, 
            IWebHostEnvironment hostingEnvironment,
            IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(_mailService));
            _config = config ?? throw new ArgumentNullException(nameof(_config));
            _bookRepository = bookRepository?? throw new ArgumentNullException(nameof(_bookRepository));
            _hostingEnvironment = hostingEnvironment;
            //!Will Sort this when I build the front end
            // _coverImageFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
            // if (!Directory.Exists(_coverImageFolderPath))
            // {
            //     Directory.CreateDirectory(_coverImageFolderPath);
            // }
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetBookAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        } 

         /// <summary>
        /// Create a book resource.
        /// </summary>
        /// <returns>Book resource created</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="201">Returns the created book.</response>        
        /// <response code="400">Returns an error if the book is in the wrong format.</response>
        [HttpPost(), DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBook([FromBody] BookForCreateDto newBook)
        {
            //Book book = JsonConvert.DeserializeObject<Book>(Request.Form["bookFormData"].ToString());
           
            // if (Request.Form.Files.Count > 0)
            // {
            //     var file = Request.Form.Files[0];

            //     if (file.Length > 0)
            //     {
            //         string fileName = Guid.NewGuid() + ContentDispositionHeaderValue
            //         .Parse(file.ContentDisposition).FileName.ToString().Trim();

            //         string fullPath = Path.Combine(_hostingEnvironment.WebRootPath, fileName);
            //         using (var stream = new FileStream(fullPath, FileMode.Create))
            //         {
            //             file.CopyTo(stream);
            //         }
            //         bookToCreate.CoverFileName = fileName;
            //     }
            // }
            // else
            // {
            //     bookToCreate.CoverFileName = _config["DefaultCoverImageFile"];
            // }
            if (ModelState.IsValid)
            {
                var bookToCreate = _mapper.Map<Entities.Book>(newBook);
                await _bookRepository.CreateBookAsync(bookToCreate);
                await _bookRepository.SaveChangesAsync();

                var bookToReturn = _mapper.Map<Book>(bookToCreate);

                return CreatedAtRoute("GetBook",
                    new { bookId = bookToReturn.BookId },
                    bookToReturn);
            }
            else
                return BadRequest(ModelState);                
        }    

        /// <summary>
        /// Get all book resources.
        /// </summary>
        /// <returns>Returns book</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        { 
            var books = await _bookRepository.GetAllBooksAync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));          
        }

        /// <summary>
        /// Get a single book resource by bookId.
        /// </summary>
        /// <returns>A single book</returns>
        /// <response code="200">Returns requested book resource by id.</response>
        /// <response code="404">Returns error if the requested book resource is not found.</response>
        [HttpGet("{bookId}", Name = "GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDto>> GetBook(Guid bookId)
        {
            if (bookId == new Guid())
            {
               return NotFound();
            }          

            var book = await _bookRepository.GetBookByIdAsync(bookId);
            return Ok(_mapper.Map<BookDto>(book));
        }       

        /// <summary>
        /// Update a book resource by bookId.
        /// </summary>
        /// <returns>Updated book resource</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPut("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdateBook(Guid bookId,[FromBody] BookForUpdateDto bookToUpdate)
        {
            if (!await _bookRepository.BookIfExistsAsync(bookId))
            {
                return NotFound();
            }

            var bookEntity =  await _bookRepository.GetBookByIdAsync(bookId);
            if (bookEntity == null)
            {
                return NotFound();
            }

            //Book book = JsonConvert.DeserializeObject<Book>(Request.Form["bookFormData"].ToString());
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid() + ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition).FileName.ToString().Trim();
                    string fullPath = Path.Combine(_hostingEnvironment.WebRootPath, fileName);
                    bool isFileExists = Directory.Exists(fullPath);

                    if (!isFileExists)
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        bookEntity.CoverFileName = fileName;
                    }
                }
            }            

            _mapper.Map(bookToUpdate, bookEntity);

            await _bookRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partially update book resource by bookId.
        /// </summary>
        /// <returns>No content if book resource was updated successfully</returns>
        /// <response code="200">Returns Ok for successfull request without errors.</response>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        /// <response code="400">Returns bad request if the resource is not supported.</response>
        /// <response code="405">Returns method not allowed.</response>
        [HttpPatch("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> PartiallyUpdateBook(Guid bookId,
            JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            if (!await _bookRepository.BookIfExistsAsync(bookId))
            {
                return NotFound();
            }

            var bookEntity =  _bookRepository.GetBookByIdAsync(bookId);
            if (bookEntity == null)
            {
                return NotFound();
            }

            var bookToPatch = _mapper.Map<BookForUpdateDto>(bookEntity);

            //patchDocument.ApplyTo(bookToPatch, ModelState);
            patchDocument.ApplyTo(bookToPatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(bookToPatch))
            {
                return BadRequest(ModelState);
            }

            await _mapper.Map(bookToPatch, bookEntity);
            await _bookRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single book resource by bookId.
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="204">Returns successfull if resource was updated successfully.</response>
        /// <response code="404">Returns not found if the requested resource is not found.</response>
        [HttpDelete("{bookId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBook(Guid bookId)
        {
            if (!await _bookRepository.BookIfExistsAsync(bookId))
            {
                return NotFound();
            }

            var bookEntity = await  _bookRepository.GetBookByIdAsync(bookId);
            if (bookEntity == null)
            {
                return NotFound();
            }

            var coverFileName = bookEntity.CoverFileName;
            if (coverFileName != _config["DefaultCoverImageFile"])
            {
                string fullPath = Path.Combine(_hostingEnvironment.WebRootPath, coverFileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }

             _bookRepository.DeleteBook(bookEntity);
            await _bookRepository.SaveChangesAsync();

            var book = _mapper.Map<Book>(bookEntity);

            _mailService.Send(
            "Book deleted.",
            $"Book named {book.Title} with id {book.BookId} was deleted.");

            return NoContent();
        }
    }
}

   