// using System;
// using Xunit;
// using KhotsoCBookStore.API.Entities;

// namespace KhotsoCBookStore.API.Tests.Entities
// {
//     public class CategoryTests : IDisposable
//     {
//         Category categories;
//         public CategoryTests()
//         {
//             categories = new Category
//             {
//                 CategoryId = new Guid("D5066515-7104-4F85-894C-109BFB65QQQQ"),
//                 CategoryName ="Front-End Development",
//                 BookId = new Guid("D5066515-7104-4F85-AAAC-109BFB651444")
//             };
//         }

//         public void Dispose()
//         {
//            categories  = null;
//         }

//         [Fact]
//         public void CanChangeCategoryId()
//         {
//             //Arrange
//             var expected  = new Guid("D5066515-7104-4F85-894C-109BFB65XXXX");
//             //Act
//             categories.CategoryId = new Guid("D5066515-7104-4F85-894C-109BFB65XXXX");
            
//             //Assert
//             Assert.Equal(expected, categories.CategoryId);
//         }

//         [Fact]
//         public void CanChangeCategoryName()
//         {
//             //Arrange
//             //Act
//             categories.CategoryName="Back-End Development";

//             //Assert
//             Assert.Equal("Back-End Development", categories.CategoryName);
//         }

//         [Fact]
//         public void CanChangeBookId()
//         {
//             //Arrange
//             var expected  = new Guid("D5066515-7104-YYYY-894C-109BFB65XXXX");
//             //Act
//             categories.CategoryId = new Guid("D5066515-7104-YYYY-894C-109BFB65XXXX");
            
//             //Assert
//             Assert.Equal(expected, categories.CategoryId);
//         }
//     }
// }
    