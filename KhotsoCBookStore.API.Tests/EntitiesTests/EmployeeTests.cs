// using System;
// using KhotsoCBookStore.API.Entities;
// using Xunit;

// namespace KhotsoCEmployeeStore.API.Tests.EntitiesTests
// {
//     public class EmployeeTests: IDisposable
//     {
//         Employee employee;
//         public EmployeeTests()
//         {
//             employee = new Employee
//             {
//                 EmployeeId = new Guid("F6F0FB84-3ABB-45AE-BFCD-C30014A40AF3"),
//                 FirstName = "Micheal",
//                 LastName = "Bay",
//                 UpdatedBy ="Test",
//                 UpdatedOn =DateTime.Now,
//                 DateOfEndEmployment = DateTime.Now,
//                 DateOfStartEmployment = DateTime.Now,
//                 EmployeeNumber = "EMP-007",
//                 DateOfBirth = DateTime.Now

//             };
//         }

//         public void Dispose()
//         {
//            employee  = null;
//         }

//         [Fact]
//         public void CanChangeEmployeeNumber()
//         {
//              //Arrange
//             var expected = "EMP-007";
//             //Act
//             employee.EmployeeNumber = "EMP-007";

//             //Assert
//             Assert.Equal(expected, employee.EmployeeNumber);
//         }

//         [Fact]
//         public void CanChangeDateOfBirth()
//         {
//              //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             employee.DateOfBirth =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, employee.DateOfBirth);
//         }

//         [Fact]
//         public void CanChangeDateOfStartEmployment()
//         {
//              //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             employee.DateOfStartEmployment =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, employee.DateOfStartEmployment);
//         }

//         [Fact]
//         public void CanChangeDateOfEndEmployment()
//         {
//              //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             employee.DateOfEndEmployment =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, employee.DateOfEndEmployment);
//         }

//         [Fact]
//         public void CanChangeId()
//         {
//             //Arrange
//             var expected = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");
//             //Act
//             employee.EmployeeId = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");

//             //Assert
//             Assert.Equal(expected, employee.EmployeeId);
//         }

//         [Fact]
//         public void CanChangeFirstName()
//         {
//             //Arrange
//             //Act
//             employee.FirstName = "Transformers Age of Darkness";

//             //Assert
//             Assert.Equal("Transformers Age of Darkness", employee.FirstName);
//         }

//         [Fact]
//         public void CanChangeLastName()
//         {
//             //Arrange
//             //Act
//             employee.LastName = "MKBay";

//             //Assert
//             Assert.Equal("MKBay", employee.LastName);
//         }

        
//         [Fact]
//         public void CanChangeUpdatedBy()
//         {
//             //Arrange
//             //Act
//             employee.UpdatedBy = "MKBay";

//             //Assert
//             Assert.Equal("MKBay", employee.UpdatedBy);
//         }

        
//         [Fact]
//         public void CanChangeUpdatedOn()
//         {
//              //Arrange
//             var expected = new DateTime(2021,05,05);
//             //Act
//             employee.UpdatedOn =new DateTime(2021,05,05);

//             //Assert
//             Assert.Equal(expected, employee.UpdatedOn);
//         }
//     }
// }
    