// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using WorldCities.Data;
// using OfficeOpenXml;
// using System.IO;
// using Microsoft.AspNetCore.Hosting;
// using WorldCities.Data.Models;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Hosting;
// using System.Security;
// using KhotsoCBookStore.API.Contexts;
// using KhotsoCBookStore.API.Entities;

// namespace WorldCities.Controllers
// {
//     [Route("api/[controller]/[action]")]
//     [ApiController]
//     [Authorize]
//     public class SeedController : ControllerBase
//     {

//         private readonly KhotsoCBookStoreDbContext _dbContext;
//         private readonly IWebHostEnvironment _env;

//         public SeedController(
//         KhotsoCBookStoreDbContext dbContext,
//         IWebHostEnvironment env)
//         {
//             _dbContext = dbContext;
//             _env = env;
//         }
//         [HttpGet]
//         public async Task<ActionResult> Import()
//         {
//             // prevents non-development environments from running this method
//             if (!_env.IsDevelopment())
//                 throw new SecurityException("Not allowed");
//             var path = Path.Combine(
//             _env.ContentRootPath,
//             "Data/Source/worldcities.xlsx");
//             using var stream = System.IO.File.OpenRead(path);
//             using var excelPackage = new ExcelPackage(stream);
//             // get the first worksheet
//             var worksheet = excelPackage.Workbook.Worksheets[0];
//             // define how many rows we want to process
//             var nEndRow = worksheet.Dimension.End.Row;
//             // initialize the record counters
//             var numberOfAuthorsAdded = 0;
//             var numberOfCitiesAdded = 0;
//             // create a lookup dictionary
//             // containing all the countries already existing
//             // into the Database (it will be empty on first run).
//             var countriesByName = _dbContext.Authors
//             .AsNoTracking()
//             .ToDictionary(x => x.Name, StringComparer.OrdinalIgnoreCase);
//             // iterates through all rows, skipping the first one
//             for (int nRow = 2; nRow <= nEndRow; nRow++)
//             {
//                 var row = worksheet.Cells[
//                 nRow, 1, nRow, worksheet.Dimension.End.Column];
//                 var authorName = row[nRow, 5].GetValue<string>();
//                 var iso2 = row[nRow, 6].GetValue<string>();
//                 var iso3 = row[nRow, 7].GetValue<string>();
//                 // skip this author if it already exists in the database
//                 if (countriesByName.ContainsKey(authorName))
//                     continue;
//                 // create the Author entity and fill it with xlsx data
//                 var author = new Author
//                 {
//                     Name = authorName,
//                     ISO2 = iso2,
//                     ISO3 = iso3
//                 };
//                 // add the new author to the DB dbContext
//                 await _dbContext.Authors.AddAsync(author);
//                 // store the author in our lookup to retrieve its Id later on
//                 countriesByName.Add(authorName, author);
//                 // increment the counter
//                 numberOfAuthorsAdded++;
//             }
//             // save all the countries into the Database
//             if (numberOfAuthorsAdded > 0)
//                 await _dbContext.SaveChangesAsync();
//             // create a lookup dictionary
//             // containing all the cities already existing
//             // into the Database (it will be empty on first run).
//             var cities = _dbContext.Cities
//             .AsNoTracking()
//             .ToDictionary(x => (
//             Name: x.Name,
//             Lat: x.Lat,
//             Lon: x.Lon,
//             AuthorId: x.AuthorId));
//             // iterates through all rows, skipping the first one
//             for (int nRow = 2; nRow <= nEndRow; nRow++)
//             {
//                 var row = worksheet.Cells[
//                 nRow, 1, nRow, worksheet.Dimension.End.Column];
//                 var name = row[nRow, 1].GetValue<string>();
//                 var nameAscii = row[nRow, 2].GetValue<string>();
//                 var lat = row[nRow, 3].GetValue<decimal>();
//                 var lon = row[nRow, 4].GetValue<decimal>();
//                 var authorName = row[nRow, 5].GetValue<string>();
//                 // retrieve author Id by authorName
//                 var authorId = countriesByName[authorName].Id;
//                 // skip this city if it already exists in the database
//                 if (cities.ContainsKey((
//                 Name: name,
//                 Lat: lat,
//                 Lon: lon,
//                 AuthorId: authorId)))
//                     continue;
//                 // create the City entity and fill it with xlsx data
//                 var city = new City
//                 {
//                     Name = name,
//                     Name_ASCII = nameAscii,
//                     Lat = lat,
//                     Lon = lon,
//                     AuthorId = authorId
//                 };
//                 // add the new city to the DB dbContext
//                 _dbContext.Cities.Add(city);
//                 // increment the counter
//                 numberOfCitiesAdded++;
//             }
//             // save all the cities into the Database
//             if (numberOfCitiesAdded > 0)
//                 await _dbContext.SaveChangesAsync();
//             return new JsonResult(new
//             {
//                 Cities = numberOfCitiesAdded,
//                 Authors = numberOfAuthorsAdded
//             });
//         }
//     }
// }