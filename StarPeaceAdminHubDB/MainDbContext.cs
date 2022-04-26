﻿using DDD.DomainLayer;
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
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<BookEvent> BookEvents { get; set; }
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Destination>()
                .HasMany(m => m.Books)
                .WithOne(m => m.MyDestination)
                .HasForeignKey(m => m.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Book>()
            //    .HasOne(m => m.MyDestination)
            //    .WithMany(m => m.Books)
            //    .HasForeignKey(m => m.DestinationId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Destination>()
                .HasIndex(m => m.Country);

            builder.Entity<Destination>()
                .HasIndex(m => m.Name);

            builder.Entity<Book>()
                .HasIndex(m => m.Name);

            builder.Entity<Book>()
                .HasIndex(nameof(Book.StartValidityDate), nameof(Book.EndValidityDate));

            
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
