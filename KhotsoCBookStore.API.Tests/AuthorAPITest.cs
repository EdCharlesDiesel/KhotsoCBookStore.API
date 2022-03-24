// using KhotsoCBookStore.API.Controllers;
// using KhotsoCBookStore.API.Entities;
// using KhotsoCBookStore.API.Services;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using System.Collections.Generic;
// using System.Linq;
// using Xunit;

// namespace KhotsoCBookStore.API.Tests
// {
//     public class AuthorAPITest
//     {
//         [Fact]
//         public void Test_GET_AllAuthors()
//         {
//             // Arrange
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo.Authors).Returns(Multiple());
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             var result = controller.Get();

//             // Assert
//             var model = Assert.IsAssignableFrom<IEnumerable<Author>>(result);
//             Assert.Equal(3, model.Count());
//         }
//         private static IEnumerable<Author> Multiple()
//         {
//             var r = new List<Author>();
//             r.Add(new Author()
//             {
//                 Id = 1,
//                 Name = "Test One",
//                 StartLocation = "SL1",
//                 EndLocation = "EL1"
//             });
//             r.Add(new Author()
//             {
//                 Id = 2,
//                 Name = "Test Two",
//                 StartLocation = "SL2",
//                 EndLocation = "EL2"
//             });
//             r.Add(new Author()
//             {
//                 Id = 3,
//                 Name = "Test Three",
//                 StartLocation = "SL3",
//                 EndLocation = "EL3"
//             });
//             return r;
//         }

//         [Fact]
//         public void Test_GET_AAuthors_BadRequest()
//         {
//             // Arrange
//             int id = 0;
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo[It.IsAny<int>()]).Returns<int>((a) => Single(a));
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             var result = controller.Get(id);

//             // Assert
//             var actionResult = Assert.IsType<ActionResult<Author>>(result);
//             Assert.IsType<BadRequestObjectResult>(actionResult.Result);
//         }

//         private static Author Single(int id)
//         {
//             IEnumerable<Author> reservations = Multiple();
//             return reservations.Where(a => a.Id == id).FirstOrDefault();
//         }

//         [Fact]
//         public void Test_GET_AAuthors_Ok()
//         {
//             // Arrange
//             int id = 1;
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo[It.IsAny<int>()]).Returns<int>((id) => Single(id));
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             var result = controller.Get(id);

//             // Assert
//             var actionResult = Assert.IsType<ActionResult<Author>>(result);
//             var actionValue = Assert.IsType<OkObjectResult>(actionResult.Result);
//             Assert.Equal(id, ((Author)actionValue.Value).Id);
//         }

//         [Fact]
//         public void Test_GET_AAuthors_NotFound()
//         {
//             // Arrange
//             int id = 4;
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo[It.IsAny<int>()]).Returns<int>((id) => Single(id));
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             var result = controller.Get(id);

//             // Assert
//             var actionResult = Assert.IsType<ActionResult<Author>>(result);
//             Assert.IsType<NotFoundResult>(actionResult.Result);
//         }

//         [Fact]
//         public void Test_POST_AddAuthor()
//         {
//             // Arrange
//             Author r = new Author()
//             {
//                 Id = 4,
//                 Name = "Test Four",
//                 StartLocation = "SL4",
//                 EndLocation = "EL4"
//             };
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo.AddAuthor(It.IsAny<Author>())).Returns(r);
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             var result = controller.Post(r);

//             // Assert
//             var reservation = Assert.IsType<Author>(result);
//             Assert.Equal(4, reservation.Id);
//             Assert.Equal("Test Four", reservation.Name);
//             Assert.Equal("SL4", reservation.StartLocation);
//             Assert.Equal("EL4", reservation.EndLocation);
//         }

//         [Fact]
//         public void Test_PUT_UpdateAuthor()
//         {
//             // Arrange
//             Author r = new Author()
//             {
//                 Id = 3,
//                 Name = "new name",
//                 StartLocation = "new start location",
//                 EndLocation = "new end location"
//             };
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo.UpdateAuthor(It.IsAny<Author>())).Returns(r);
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             var result = controller.Put(r);

//             // Assert
//             var reservation = Assert.IsType<Author>(result);
//             Assert.Equal(3, reservation.Id);
//             Assert.Equal("new name", reservation.Name);
//             Assert.Equal("new start location", reservation.StartLocation);
//             Assert.Equal("new end location", reservation.EndLocation);
//         }

//         [Fact]
//         public void Test_DELETE_Author()
//         {
//             // Arrange
//             var mockRepo = new Mock<IAuthorService>();
//             mockRepo.Setup(repo => repo.DeleteAuthor(It.IsAny<int>())).Verifiable();
//             var controller = new AuthorController(mockRepo.Object);

//             // Act
//             controller.Delete(3);

//             // Assert
//             mockRepo.Verify();
//         }
//     }
// }
