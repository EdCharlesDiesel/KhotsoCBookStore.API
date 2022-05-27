using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhotsoCBookStore.API.Contexts
{
    public partial class KhotsoCBookStoreDbContext : DbContext
    {

        public KhotsoCBookStoreDbContext(DbContextOptions<KhotsoCBookStoreDbContext> options)
            : base(options)
        {
        }

        // public virtual DbSet<Publisher> Publishers { get; set; }
        // public virtual DbSet<Promotion> Promotions { get; set; }
        // public virtual DbSet<Author> Authors { get; set; }
        // public virtual DbSet<Customer> Customers { get; set; }
        // public virtual DbSet<Employee> Employees { get; set; }
        // public virtual DbSet<Book> Books { get; set; }
        // public virtual DbSet<ProductSubscription> ProductSubscriptions { get; set; }
        // public virtual DbSet<ProductSubscriptionItem> ProductSubscriptionItems { get; set; }
        // public virtual DbSet<Cart> Carts { get; set; }
        // public virtual DbSet<CartItem> CartItems { get; set; }
        // public virtual DbSet<Category> Categories { get; set; }
        // public virtual DbSet<OrderItem> OrderItems { get; set; }
        // public virtual DbSet<Order> Orders { get; set; }
        // public virtual DbSet<UserType> UserTypes { get; set; }
        // public virtual DbSet<UserMaster> UserMasters { get; set; }
        // public virtual DbSet<WishList> WishLists { get; set; }
        // public virtual DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<UserType>().HasData
            // (
            //     new UserType
            //     {
            //         UserTypeId = new Guid("2A342C4E-6B32-46E6-BA0A-509C39F044AC"),
            //         UserTypeName = "Admin"
            //     },
            //     new UserType
            //     {
            //         UserTypeId = new Guid("EB687590-B398-400A-B14F-4EFB4D6B728E"),
            //         UserTypeName = "User"
            //     }
            // );

            // modelBuilder.Entity<UserMaster>().HasData
            // (
            //     new UserMaster
            //     {
            //         FirstName = "Charles",
            //         LastName = "Mokhethi",
            //         Username = "EdCharles",
            //         Password = "12345"      
            //     },
            //     new UserMaster
            //     {
            //         FirstName = "Otsile",
            //         LastName = "Mokhethi",
            //         Username = "EdCharles",
            //         Password = "12345"
            //     }
            // );

            // modelBuilder.Entity<UserType>().HasData
            // (
            //     new UserType
            //     {
            //        UserTypeId = new Guid("0083FD68-2A81-48D1-81DE-FFC82D18D564"),
            //        UserTypeName ="Developer"     
            //     },
            //     new UserType
            //     {
            //        UserTypeId = new Guid("74CA3B3F-14D0-4199-B633-110DED2E98BC"),
            //        UserTypeName ="Administrator"
            //     },
            //     new UserType
            //     {
            //        UserTypeId = new Guid("602F28D4-5DE7-4D2B-8DEE-978AA53502F7"),
            //        UserTypeName ="Product Owner"
            //     }
            // );

            // modelBuilder.Entity<Employee>().HasData
            // (
            //     new Employee
            //     {
            //         EmployeeId = new Guid("602F28D4-5DE7-4D2B-8DEE-978AA55802F7"),
            //         FirstName = "Khotso",
            //         LastName = "Mokhethi",
            //         EmployeeNumber = "EMP-001",
            //         DateOfBirth = new System.DateTime(1988, 08, 05),
            //         DateOfStartEmployment = new DateTime(2022, 03, 16)
            //     }
            // );

            // modelBuilder.Entity<Customer>().HasData
            // (
            //     new Customer
            //     {
            //         CustomerId = new Guid("FEB6F8D2-A51A-4EC6-8812-71A2C1819601"),
            //         FirstName = "Khotso",
            //         LastName = "Mokhethi",
            //         Address = "Mandela Street Sandton Drive",
            //         City = "Sandton",
            //         Province = "Gauteng",
            //         Postal = 2007,
            //         DateOfBirth =DateTime.Now,
            //         EmailAddress= "Mokhethi@hotmail.com",
            //         Username="EdCharlesDiesel"
            //     },
            //    new Customer
            //    {
            //        CustomerId = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6"),
            //        FirstName = "Kagiso",
            //        LastName = "Mokhethi",
            //        Address = "Mandela Street Sandton Drive",
            //        City = "Sandton",
            //        Province = "Gauteng",
            //         Postal = 2007,
            //         DateOfBirth =DateTime.Now,
            //         EmailAddress= "Mokhethi@hotmail.com",
            //         Username="EdCharlesDiesel",
            //         Orders= new List<Order>()
            //    }
            // );

            // // modelBuilder.Entity<Order>().HasData
            // // (
            // //     new Order
            // //     {
            // //         OrderId = Guid.NewGuid(),
            // //         CustomerId = new Guid("FEB6F8D2-A51A-4EC6-8812-71A2C1819601"),
            // //         OrderDate = DateTime.Today,
            // //         ShipAddress = "Mandela Street Sandton Drive",
            // //         CartTotal = 15.44M,
            // //         ShipDate = DateTime.Now
            // //     },
            // //    new Order
            // //    {
            // //        OrderId = Guid.NewGuid(),
            // //        CustomerId = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6"),
            // //        OrderDate = DateTime.Today,
            // //        ShipAddress = "Mandela Street Sandton Drive",
            // //        CartTotal = 15.44M,
            // //        ShipDate = DateTime.Now
            // //    }
            // // );

            // modelBuilder.Entity<Author>().HasData
            // (
            //     new Author
            //     {
            //         AuthorId = Guid.NewGuid(),
            //         FirstName = "Neil",
            //         LastName ="Bohr"
            //     },
            //    new Author
            //    {
            //         AuthorId = Guid.NewGuid(),
            //         FirstName = "Sir Issac",
            //         LastName ="Newton"
            //    }
            // );

            // modelBuilder.Entity<Category>().HasData
            // (
            //     new Category
            //     {
            //        CategoryId = Guid.NewGuid(),
            //        CategoryName ="Development"
            //     },
            //    new Category
            //    {
            //           CategoryId = Guid.NewGuid(),
            //        CategoryName ="SQL"
            //    }
            // );

            //  modelBuilder.Entity<Publisher>().HasData
            // (
            //     new Publisher
            //     {
            //        PublisherId = Guid.NewGuid(),
            //        Name="Miller",
            //        EmailAddress="Mokhetkc@hotmail.com"
            //     },
            //    new Publisher
            //    {
            //         PublisherId = Guid.NewGuid(),
            //        Name="Anton",
            //        EmailAddress="Mokhethi@hotmail.com"
            //    }
            // );



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
