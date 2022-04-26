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
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CategoryEvent> CategoryEvents { get; set; }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Book>()
                .HasMany(m => m.Categorys)
                .WithOne(m => m.MyBook)
                .HasForeignKey(m => m.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Category>()
            //    .HasOne(m => m.MyBook)
            //    .WithMany(m => m.Categorys)
            //    .HasForeignKey(m => m.BookId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Book>()
                .HasIndex(m => m.Country);

            builder.Entity<Book>()
                .HasIndex(m => m.Name);

            builder.Entity<Category>()
                .HasIndex(m => m.Name);

            builder.Entity<Category>()
                .HasIndex(nameof(Category.StartValidityDate), nameof(Category.EndValidityDate));
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
