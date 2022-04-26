using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarPeaceAdminHub.Models.Categorys
{
    public class CategoryFullEditViewModel: ICategoryFullEditDTO
    {
        public CategoryFullEditViewModel() { }
        public CategoryFullEditViewModel(ICategory o)
        {
            Id = o.Id;
            BookId = o.BookId;
            CategoryName = o.CategoryName;           
            
        }
        public int Id { get; set; }
        
        [StringLength(128, MinimumLength = 5), Required]
        [Display(Name = "CategoryName")]        
        public string CategoryName { get; set; }
        
        [Display(Name = "Book")]
        public int BookId { get; set; }
    }
}
