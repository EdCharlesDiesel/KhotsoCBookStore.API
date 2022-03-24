using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class CategoryForUpdateDto
    { 
        [Required(ErrorMessage ="Please provide the category name")]        
        public string CategoryName { get; set; }
        
        public Guid BookId { get; set; }         
    }
}