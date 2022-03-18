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

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        readonly IWebHostEnvironment _hostingEnvironment;
        readonly IBookService _bookRepository;

        private readonly IMailService _mailService;
        readonly IConfiguration _config;
        private readonly IMapper _mapper;
        readonly string coverImageFolderPath = string.Empty;

        public BooksController( 
        IMapper mapper, 
        IMailService mailService,
        IConfiguration config, 
        IWebHostEnvironment hostingEnvironment,
        IBookService bookRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
  
            _config = config;
            _bookRepository = bookRepository?? throw new ArgumentNullException(nameof(_bookRepository));
            _hostingEnvironment = hostingEnvironment;
             _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
       
            
            coverImageFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
            if (!Directory.Exists(coverImageFolderPath))
            {
                Directory.CreateDirectory(coverImageFolderPath);
            }
        }

        /// <summary>
        /// Get supported resource actions
        /// </summary>
        /// <returns>API actions allowed</returns>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the list of all requests allowed on this end-point</response>
        [HttpOptions]
        public IActionResult GetBooksAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }     

        /// <summary>
        /// Get all the books
        /// </summary>
        /// <returns>Returns books</returns>
        /// <response code="200">Returns the requested books</response>
        /// <response code="404">Returns no books found</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        { 
              
            var books = await _bookRepository.GetAllBooksAync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));          
        }

      

        /// <summary>
        /// Get a single books resource by booksId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpGet("{booksId}", Name = "GetBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> GetBookById(Guid booksId)
        {
            if (booksId == new Guid())
            {
               return NotFound();
            }

            var books = await _bookRepository.GetBookByIdAsync(booksId);
            return Ok(_mapper.Map<BookDto>(books));
        }

        /// <summary>
        /// Create an books resource.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the created books.</response>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBook([FromBody] BookForCreateDto newBook)
        {
            var booksToCreate = _mapper.Map<Entities.Book>(newBook);
            await _bookRepository.CreateBook(booksToCreate);
            await _bookRepository.SaveChangesAsync();

            var booksToReturn = _mapper.Map<Book>(booksToCreate);

            return CreatedAtRoute("GetBook",
                new { booksId = booksToReturn.BookId },
                booksToReturn);
        }

        /// <summary>
        /// Update books resource by booksId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns no content.</response>
        [HttpPut("{booksId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public async Task<ActionResult> UpdateBook(Guid booksId,
            BookForUpdateDto booksToUpdate)
        {
            if (!await _bookRepository.BookIfExistsAsync(booksId))
            {
                return NotFound();
            }

            var booksEntity =  await _bookRepository.GetBookByIdAsync(booksId);
            if (booksEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(booksToUpdate, booksEntity);

            await _bookRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Partial update books resource by booksId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns no content.</response>
        [HttpPatch("{booksId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PartiallyUpdateBook(Guid booksId,
            JsonPatchDocument<BookForUpdateDto> patchDocument)
        {
            if (!await _bookRepository.BookIfExistsAsync(booksId))
            {
                return NotFound();
            }

            var booksEntity =  _bookRepository.GetBookByIdAsync(booksId);
            if (booksEntity == null)
            {
                return NotFound();
            }

            var booksToPatch = _mapper.Map<BookForUpdateDto>(booksEntity);

            //patchDocument.ApplyTo(booksToPatch, ModelState);
            patchDocument.ApplyTo(booksToPatch);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(booksToPatch))
            {
                return BadRequest(ModelState);
            }

            await _mapper.Map(booksToPatch, booksEntity);
            await _bookRepository.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Delete a single books resource by booksId.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested employes.</response>
        [HttpDelete("{booksId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBook(Guid booksId)
        {
            if (!await _bookRepository.BookIfExistsAsync(booksId))
            {
                return NotFound();
            }

            var booksEntity = await  _bookRepository.GetBookByIdAsync(booksId);

            if (booksEntity == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(booksEntity);
            await _bookRepository.SaveChangesAsync();

            //  _mailService.Send(
            //      "Book deleted.",
            //   $"Book named {booksEntity.FirstName} with id {booksEntity.BookId} was deleted.");

            return NoContent();
        }
       
    

        ///<summary>
        ///Get all books resources.
        /// </summary>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested books.</response>
        // [HttpGet()]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [ProducesDefaultResponseType]
        // public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        // {
        //     var books = await _bookRepository.GetAllBooksAync();
        //     return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        // }

        // /// <summary>
        // /// Get the specific book with BookId
        // /// </summary>
        // /// <param name="bookId"></param>
        // /// <returns></returns>
        // [HttpGet("{bookId}")]
        // public IActionResult Get(Guid bookId)
        // {
        //     Book book = _bookRepository.GetBookByIdAsync(bookId);
        //     if (book != null)
        //     {
        //         return Ok(book);
        //     }
        //     return NotFound();
        // }

        /// <summary>
        /// Get the list of categories.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoriesList")]
        public  Task<IEnumerable<Category>> CategoryDetails()
        {
            // return await Task.FromResult(_bookRepository.GetCategories()).ConfigureAwait(true);
            throw new NotImplementedException();
        }    

        /// <summary>
        /// Add a new book.
        /// </summary>
        /// <returns></returns>
        // [HttpPost, DisableRequestSizeLimit]
        // //[Bookize(Policy = UserRoles.Admin)]
        // public int Post()
        // {
        //     Book book = JsonConvert.DeserializeObject<Book>(Request.Form["bookFormData"].ToString());

        //     if (Request.Form.Files.Count > 0)
        //     {
        //         var file = Request.Form.Files[0];

        //         if (file.Length > 0)
        //         {
        //             string fileName = Guid.NewGuid() + ContentDispositionHeaderValue
        //             .Parse(file.ContentDisposition).FileName.Trim('"');
        //             string fullPath = Path.Combine(coverImageFolderPath, fileName);
        //             using (var stream = new FileStream(fullPath, FileMode.Create))
        //             {
        //                 file.CopyTo(stream);
        //             }
        //             book.CoverFileName = fileName;
        //         }
        //     }
        //     else
        //     {
        //         book.CoverFileName = _config["DefaultCoverImageFile"];
        //     }
        //     return _bookRepository.AddBook(book);
        // }

        /// <summary>
        /// Update a specific book.
        /// </summary>
        /// <returns></returns>
        // [HttpPut]
        // // [Bookize(Policy = UserRoles.Admin)]
        // public int Put()
        // {
        //     Book book = JsonConvert.DeserializeObject<Book>(Request.Form["bookFormData"].ToString());
        //     if (Request.Form.Files.Count > 0)
        //     {
        //         var file = Request.Form.Files[0];

        //         if (file.Length > 0)
        //         {
        //             string fileName = Guid.NewGuid() + ContentDispositionHeaderValue
        //             .Parse(file.ContentDisposition).FileName.Trim('"');
        //             string fullPath = Path.Combine(coverImageFolderPath, fileName);
        //             bool isFileExists = Directory.Exists(fullPath);

        //             if (!isFileExists)
        //             {
        //                 using (var stream = new FileStream(fullPath, FileMode.Create))
        //                 {
        //                     file.CopyTo(stream);
        //                 }
        //                 book.CoverFileName = fileName;
        //             }
        //         }
        //     }
        //     return _bookRepository.UpdateBook(book);
        // }

        /// <summary>
        /// Delete a specific book.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        // [HttpDelete("{bookId}")]
        //  // [Bookize(Policy = UserRoles.Admin)]
        // public int Delete(Guid bookId)
        // {
        //     string coverFileName = _bookRepository.DeleteBook(bookId);
        //     if (coverFileName != _config["DefaultCoverImageFile"])
        //     {
        //         string fullPath = Path.Combine(coverImageFolderPath, coverFileName);
        //         if (System.IO.File.Exists(fullPath))
        //         {
        //             System.IO.File.Delete(fullPath);
        //         }
        //     }
        //     return 1;
        // }

  

     

        
    }
}

   