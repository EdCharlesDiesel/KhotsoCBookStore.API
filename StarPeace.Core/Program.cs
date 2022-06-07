using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StarPeaceAdminHubDB.Models;
using StarPeaceAdminHubDB;
using System.Globalization;

namespace StarPeace.CoreTest
{
    class Program
    {

        public class BookEx
        {
            public string Title { get; set; }
            public int AuthorId { get; set; }
        }
        public class AuthorEx
        {
            public int AuthorId { get; set; }
            public string FullName { get; set; }
        }
        static void Main(string[] args)
        {

            List<AuthorEx> authors = new List<AuthorEx>()
            {
                new AuthorEx() { AuthorId = 1, FullName = "Fruit" },
                new AuthorEx() { AuthorId = 2, FullName = "Food" },
                new AuthorEx() { AuthorId = 3, FullName = "Shoe" },
                new AuthorEx() { AuthorId = 4, FullName = "Juice" },
            };

            List<BookEx> books = new List<BookEx>()
            {
                new BookEx() { Title = "Strawberry", AuthorId = 1 },
                new BookEx() { Title = "Banana", AuthorId = 1 },
                new BookEx() { Title = "Chicken meat", AuthorId = 2 },
                new BookEx() { Title = "Apple Juice", AuthorId = 4 },
                new BookEx() { Title = "Fish", AuthorId = 2 },
                new BookEx() { Title = "Orange Juice", AuthorId = 4 },
                new BookEx() { Title = "Sandal", AuthorId = 3 },
            };

            var booksWithAuthors = 
            from book in books
            join author in authors
             on book.AuthorId equals author.AuthorId
             select new { FullName = book.Title,
                            AuthorsName = author.FullName};
            foreach( var item in booksWithAuthors)
            {
                Console.WriteLine(item);
            }    

            // Console.WriteLine("program start: populate database, please enter any key proceed");
            // Console.ReadKey();

            // var context = new LibraryDesignTimeDbContextFactory()
            //     .CreateDbContext();
            // var firstBook = new Book
            // {
            //     ISBN = "XXX-2568-CSharp",
            //     Title = "Fundamentals of Computer Programming with C#",
            //     Description = "The Bulgarian C# Programming Book",
            //     PublishingDate = new DateTime(2012 / 01 / 01),
            //     Cost = 700,
            //     RetailPrice = 1200,
            //     CoverFileName = "Dafault_Cover.jpg",
            //     EntityVersion = 1,
            //     Authors = new List<Author>()
            //             {
            //                 new Author
            //                 {
            //                     BookId = 1,
            //                     FirstName ="Svetlin",
            //                     LastName = "Nakov",
            //                     BookStartPrice = 1000,
            //                     EntityVersion =1,
            //                     StartPublishingDate = new DateTime(2012/01/01),
            //                     EndPublishingDate = new DateTime(2012/12/01)
            //                 }
            //             }
            // };

            // context.Books.Add(firstBook);
            // context.SaveChanges();
            // Console.WriteLine(
            //     "DB populated: first book id is " +
            //     firstBook.Id + "please press any key when you are done.");
            // Console.ReadKey();

            // var secondBook = new Book
            // {
            //     ISBN = "XXX-2258-Architecture",
            //     Title = "Software Architecture with C# 9 and .NET 5",
            //     Description = "Architecting software solutions using microservices, DevOps, and design patterns for Azure",
            //     PublishingDate = new DateTime(2021 / 01 / 01),
            //     Cost = 900,
            //     RetailPrice = 1500,
            //     CoverFileName = "Dafault_Cover.jpg",
            //     EntityVersion = 1,
            //     Authors = new List<Author>()
            //             {
            //                 new Author
            //                 {
            //                     BookId = 2,
            //                     FirstName ="Francesco",
            //                     LastName = "Abbruzzese",
            //                     BookStartPrice = 1000,
            //                     StartPublishingDate = new DateTime(2021/01/01),
            //                     EndPublishingDate = new DateTime(2021/12/01),
            //                     EntityVersion =1,
            //                 },
            //                 new Author
            //                 {
            //                     BookId = 2,
            //                     FirstName ="Gabriel",
            //                     LastName = "Baptista",
            //                     BookStartPrice = 1000,
            //                     StartPublishingDate = new DateTime(2021/01/01),
            //                     EndPublishingDate = new DateTime(2021/12/01),
            //                     EntityVersion =1,
            //                 }
            //             }
            // };

//             // var listofCost = context.Books.Select(c => c.Cost).ToList();
//             // var orderedBooks = context.Books.OrderByDescending(x => x.Title);
//             // foreach (var cost in listofCost)
//             // {
//             //     System.Console.WriteLine(cost);
//             // }

//             // foreach (var item in orderedBooks)
//             // {
//             //     System.Console.WriteLine("Book {0} is selling for {1}.", item.Title, item.RetailPrice);
//             // }

//             // var cultures = from culture in
//             // CultureInfo.GetCultures(CultureTypes.AllCultures)
//             //                select culture;

//             // foreach (var item in cultures)
//             // {
//             //     System.Console.WriteLine("for culture type is {0}", item);
//             // }




//             // context.Books.Add(secondBook);
//             // context.SaveChanges();
//             // Console.WriteLine(
//             //     "DB populated: second book id is " +
//             //     secondBook.Id + "please press any key when you are done.");
//             // Console.ReadKey();

//             // var toModify = context.Destinations
//             //     .Where(m => m.Name == "Florence")
//             //     .Include(m => m.Packages)
//             //     .FirstOrDefault();

//             // toModify.Description = 
//             //                 "Florence is a famous historical Italian town";
//             // foreach (var package in toModify.Packages)
//             //                 package.Price = package.Price * 1.1m;
//             // context.SaveChanges();

//             // var verifyChanges= context.Destinations
//             //         .Where(m => m.Name == "Florence")
//             //         .FirstOrDefault();

//             // Console.WriteLine(
//             //     "New Florence description: " +
//             //     verifyChanges.Description);
//             // Console.ReadKey();
//             // var period = new DateTime(2019, 8, 10);
//             // var list = context.Packages
//             //     .Where(m => period >= m.StartValidityDate
//             //     && period <= m.EndValidityDate)
//             //     .Select(m => new PackagesListDTO
//             //     {
//             //         StartValidityDate=m.StartValidityDate,
//             //         EndValidityDate=m.EndValidityDate,
//             //         Name=m.Name,
//             //         DurationInDays=m.DurationInDays,
//             //         Id=m.Id,
//             //         Price=m.Price,
//             //         DestinationName=m.MyDestination.Name,
//             //         DestinationId = m.DestinationId
//             //     })
//             //     .ToList();
//             // foreach (var result in list)
//             //     Console.WriteLine(result.ToString());
//             // Console.ReadKey();

        }

    }
}

// namespace KhotsoTest
// {
// 	public class Book
// 	{
// 		public int BookId {get; set;}
// 		public string Title {get; set;}
// 	}

// 	public class Author
// 	{
// 		public int AuthorId {get; set;}
// 		public str FullName {get; set;}
// 	}

// 	public class Program
// 	{
// 		public static void Main()
// 		{
// 			var books = new List<Book>()
// 			{
// 				new Book
// 				{
// 					BookId = 1,
// 					Title = "I love C#"				
// 				},
// 				new Book
// 				{
// 					BookId = 2,
// 					Title = "I love F#"				
// 				},
// 				new Book
// 				{
// 					BookId = 3,
// 					Title = "I love TypeScript"				
// 				}	
// 			};
			
// 			var authors = new List<Author>()
// 			{
// 				new Author
// 				{
// 					AuthorId = 1,
// 					FullName = "Khotso Charles"				
// 				},
// 				new Author
// 				{
// 					AuthorId = 2,
// 					FullName = "Shante Chetty"				
// 				},
// 				new Author
// 				{
// 					AuthorId = 3,
// 					FullName = "Scott Hasleman"				
// 				}	
// 			};
			
// 			var booksWithAuthors = from mybooks in Book
// 									join myAuthors in Author
// 									on mybooks.BookId equals myAuthors.AuthorId
// 									select new { BookTitle = mybooks.Title,
// 									AuthorFullName = myAuthors.FullName}};
									
// 			foreach( var item in booksWithAuthors )
// 			{
// 				System.Console.WriteLine("Book with {0}",item);
// 			}
// 		}
// 	}
// }


