using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;

namespace StarPeaceAdminHubDB.Contexts
{
    public class MainDbContext: DbContext
    {
        
        public DbSet<BookSeriesExtras> BookSeriesExtras { get; set; }
        
        public DbSet<Publisher> Publishers { get; set; }
        
        public DbSet<Book> Books { get; set; }
        
        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        
        public DbSet<ProductSubscription> ProductSubscriptions { get; set; }

        public DbSet<ProductSubscriptionItem> ProductSubscriptionItems { get; set; }

        public DbSet<WishList> WishLists { get; set; }

        public DbSet<WishListItem> WishListItems { get; set; }
        
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
            .HasMany(m => m.Categories)
            .WithOne(m => m.Book)
            .HasForeignKey(m => m.BookId)
            .OnDelete(DeleteBehavior.Cascade);
            // ! Soft Delete will explorer later
            //.HasQueryFilter(m => !m.IsDeleted);

            builder.Entity<Publisher>()
            .HasMany(m => m.Books)
            .WithOne(m => m.Publisher)
            .HasForeignKey(m => m.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
            // ! Soft Delete will explorer later
            //.HasQueryFilter(m => !m.IsDeleted);

            builder.Entity<Order>()
            .HasMany(m => m.OrderItems)
            .WithOne(m => m.Order)
            .HasForeignKey(m => m.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
            .HasIndex(m => m.OrderDate);

            builder.Entity<Order>()
            .HasIndex(m => m.ShipDate);

            builder.Entity<Order>()
            .HasIndex(m => m.ShipAddress);

            builder.Entity<Order>()
            .Property(m => m.CartTotal)
            .HasPrecision(10, 3);


            builder.Entity<Book>()
            .HasIndex(m => m.Title);
            
            builder.Entity<Book>()
            .HasIndex(m => m.ISBN);

            builder.Entity<Book>()
            .HasIndex(m => m.Description);

            builder.Entity<Book>()
            .HasIndex(m => m.PublisheredDate);

            builder.Entity<Book>()
            .HasIndex(m => m.CoverFileName);

            builder.Entity<Book>()
            .Property(m => m.Cost)
            .HasPrecision(10, 3);

            builder.Entity<Book>()
            .Property(m => m.RetailPrice)
            .HasPrecision(10, 3);

           
            builder.Entity<Publisher>()
            .HasIndex(m => m.PhoneNumber);

            builder.Entity<Publisher>()
            .HasIndex(m => m.PublisherName);

            builder.Entity<Publisher>()
            .HasIndex(m => m.EmailAddress);


            builder.Entity<Category>()
            .HasIndex(nameof(Category.CategoryName));

            builder.Entity<OrderItem>()
            .HasIndex(nameof(OrderItem.Quantity));
        }

        public async Task<bool> SaveEntitiesAsync()
        {
            try
            {
                return await SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {

                    entry.State = EntityState.Detached;

                }
                throw;
            }

        }

        // public async Task StartAsync()
        // {
        //     await Database.BeginTransactionAsync();
        // }

        // public Task CommitAsync()
        // {
        //     Database.CommitTransaction();
        //     return Task.CompletedTask;
        // }

        // public Task RollbackAsync()
        // {
        //     Database.RollbackTransaction();
        //     return Task.CompletedTask;
        // }   
    }
}
