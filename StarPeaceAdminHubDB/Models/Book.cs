using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    [Table("Books")]
    public class Book: AuditableEntity
    {
        private int likes;
        private int dislikes;
        private int loves;
        public Book(string title)
        {
            Title = title;
        }
        
        [Key]
        public Guid BookId { get; set; }

        [MaxLength(128), Required]
        public string Title { get; set; }
        
        [Required]        
        public string ISBN { get; set; }
        
        public string Description { get; set; }

        [Required]
        public DateTime PublisheredDate { get; set; }
        
        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public string CoverFileName { get; set; }

        public decimal Cost { get; set; }    

        public decimal RetailPrice { get; set; }        
        
        public ICollection<Category> Categories { get; set; }

        public void Like()
        {
            likes++;
            PresentStatus();
        }

        private void PresentStatus()
        {
            if (likes == 1)
                Console.WriteLine($"There is {likes} like to package {Name}");
            if (likes > 1)
                Console.WriteLine($"There are {likes} likes to package {Name}");
            if (dislikes == 1)
                Console.WriteLine($"There is {dislikes} dislike to package {Name}");
            if (dislikes > 1)
                Console.WriteLine($"There are {dislikes} dislikes to package {Name}");
            if (loves == 1)
                Console.WriteLine($"There is {loves} love to package {Name}");
            if (dislikes > 1)
                Console.WriteLine($"There are {loves} loves to package {Name}");
        }

        internal void UndoLike()
        {
            likes--;
            PresentStatus();
        }

        public void Dislike()
        {
            dislikes++;
            PresentStatus();
        }
        public void UndoDislike()
        {
            dislikes--;
            PresentStatus();
        }

        public void Love()
        {
            loves++;
            PresentStatus();
        }
        public void UndoLove()
        {
            loves--;
            PresentStatus();
        }
    }
}
