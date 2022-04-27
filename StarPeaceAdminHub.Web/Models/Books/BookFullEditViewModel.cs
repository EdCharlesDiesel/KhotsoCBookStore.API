// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.DTOs;
// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;

// namespace StarPeaceAdminHub.Models.Books
// {
//     // 2. One or more ViewModels containing changes to apply are hidden behind
//     // interfaces (IMyUpdate) defined in the domain layer.
//     public class BookFullEditViewModel: IBookFullEditDTO
//     {
//         public BookFullEditViewModel() { }
//         public BookFullEditViewModel(IBook o)
//         {
//             Id = o.Id;
//             Title = o.Title;           
            
//         }
//         public int Id { get; set; }
        
//         [StringLength(128, MinimumLength = 5), Required]
//         [Display(Name = "Title")]        
//         public string Title { get; set; }
        
//         [Display(Name = "Book")]
//         public int BookId { get; set; }


//         public string ISBN { get; set; }
        
//         public DateTime PublishingDate { get; set; }
        
//         public decimal Cost { get; set; }    

//         public decimal RetailPrice { get; set; }     
        
//         public string CoverFileName { get; set; }  
//     }
// }
