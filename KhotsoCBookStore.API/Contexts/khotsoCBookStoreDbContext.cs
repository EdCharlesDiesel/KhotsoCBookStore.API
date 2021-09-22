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

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookSubscription>  BookSubscription { get; set; }

        public virtual DbSet<BookSubscriptionItems>  BookSubscriptionItems { get; set; }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<WishlistItems> WishlistItems { get; set; }
        

             protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoverFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.CartItemId)
                    .HasName("PK__CartItem__488B0B0AA0297D1C");

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A2B46B8DFC9");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__Customer__9DD74DBD81D9221B");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Customer__C3905BCF96C8F1E7");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CartTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<BookSubscription>(entity =>
            {
                entity.HasKey(e => e.BookSubscriptionId)
                    .HasName("PK__BookSubscriptionId");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserMasterID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    
                    .HasMaxLength(20)
                    .IsUnicode(false);           

                entity.Property(e => e.LastName)
                    
                    .HasMaxLength(20)
                    .IsUnicode(false);
                     entity.Property(e => e.EmailAddress);                 
                 

                entity.Property(e => e.PasswordHash);
                entity.Property(e => e.PasswordSalt);
                    

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.WishlistId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<WishlistItems>(entity =>
            {
                entity.HasKey(e => e.WishlistItemId)
                    .HasName("PK__WishlistItemId");

                entity.Property(e => e.WishlistId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

             modelBuilder.Entity<BookSubscriptionItems>(entity =>
            {
                entity.HasKey(e => e.BookSubscriptionItemId)
                    .HasName("PK__BookSubscriptionItemId");

                entity.Property(e => e.BookSubscriptionItemId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });
            

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

              modelBuilder.Entity<Book>().HasData(
                 new Book
                 {
                     BookId =1,
                     Name = "Deep Learning with JavaScript",
                     Text = "Deep learning has transformed the fields of computer vision, image processing, and natural language applications.",
                     Author ="Charles",
                     CoverFileName ="Default_image",
                     PurchasePrice = 300,
                     Category = "Development"
                 },
                   new Book
                 {
                     BookId =2,
                     Name = "Webdevelopment-101",
                     Text ="Learn how to make better decisions and write cleaner Ruby code. This book shows you how to avoid messy code that is hard to test and which cripples productivity.",
                     Author ="Kagiso",
                     CoverFileName ="Default_image",
                     PurchasePrice = 300,
                     Category = "Development"
                 }
                );

            //modelBuilder.Entity<UserMaster>().HasData(
            //     new UserMaster
            //     {
            //         UserTypeId = 1,
            //         FirstName = "Khotso",
            //         LastName = "Mokhethi",
            //         EmailAddress ="Mokhetkc@hotmail.com",                     
            //         Username = "Batman",
            //         Password = "IamBatman",
            //         UserId = 1
            //     }
            //    );

            modelBuilder.Entity<Categories>().HasData(
             new Categories
             {
                 CategoryId = 1,
                 CategoryName = "Web Development",
             },
             new Categories
             {
                 CategoryId = 2,
                 CategoryName = "Programming",
             },
             new Categories
             {
                 CategoryId = 3,
                 CategoryName = "Databases",
             },
             new Categories
             {
                 CategoryId = 4,
                 CategoryName = "Administration",
             });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
