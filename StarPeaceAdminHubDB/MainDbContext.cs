using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;
using System.Threading.Tasks;


namespace StarPeaceAdminHubDB
{
    public class MainDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>, IUnitOfWork
    {
        public DbSet<Book> Books { get; set; }
        public  DbSet<Publisher> Publishers { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<BookSeriesExtras> BookSeriesExtras { get; set; }
        // public  DbSet<Author> Authors { get; set; }
        // public  DbSet<Customer> Customers { get; set; }
        // public  DbSet<Employee> Employees { get; set; }
        // public  DbSet<ProductSubscription> ProductSubscriptions { get; set; }
        // public  DbSet<ProductSubscriptionItem> ProductSubscriptionItems { get; set; }
        // public  DbSet<Cart> Carts { get; set; }
        // public  DbSet<CartItem> CartItems { get; set; }
        
        // public  DbSet<OrderItem> OrderItems { get; set; }
        // public  DbSet<Order> Orders { get; set; }
        // public  DbSet<UserMaster> UserMasters { get; set; }
        // public  DbSet<WishList> WishLists { get; set; }
        // public  DbSet<WishListItem> WishListItems { get; set; }

        // public DbSet<Destination> Destinations { get; set; }
        // public DbSet<BookEvent> BookEvents { get; set; }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasMany(m => m.Categories)
                .HasMany(m=>m.Publishers)
                .WithOne(m => m.Book)
                .HasForeignKey(m => m.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<Category>()
            //    .HasOne(m => m.MyBook)
            //    .WithMany(m => m.Categories)
            //    .HasForeignKey(m => m.BookId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<Book>()
            //     .HasIndex(m => m.Country);

            //  builder.Entity<Book>()
            //     .HasIndex(m => m);



            // builder.Entity<Book>()
            //     .HasIndex(m => m.Title);

            // builder.Entity<Category>()
            //     .HasIndex(m => m.Name);

            // builder.Entity<Category>()
            //     .HasIndex(nameof(Category.StartValidityDate), 
            //     nameof(Category.EndValidityDate));

            
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

        public async Task StartAsync()
        {
            await Database.BeginTransactionAsync();
        }

        public Task CommitAsync()
        {
            Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public Task RollbackAsync()
        {
            Database.RollbackTransaction();
            return Task.CompletedTask;
        }
    }
}
