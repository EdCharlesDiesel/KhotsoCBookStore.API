using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPeace.Extensions.Service.Entities
{
    [Table("WebsiteMetadata")]
    public class WebsiteMetadata
    {
        private static WebsiteMetadata instance;
        private WebsiteMetadata()
        {
        }
        public static WebsiteMetadata GetInstance()
        {
            if (instance == null)
            {
                using (StarPeaceExtensionsDbContext db = new StarPeaceExtensionsDbContext())
                {
                    if (db.Metadata.Count() == 0)
                    {
                        db.Metadata.Add(new WebsiteMetadata()
                        {
                            Title = "KhotsoCBookStore",
                            AdminEmail = "admin@KhotsoCBookStore.co.za",
                            DefaultTheme = "Summer",
                            LogErrors = true
                        });
                        db.SaveChanges();
                    }
                    instance = db.Metadata.SingleOrDefault();
                }
            }
            return instance;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        
    }
}