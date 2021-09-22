using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Entities;
using KhotsoCBookStore.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KhotsoCBookStore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        readonly IWebHostEnvironment _hostingEnvironment;
        readonly IBookService _bookService;
        readonly IConfiguration _config;
        readonly string coverImageFolderPath = string.Empty;

        public BookController(IConfiguration config, IWebHostEnvironment hostingEnvironment, IBookService bookService)
        {
            _config = config;
            _bookService = bookService?? throw new ArgumentNullException(nameof(_bookService));
            _hostingEnvironment = hostingEnvironment;
            coverImageFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Upload");
            if (!Directory.Exists(coverImageFolderPath))
            {
                Directory.CreateDirectory(coverImageFolderPath);
            }
        }

        /// <summary>
        /// List of all the actions that are allows with this API
        /// </summary>
        /// <returns>An IActionResult of actions allowed</returns>
        [HttpOptions]
        public IActionResult GetBooksAPIOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,DELETE,PUT,PATCH");
            return Ok();
        }     

        /// <summary>
        /// Get all the books
        /// </summary>
        /// <returns>An ActionResult of type Book</returns>
        /// <response code="200">Returns the requested books</response>
        /// <response code="404">Returns no books found</response>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await Task.FromResult(_bookService.GetAllBooks()).ConfigureAwait(true);            
        }

        /// <summary>
        /// Get the specific book data corresponding to the BookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId)
        {
            Book book = _bookService.GetBookData(bookId);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        /// <summary>
        /// Get the list of available categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCategoriesList")]
        public async Task<IEnumerable<Categories>> CategoryDetails()
        {
            return await Task.FromResult(_bookService.GetCategories()).ConfigureAwait(true);
        }    

        /// <summary>
        /// Add a new book record
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
      //  [Authorize(Policy = UserRoles.Admin)]
        public int Post()
        {
            Book book = JsonConvert.DeserializeObject<Book>(Request.Form["bookFormData"].ToString());

            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(coverImageFolderPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    book.CoverFileName = fileName;
                }
            }
            else
            {
                book.CoverFileName = _config["DefaultCoverImageFile"];
            }
            return _bookService.AddBook(book);
        }

        /// <summary>
        /// Update a particular book record
        /// </summary>
        /// <returns></returns>
        [HttpPut]
      //  [Authorize(Policy = UserRoles.Admin)]
        public int Put()
        {
            Book book = JsonConvert.DeserializeObject<Book>(Request.Form["bookFormData"].ToString());
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(coverImageFolderPath, fileName);
                    bool isFileExists = Directory.Exists(fullPath);

                    if (!isFileExists)
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        book.CoverFileName = fileName;
                    }
                }
            }
            return _bookService.UpdateBook(book);
        }

        /// <summary>
        /// Delete a particular book record
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{bookId}")]
     //   [Authorize(Policy = UserRoles.Admin)]
        public int Delete(int bookId)
        {
            string coverFileName = _bookService.DeleteBook(bookId);
            if (coverFileName != _config["DefaultCoverImageFile"])
            {
                string fullPath = Path.Combine(coverImageFolderPath, coverFileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            return 1;
        }
    }
}
