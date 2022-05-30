// using System;
// using KhotsoCBookStore.API.Entities;
// using Xunit;

// namespace KhotsoCBookStore.API.Tests.EntitiesTests
// {
//     public class AuthorTests: IDisposable
//     {
//         Author author;
//         public AuthorTests()
//         {
//             author = new Author
//             {
//                 AuthorId = new Guid("F6F0FB84-3ABB-45AE-BFCD-C30014A40AF3"),
//                 FirstName = "Micheal",
//                 LastName = "Bay",
//                 UpdatedBy ="Test",
//                 UpdatedOn =DateTime.Now
//             };
//         }

//         public void Dispose()
//         {
//            author  = null;
//         }

//         [Fact]
//         public void CanChangeId()
//         {
//             //Arrange
//             var expected = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");
//             //Act
//             author.AuthorId = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");

//             //Assert
//             Assert.Equal(expected, author.AuthorId);
//         }

//         [Fact]
//         public void CanChangeFirstName()
//         {
//             //Arrange
//             //Act
//             author.FirstName = "Transformers Age of Darkness";

//             //Assert
//             Assert.Equal("Transformers Age of Darkness", author.FirstName);
//         }

//         [Fact]
//         public void CanChangeLastName()
//         {
//             //Arrange
//             //Act
//             author.LastName = "MKBay";

//             //Assert
//             Assert.Equal("MKBay", author.LastName);
//         }

        
//         [Fact]
//         public void CanChangeUpdatedBy()
//         {
//             //Arrange
//             //Act
//             author.UpdatedBy = "MKBay";

//             //Assert
//             Assert.Equal("MKBay", author.UpdatedBy);
//         }

        
//         [Fact]
//         public void CanChangeUpdatedOn()
//         {
//              //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             author.UpdatedOn =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, author.UpdatedOn);
//         }
//     }
// }
    