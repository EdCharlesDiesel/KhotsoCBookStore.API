// using System;
// using Xunit;
// using KhotsoCBookStore.API.Dtos;

// namespace KhotsoCBookStore.API.Tests.Dtos
// {
//     public class UpdateDtoTests : IDisposable
//     {
//         UpdateDto updateDto;
//         public UpdateDtoTests()
//         {
//             updateDto = new UpdateDto
//             {
//                 Password = "admin",
//                 Username = "admin",
//                 FirstName = "Khotso",
//                 LastName = "Mokhethi"
//             };
//         }

//         public void Dispose()
//         {
//            updateDto  = null;
//         }

//         [Fact]
//         public void CanChangeUsername()
//         {
//             //Arrange
//             //Act
//             updateDto.Username = "Admin";

//             //Assert
//             Assert.Equal("Admin", updateDto.Username);
//         }

//         [Fact]
//         public void CanChangePassword()
//         {
//             //Arrange
//             //Act
//             updateDto.Password = "Admin";

//             //Assert
//             Assert.Equal("Admin", updateDto.Password);
//         }

//         [Fact]
//         public void CanChangeFirstname()
//         {
//             //Arrange
//             //Act
//             updateDto.FirstName = "khotso";

//             //Assert
//             Assert.Equal("khotso", updateDto.FirstName);
//         }

//         [Fact]
//         public void CanChangeLastname()
//         {
//             //Arrange
//             //Act
//             updateDto.LastName = "Legwale";

//             //Assert
//             Assert.Equal("Legwale", updateDto.LastName);
//         }    
//     }
// }
    