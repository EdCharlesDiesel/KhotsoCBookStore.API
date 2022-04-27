using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;
using System.Threading.Tasks;

namespace StarPeaceAdminHubDB
{
    // This context defines the user's tables needed for the authentication. In our case, we
    // opted for the IdentityUser<T> standard and IdentityRole<S> for users and roles,
    // respectively, and used integers for both the T and S Entity keys. However, we may
    // also use classes that inherit from IdentityUser and IdentityRole and then add
    // further properties.

    // The preceding implementation just calls the SaveChangesAsync DbContext
    // context method, which saves all changes to the database, but then it intercepts all
    // concurrency exceptions and detaches all the entities involved in the concurrency
    // error from the context. This way, next time a command retries the whole failed
    // operation, their updated versions will be reloaded from the database.
    public class MainDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>, IUnitOfWork
    {
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CategoryEvent> CategoryEvents { get; set; }

        public DbSet<BookEvent> BookEvents { get; set; }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Book>()
                .HasMany(m => m.Categorys)
                .WithOne(m => m.Book)
                .HasForeignKey(m => m.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Category>()
            //    .HasOne(m => m.MyBook)
            //    .WithMany(m => m.Categorys)
            //    .HasForeignKey(m => m.BookId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Book>()
                .HasIndex(m => m.ISBN);

            builder.Entity<Book>()
                .HasIndex(m => m.Title);

            builder.Entity<Category>()
                .HasIndex(m => m.CategoryName);
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
