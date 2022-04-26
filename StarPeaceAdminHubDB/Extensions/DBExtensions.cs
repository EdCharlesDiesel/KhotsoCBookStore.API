using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarPeaceAdminHubDB.Contexts;
using StarPeaceAdminHubDB.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDB.Extensions
{
    public static class DBExtensions
    {
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
            

                 var firstBook = new Book
                    {
                        BookId = Guid.NewGuid(),
                        Title = "Software Architecture with C# 9 and .NET 5",
                        Cost = 750.00M,
                        CoverFileName = "Default Cover",
                        Description = "Architecting software solutions using microservices/,DevOps, and design patterns for Azure",
                        DurationOnShelfInDays = 0,
                        RetailPrice = 1250.00M,
                        PublisheredDate = new DateTime(2019, 6, 1),
                        StartValidityDate = new DateTime(2019, 6, 1),
                        EndValidityDate= new DateTime(2019, 6, 1),
                        Categories = new List<Category>()
                                    {
                                        new Category
                                        {
                                            CategoryName ="Software Architecture"
                                        },
                                        new Category
                                        {
                                            CategoryName ="C#"
                                        }
                                    } 

            };

            if (!await context.Publishers.AnyAsync())
            
                var firstPublisher = new Publisher
                {
                    PublisherName = "Packt",
                    PublisherId = Guid.NewGuid(),
                    EmailAddress = "packt@CusstomerInfo.com",
                    PhoneNumber = "000 00 0000",
                    Books = new List<Book>()                                                                       
                };
            context.Books.Add(firstBook);            
            await context.SaveChangesAsync();
            
        }

    }
}
