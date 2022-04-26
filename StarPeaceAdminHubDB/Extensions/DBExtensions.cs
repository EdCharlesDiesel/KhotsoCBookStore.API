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
            {
                var firstBook = new Book
                {
                    Title = "Beginning SOLID Principles and Design Patterns for ASP.NET Developers",
                    ISBN = "XXX-00000-000-YGB",
                    CoverFileName = "Default Cover",
                    Cost = 750.00M,
                    RetailPrice = 1250.99M,
                    PublishingDate = DateTime(2016,01,01),
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
                                EntityVersion=1
                            }
                        }
                };
                context.Books.Add(firstBook);
                await context.SaveChangesAsync();
            }
        }

    }
}
