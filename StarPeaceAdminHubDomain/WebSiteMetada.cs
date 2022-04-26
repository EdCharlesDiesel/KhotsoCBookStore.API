using System;

namespace StarPeaceAdminHubDomain
{

    public sealed class WebSiteMetada
    {

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(40)]
        public string DefaultTheme { get; set; }
        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }
        [Required]
        public bool LogErrors { get; set; }


        private static WebsiteMetadata instance;

        private WebsiteMetadata()
        {

        }

        public static WebsiteMetadata GetInstance()
        {
            if(instance == null)
            {
                // using (AppDbContext db = new AppDbContext())
                // {
                //     if(db.Metadata.Count()==0)
                //     {
                //         db.Metadata.Add(new WebsiteMetadata() { Title = "My Application", AdminEmail = "admin@localhost", DefaultTheme = "Summer", LogErrors = true });
                //         db.SaveChanges();
                //     }
                //     instance = db.Metadata.SingleOrDefault();
                // }
                throw new NotImplementedException();
            }
            return instance;
        }
        #region This is the Singleton definition
        private static WebSiteMetada _instance;

        public static WebSiteMetada Current => _instance ??= new WebSiteMetada();       
        

        public string Message { get; set; }

        public void Print()
        {
            Console.WriteLine(Message);
            Console.WriteLine("This is working");
        }
        #endregion
    }
}
