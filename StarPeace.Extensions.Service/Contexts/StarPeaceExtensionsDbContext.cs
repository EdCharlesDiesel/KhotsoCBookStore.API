using System;
using System.Collections.Generic;
using KhotsoCBookStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace StarPeace.Extensions.Service.Algorithms.Contexts
{
    public partial class StarPeaceExtensionsDbContext : DbContext
    {

        public StarPeaceExtensionsDbContext(DbContextOptions<StarPeaceExtensionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebsiteMetadata> WebsiteMetadata { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookSeriesBook> BookSeriesBooks { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
