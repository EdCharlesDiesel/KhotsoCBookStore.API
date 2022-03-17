// using System;
// using Xunit;
// using KhotsoCBookStore.API.Dtos;

// namespace KhotsoCBookStore.API.Tests.Dtos
// {
//     public class CartItemDtoTests : IDisposable
//     {
//         CartItemDto cartItemDto;
//         public CartItemDtoTests()
//         {
//             cartItemDto = new CartItemDto
//             {
//                 Book = new API.Entities.Book()
//                         {
//                             BookId = Guid.NewGuid(),
//                             Author = "Charles",
//                             Category = "Databases",
//                             Name ="SQL CookBook",
//                             PurchasePrice=89.55M,
//                             CoverFileName ="Dafault_Image.jpg",
//                             Text = "Code recipes for SQL Developers"
//                         },
//                 Quantity = 1
//             };
//         }

//         public void Dispose()
//         {
//            cartItemDto  = null;
//         }

//         [Fact]
//         public void CanChangeQuantity()
//         {
//             //Arrange
//             //Act
//             cartItemDto.Quantity = 2;

//             //Assert
//             Assert.Equal(2, cartItemDto.Quantity);
//         }

//        // [Fact]

//         public void CanChangeBook()
//         {
//             //Arrange
//             //Act
//             cartItemDto.Book = new API.Entities.Book()
//                                     {
//                                         BookId = Guid.NewGuid(),
//                                         Author = "Charles",
//                                         Category = "Databases",
//                                         Name ="SQL CookBook",
//                                         PurchasePrice=89.55M,
//                                         CoverFileName ="Dafault_Image.jpg",
//                                         Text = "Code recipes for SQL Developers"
//                                     };

//             var expected = new  API.Entities.Book()
//             {
//                 BookId = Guid.NewGuid(),
//                 Author = "Charles",
//                 Category = "Databases",
//                 Name ="SQL CookBook",
//                 PurchasePrice=89.55M,
//                 CoverFileName ="Dafault_Image.jpg",
//                 Text = "Code recipes for SQL Developers"
//             };

//             //Assert
//            // Assert.Equals(expected, cartItemDto.Book);
//         }
        
//     }    
// }
    