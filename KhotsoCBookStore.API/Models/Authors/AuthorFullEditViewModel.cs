// using System;
// using System.ComponentModel.DataAnnotations;
// using StarPeaceAdminHubDomain.Aggregates;
// using StarPeaceAdminHubDomain.DTOs;

// namespace KhotsoCBookStore.API.Models.Authors
// {
//     public class AuthorFullEditViewModel: IAuthorFullEditDTO
//     {
//         public AuthorFullEditViewModel() { }
//         public AuthorFullEditViewModel(IAuthor o)
//         {
//             Id = o.Id;
//             DestinationId = o.DestinationId;
//             Name = o.Name;
//             Description = o.Description;
//             Price = o.Price;
//             DurationInDays = o.DurationInDays;
//             StartValidityDate = o.StartValidityDate;
//             EndValidityDate = o.EndValidityDate;
//         }
//         public int Id { get; set; }
//         [StringLength(128, MinimumLength = 5), Required]
//         [Display(Name = "name")]
//         public string Name { get; set; }
//         [Display(Name = "Author infos")]
//         [StringLength(128, MinimumLength = 10), Required]
//         public string Description { get; set; }
//         [Display(Name = "price")]
//         [Range(0, 100000)]
//         public decimal Price { get; set; }
//         [Display(Name = "duration in days")]
//         [Range(1, 90)]
//         public int DurationInDays { get; set; }
//         [Display(Name = "available from"), Required]
//         public DateTime? StartValidityDate { get; set; }
//         [Display(Name = "available to"), Required]
//         public DateTime? EndValidityDate { get; set; }
//         [Display(Name = "destination")]
//         public int DestinationId { get; set; }
//     }
// }
