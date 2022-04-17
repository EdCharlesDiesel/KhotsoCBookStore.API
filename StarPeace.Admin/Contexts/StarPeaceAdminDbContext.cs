using System;
using System.Collections.Generic;
using StarPeace.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using StarPeace.Admin.Services;


namespace StarPeace.Admin.Contexts
{
    public partial class StarPeaceAdminDbContext : DbContext
    {

        public StarPeaceAdminDbContext(DbContextOptions<StarPeaceAdminDbContext> options)
            : base(options)
        {
        }

        //public DbSet<WebsiteMetadata> WebsiteMetadata { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookSeriesBook> BookSeriesBooks { get; set; }
         public DbSet<Customer> Customers { get; set; }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
