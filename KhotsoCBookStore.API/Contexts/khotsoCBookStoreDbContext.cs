using System;
using System.Collections.Generic;

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

        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
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
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
