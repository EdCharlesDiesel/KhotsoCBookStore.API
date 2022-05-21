using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarPeaceAdminHubDB;
using StarPeaceAdminHubDB.Models;

namespace StarPeaceAdminHubDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("program start: populate database");
            Console.ReadKey();

            var context = new LibraryDesignTimeDbContextFactory()
                .CreateDbContext();

            var firstBook = new Book
            {
                Title = "Software Architecture with C# 9 and .NET 5",
                ISBN = "XXX-2257-CSHA",
                Description = "Architecting software solutions using microservices,DevOps, and design patterns for Azure",
                PublishingDate = new DateTime(2020, 6, 1),
                Cost = 700,
                RetailPrice = 1500,
                CoverFileName = "Default Image",
                Authors = new List<Author>()
                {
                    new Author
                    {
                        FirstName ="Gabriel",
                        LastName="Baptista",
                        StartPublishingDate = new DateTime(2019, 6, 1),
                        EndPublishingDate = new DateTime(2019, 6, 1),
                        BookStartPrice  = 1000
                    },
                    new Author
                    {
                        FirstName ="Francesco",
                        LastName="Abbruzzese",
                        StartPublishingDate = new DateTime(2019, 6, 1),
                        EndPublishingDate = new DateTime(2019, 6, 1),
                        BookStartPrice  = 1000
                    }
                }
            };
            context.Books.Add(firstBook);
            context.SaveChanges();
            Console.WriteLine(
                "DB populated: first Book id is " +
                firstBook.Id);
            Console.ReadKey();

            var toModify = context.Books
                .Where(m => m.Title == "Software Architecture with C# 9 and .NET 5")
                .Include(m => m.Authors)
                .FirstOrDefault();

            toModify.Description =
                            "Architecting software solutions using microservices";
            foreach (var Author in toModify.Authors)
                Author.BookStartPrice = Author.BookStartPrice * 1.1m;
            context.SaveChanges();

            var verifyChanges = context.Books
                    .Where(m => m.Title == "Software Architecture with C# 9 and .NET 5")
                    .FirstOrDefault();

            Console.WriteLine(
                "New Software Architecture description: " +
                verifyChanges.Description);
            Console.ReadKey();
            var period = new DateTime(2019, 8, 10);
            var list = context.Authors
                .Select(m => new AuthorsListDTO
                {
                    Id = m.BookId,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    StartPublishingDate = m.StartPublishingDate,
                    EndPublishingDate = m.EndPublishingDate
                })
                .ToList();
            foreach (var result in list)
            Console.WriteLine(result.ToString());
            Console.ReadKey();

        }

    }

}