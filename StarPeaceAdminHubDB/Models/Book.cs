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
        // public Book(string title)
        // {
        //     Title = title;
        // }        

        public int Likes
        {
            get { return likes; }
            set { likes = value; }
        }        

        public int Dislikes
        {
            get { return dislikes; }
            set { dislikes = value; }
        }
        
        public int Love
        {
            get { return loves; }
            set { loves = value; }
        }
        
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        
    }
}
