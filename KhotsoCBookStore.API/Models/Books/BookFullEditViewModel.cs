// using System;
// using System.ComponentModel.DataAnnotations;
// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.DTOs;

// namespace KhotsoCBookStore.API.Models.Books
// {
//     public class BookFullEditViewModel: IBookFullEditDTO
//     {
//         public BookFullEditViewModel() { }
//         public BookFullEditViewModel(IBook o)
//         {
//             Id = o.Id;
//             FirstName = o.FirstName;
//             LastName = o.LastName;
//             BookStartPrice = o.BookStartPrice;
//             StartPublishingDate = o.StartPublishingDate;
//             EndPublishingDate = o.EndPublishingDate;
//         }
        
//         public int Id { get; set; }

//         [StringLength(150, MinimumLength = 5), Required]
//         [Display(Name = "First Name")]
//         public string FirstName { get; set; }

//         [StringLength(150, MinimumLength = 5), Required]
//         [Display(Name = "Last Name")]
//         public string LastName { get; set; }

//         [Display(Name = "Book Starting Price")]
//         [Range(0, 100000)]
//         public decimal BookStartPrice { get; set; }
        
//         public DateTime? StartPublishingDate { get; set; }

//         public DateTime? EndPublishingDate { get; set; }
        
//         [Display(Name = "Book")]
//         public int BookId { get; set; }
        
//     }
// }
