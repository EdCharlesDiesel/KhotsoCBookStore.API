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
        public DbSet<Title> Titles { get; set; }
        public DbSet<BookTitle> BookTitles { get; set; }
        public DbSet<BookTitleEvent> BookTitleEvents { get; set; }
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


// protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);

//         //Seeding a  'Administrator' role to AspNetRoles table
//         modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });


//         //a hasher to hash the password before seeding the user to the db
//         var hasher = new PasswordHasher<IdentityUser>();


//         //Seeding the User to AspNetUsers table
//         modelBuilder.Entity<IdentityUser>().HasData(
//             new IdentityUser
//             {
//                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
//                 UserName = "myuser",
//                 NormalizedUserName = "MYUSER",
//                 PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
//             }
//         );


//         //Seeding the relation between our user and role to AspNetUserRoles table
//         modelBuilder.Entity<IdentityUserRole<string>>().HasData(
//             new IdentityUserRole<string>
//             {
//                 RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
//                 UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
//             }
//         );
        

//     }

// public void ConfigureServices(IServiceCollection services)  
//        {  
//            #region database configuration              
//            string connectionString = config.GetConnectionString("AppDb");  
  
//            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString));  
  
//            services.AddIdentity<User, IdentityRole>()  
//                .AddEntityFrameworkStores<AppDbContext>();  
//            #endregion                         
//        }


// public class AppDbContext : IdentityDbContext<User>  
//     {  
//         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  
//         {  
  
//         }  
  
//         protected override void OnModelCreating(ModelBuilder builder)  
//         {  
//             base.OnModelCreating(builder);  
//             this.SeedUsers(builder);  
//             this.SeedUserRoles(builder);  
//         }  
  
//         private void SeedUsers(ModelBuilder builder)  
//         {  
//             User user = new User()  
//             {  
//                 Id = "b74ddd14-6340-4840-95c2-db12554843e5",  
//                 UserName = "Admin",  
//                 Email = "admin@gmail.com",  
//                 LockoutEnabled = false,  
//                 PhoneNumber = "1234567890"  
//             };  
  
//             PasswordHasher<User> passwordHasher = new PasswordHasher<User>();  
//             passwordHasher.HashPassword(user, "Admin*123");  
  
//             builder.Entity<User>().HasData(user);  
//         }  
  
//         private void SeedRoles(ModelBuilder builder)  
//         {  
//             builder.Entity<IdentityRole>().HasData(  
//                 new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },  
//                 new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }  
//                 );  
//         }  
  
//         private void SeedUserRoles(ModelBuilder builder)  
//         {  
//             builder.Entity<IdentityUserRole<string>>().HasData(  
//                 new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }  
//                 );  
//         }  
//     }  