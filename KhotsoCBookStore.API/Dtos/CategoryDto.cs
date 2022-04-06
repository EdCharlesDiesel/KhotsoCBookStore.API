using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; } 
      
        public string CategoryName { get; set; }
        
        public Guid BookId { get; set; }       
        
    }
}