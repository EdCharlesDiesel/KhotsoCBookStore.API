using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security;
using KhotsoCBookStore.API.Contexts;
using KhotsoCBookStore.API.Entities;

namespace WorldBooks.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class SeedController : ControllerBase
    {
        private readonly KhotsoCBookStoreDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        public SeedController(KhotsoCBookStoreDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _env = env?? throw new ArgumentNullException(nameof(_env));
        }
        [HttpGet]
        public async Task<ActionResult> Import()
        {
            // prevents non-development environments from running this method
            if (!_env.IsDevelopment())
                throw new SecurityException("Not allowed");

            var path = Path.Combine(_env.ContentRootPath,"Data/Source/KhotsoCBookStoreSeedData.xlsx");

            using var stream = System.IO.File.OpenRead(path);
            using var excelPackage = new ExcelPackage(stream);

            // get the first worksheet
            var worksheet = excelPackage.Workbook.Worksheets[0];
            
            // define how many rows we want to process
            var nEndRow = worksheet.Dimension.End.Row;
            
            // initialize the record counters
            var numberOfAuthorsAdded = 0;
            //var numberOfBooksAdded = 0;
            
            // create a lookup dictionary
            // containing all the authors already existing
            // into the Database (it will be empty on first run).
            var  authorsbyName = _dbContext.Authors
            .AsNoTracking()
            .ToDictionary(x => x.FirstName, StringComparer.OrdinalIgnoreCase);
            
            // iterates through all rows, skipping the first one
            for (int nRow = 2; nRow <= nEndRow; nRow++)
            {
                var row = worksheet.Cells[
                nRow, 1, nRow, worksheet.Dimension.End.Column];
                var authorName = row[nRow, 5].GetValue<string>();
                var firstName = row[nRow, 6].GetValue<string>();
                var lastName = row[nRow, 7].GetValue<string>();
                
                // skip this author if it already exists in the database
                if (authorsbyName.ContainsKey(authorName))
                    continue;
                // create the Author entity and fill it with xlsx data
                var author = new Author
                {
                   AuthorId = new Guid(),
                   FirstName = firstName,
                   LastName = lastName
                };
                
                // add the new author to the DB dbContext
                await _dbContext.Authors.AddAsync(author);
                
                // store the author in our lookup to retrieve its Id later on
                authorsbyName.Add(authorName, author);
                
                // increment the counter
                numberOfAuthorsAdded++;
            }

            // save all the authors into the Database
            if (numberOfAuthorsAdded > 0)
                await _dbContext.SaveChangesAsync();
            
            // create a lookup dictionary
            // containing all the books already existing
            // into the Database (it will be empty on first run).
            // var books = _dbContext.Books
            // .AsNoTracking()
            // .ToDictionary(x => (
            // Name: x.Name,
            // Lat: x.Lat,
            // Lon: x.Lon,
            // AuthorId: x.AuthorId));
            
            // iterates through all rows, skipping the first one
            // for (int nRow = 2; nRow <= nEndRow; nRow++)
            // {
            //     var row = worksheet.Cells[
            //     nRow, 1, nRow, worksheet.Dimension.End.Column];
            //     var name = row[nRow, 1].GetValue<string>();
            //     var nameAscii = row[nRow, 2].GetValue<string>();
            //     var lat = row[nRow, 3].GetValue<decimal>();
            //     var lon = row[nRow, 4].GetValue<decimal>();
            //     var authorName = row[nRow, 5].GetValue<string>();
                
            //     // retrieve author Id by authorName
            //     var authorId = authorsbyName[authorName].AuthorId;
                
            //     // skip this book if it already exists in the database
            //     // if (books.ContainsKey((
            //     // Name: name,
            //     // Lat: lat,
            //     // Lon: lon,
            //     // AuthorId: authorId)))
            //     //     continue;
                
            //     // create the Book entity and fill it with xlsx data
            //     // var book = new Book
            //     // {
            //     //     Name = name,
            //     //     Name_ASCII = nameAscii,
            //     //     Lat = lat,
            //     //     Lon = lon,
            //     //     AuthorId = authorId
            //     // };
                
            //     // add the new book to the DB dbContext
            //     //_dbContext.Books.Add(book);
                
            //     // increment the counter
            //     numberOfBooksAdded++;
            // }
            
            // // save all the books into the Database
            // if (numberOfBooksAdded > 0)
            //     await _dbContext.SaveChangesAsync();

            return new JsonResult(new
            {
                //Books = numberOfBooksAdded,
                Authors = numberOfAuthorsAdded
            });
        }
    }
}