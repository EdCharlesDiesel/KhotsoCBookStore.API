using System;
using System.Collections.Generic;
using StarPeace.Admin.Entities;
using Microsoft.EntityFrameworkCore;
using StarPeace.Admin.Services;
using StarPeace.Admin.Helpers;


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
        public DbSet<Book> Books { get; set; }
        public DbSet<Activity> ActivityLog { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<CommandQueueItem> CommandQueue { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FileStoreEntry> FileStore { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OrderLog> OrderLog { get; set; }
        public DbSet<Question> Questions { get; set; }        
        public DbSet<StockTradingEntry> StockTradingLog { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
