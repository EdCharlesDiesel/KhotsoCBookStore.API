using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarPeaceAdminHubDB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDB.Extensions
{
    // It reads the entity from the database and formally removes it from the Packages
    // dataset. This will force the entity to be deleted in the database when changes are saved
    // to the database. Moreover, it adds PackageDeleteEvent to the aggregate list of events.
    // The Extensions folder contains the DBExtensions static class, which, in turn, defines
    // two extension methods to be added to the application DI engine and the ASP.NET
    // Core pipeline, respectively. Once added to the pipeline, these two methods will
    // connect the database layer to the application layer.
    // The IServiceCollection extension of AddDbLayer accepts (as its input parameters)
    // the database connection string and the name of the .dll file that contains all
    // migrations. Then, it does the following:
    public static class DBExtensions
    {

        // That is, it adds and configures all the types needed to handle database-based
        // authentication. In particular, it adds the UserManager and RoleManager types, which
        // the application layer can use to manage users and roles. AddDefaultTokenProviders
        // adds the provider that creates the authentication tokens using data contained in the
        // database when users log in.
        public static IServiceCollection AddDbLayer(this IServiceCollection services,
            string connectionString, string migrationAssembly)
        {
            services.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssembly)));
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
                .AddEntityFrameworkStores<MainDbContext>()
                .AddDefaultTokenProviders();
            services.AddAllRepositories(typeof(DBExtensions).Assembly);
            return services;
        }

        public static async Task Seed(this MainDbContext context, IServiceScope serviceScope)
        {
            await context.Database.MigrateAsync();

            if (!await context.Roles.AnyAsync())
            {
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole<int>>>();
                var role = new IdentityRole<int> { Name = "Admins" };
                await roleManager.CreateAsync(role);

            }
            
            if (!await context.Users.AnyAsync())
            {

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser<int>>>();
                string user = "Admin";
                string password = "_Admin_pwd1";
                IdentityUser<int> currUser = null;
                var result = await userManager.CreateAsync(currUser = new IdentityUser<int> { UserName = user, Email = "admin@fakedomain.com", EmailConfirmed = true }, password);

                await userManager.AddToRoleAsync(currUser, "Admins");

            }

            if (!await context.Books.AnyAsync())
            {
                var firstBook = new Book
                {
                    Title = "Beginning SOLID Principles and Design Patterns for ASP.NET Developers",
                    ISBN = "XXX-00000-000-YGB",
                    Description = "SOLID Principles and Design Patterns",
                    CoverFileName = "Default Cover",
                    Cost = 750.00M,
                    RetailPrice = 1250.99M,
                    PublishingDate = new DateTime(2016,01,01),
                    EntityVersion = 1,
                    Categorys = new List<Category>()
                        {
                            new Category
                            {
                                CategoryName = "Design Patterns",
                                EntityVersion = 1
                            },
                            new Category
                            {
                                CategoryName = "Asp.Net",
                                EntityVersion = 1
                            }
                        }
                };

                var secondBook = new Book
                {
                    Title = "Software Architecture with C# 9 and .NET 5",
                    ISBN = "XXX-00000-000-2nd",
                    Description = "Architecting software solutions using microservices,DevOps, and design patterns for Azure",
                    CoverFileName = "Default Cover",
                    Cost = 1200.00M,
                    RetailPrice = 2250.99M,
                    PublishingDate = new DateTime(2016,01,01),
                    EntityVersion = 1,
                    Categorys = new List<Category>()
                        {
                            new Category
                            {
                                CategoryName = "Design Patterns",
                                EntityVersion = 1
                            },
                            new Category
                            {
                                CategoryName = "Asp.Net",
                                EntityVersion = 1
                            },
                            new Category
                            {
                                CategoryName = "Architecture",
                                EntityVersion = 1
                            }
                        }
                };

                var thirdBook = new Book
                {
                    Title = "FUNDAMENTALS OF COMPUTER PROGRAMMING WITH C#",
                    ISBN = "XXX-00000-000-6TG",
                    Description = "The Bulgarian C# Programming Book",
                    CoverFileName = "Default Cover",
                    Cost = 5200.00M,
                    RetailPrice = 250.99M,
                    PublishingDate = new DateTime(2016,01,01),
                    EntityVersion = 1,
                    Categorys = new List<Category>()
                        {
                            new Category
                            {
                                CategoryName = "C#",
                                EntityVersion = 1

                            },
                            new Category
                            {
                                CategoryName = "Funadamentals",
                                EntityVersion = 1
                            }                            
                        }
                };

                var fourthBook = new Book
                {
                    Title = "xUnit Test Patterns",
                    ISBN = "XXX-00000-000-XUN",
                    Description = "",
                    CoverFileName = "Default Cover",
                    Cost = 600.00M,
                    RetailPrice = 850.99M,
                    PublishingDate = new DateTime(2016,01,01),
                    EntityVersion = 1,
                    Categorys = new List<Category>()
                        {                 
                            new Category
                            {
                                CategoryName = "Unit Testing",
                                EntityVersion = 1
                            }                            
                        }
                };
                
                context.Books.Add(firstBook);
                context.Books.Add(secondBook);
                context.Books.Add(thirdBook);
                await context.SaveChangesAsync();
            }
        }

    }
}
