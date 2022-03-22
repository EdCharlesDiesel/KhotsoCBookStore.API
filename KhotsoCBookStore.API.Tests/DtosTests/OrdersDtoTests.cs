// using System;
// using Xunit;
// using KhotsoCBookStore.API.Dtos;
// using System.Collections.Generic;

// namespace KhotsoCBookStore.API.Tests.Dtos
// {
//     public class OrdersDtoTests : IDisposable
//     {
//         OrdersDto ordersDto;
//         public OrdersDtoTests()
//         {
//             ordersDto = new OrdersDto
//             {
//                 OrderId = "1",
//                 CartTotal = 1,
//                 OrderDetails = new List<CartItemDto>
//                                 {
//                                     new CartItemDto
//                                     {
//                                         Quantity = 1, 
//                                         Book = new API.Entities.Book()
//                                         {
//                                             BookId = Guid.NewGuid(),
//                                             Author = "Charles",
//                                             Category = "Databases",
//                                             Name ="SQL CookBook",
//                                             PurchasePrice=89.55M,
//                                             CoverFileName ="Dafault_Image.jpg",
//                                             Text = "Code recipes for SQL Developers"
//                                         }   
//                                     },

//                                     new CartItemDto
//                                     {
//                                         Quantity = 2, 
//                                         Book = new API.Entities.Book()
//                                         {
//                                             BookId = Guid.NewGuid(),
//                                             Author = "Charles",
//                                             Category = "Databases",
//                                             Name ="SQL CookBook V2",
//                                             PurchasePrice=89.55M,
//                                             CoverFileName ="Dafault_Image.jpg",
//                                             Text = "Code recipes for SQL Developers V2"
//                                         }   
//                                     },

//                                 },
//                 OrderDate = new DateTime(2021, 02, 04)
//             };
//         }

//         public void Dispose()
//         {
//             ordersDto = null;
//         }

//         [Fact]
//         public void CanOrderId()
//         {
//             //Arrange
//             //Act
//             ordersDto.OrderId = "2";

//             //Assert
//             Assert.Equal("2", ordersDto.OrderId);
//         }

//         [Fact]
//         public void CanChangeCartTotal()
//         {
//             //Arrange
//             //Act
//             ordersDto.CartTotal = 2;

//             //Assert
//             Assert.Equal(2, ordersDto.CartTotal);
//         }

//         [Fact]
//         public void CanChangeOrderDate()
//         {
//             //Arrange
//             //Act
//             ordersDto.OrderDate =new DateTime(2021,02,12);
//             var expected = new DateTime(2021,02,12);

//             //Assert
//             Assert.Equal(expected, ordersDto.OrderDate);
//         }
//     }
// }
