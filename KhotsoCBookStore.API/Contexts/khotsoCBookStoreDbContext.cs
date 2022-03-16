using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace KhotsoCBookStore.API.Contexts
{
    public partial class KhotsoCBookStoreDbContext : DbContext
    {
        public KhotsoCBookStoreDbContext()
        {
        }

        public KhotsoCBookStoreDbContext(DbContextOptions<KhotsoCBookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ProductSubscription> ProductSubscriptions { get; set; }
        public virtual DbSet<ProductSubscriptionItem> ProductSubscriptionItems { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(
                 new UserType
                 {
                     UserTypeId = 1,
                     UserTypeName = "Admin"
                 },
                   new UserType
                   {
                       UserTypeId = 2,
                       UserTypeName = "User"
                   }
                );

            

            modelBuilder.Entity<Employee>().HasData
            (
                new Employee
                {
                    FirstName = "Khotso",
                    LastName = "Mokhethi",
                    EmployeeNumber = "EMP-001",
                    DateOfBirth = new System.DateTime(1988, 08, 05),
                    DateOfStartEmployment = new DateTime(2022, 03, 16)
                }
            );

            modelBuilder.Entity<Customer>().HasData
            (
                new Customer
                {
                    Id = new Guid("FEB6F8D2-A51A-4EC6-8812-71A2C1819601"),
                    FirstName = "Khotso",
                    LastName = "Mokhethi",
                    Address = "Mandela Street Sandton Drive",
                    City = "Sandton",
                    Province = "Gauteng",
                    Postal = 2007
                },
               new Customer
               {
                   Id = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6"),
                   FirstName = "Kagiso",
                   LastName = "Mokhethi",
                   Address = "Mandela Street Sandton Drive",
                   City = "Sandton",
                   Province = "Gauteng",
                   Postal = 2007
               }
            );

            modelBuilder.Entity<Order>().HasData
            (
                new Order
                {
                    OrderId = Guid.NewGuid(),
                    CustomerId = new Guid("FEB6F8D2-A51A-4EC6-8812-71A2C1819601"),
                    OrderDate = DateTime.Today,
                    ShipAddress = "Mandela Street Sandton Drive",
                    CartTotal = 15.44M,
                    ShipDate = DateTime.Now
                },
               new Order
               {
                   OrderId = Guid.NewGuid(),
                   CustomerId = new Guid("300F030A-8226-40A0-95F5-52D55B4242D6"),
                   OrderDate = DateTime.Today,
                   ShipAddress = "Mandela Street Sandton Drive",
                   CartTotal = 15.44M,
                   ShipDate = DateTime.Now
               }
            );


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
