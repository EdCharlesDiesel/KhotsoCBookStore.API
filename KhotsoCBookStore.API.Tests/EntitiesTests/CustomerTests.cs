// using System;
// using Xunit;
// using KhotsoCBookStore.API.Entities;

// namespace KhotsoCBookStore.API.Tests.Entities
// {
//     public class CustomerTests : IDisposable
//     {
//         Customer customer;
//         public CustomerTests() => customer = new Customer
//         {
//             CustomerId = new Guid("FEB6F8D2-A51A-4EC6-8812-71A2C1819601"),
//             FirstName = "Khotso",
//             LastName = "Mokhethi",
//             Username = "Mokhetkc",
//             EmailAddress = "Mokhetkc@hotmail.com",
//             Address = "Mandela Street Sandton Drive",
//             City = "Sandton",
//             Province = "Gauteng",
//             Postal = 2007,
//             CreatedBy = "system",
//             CreatedOn = DateTime.Now,
            
//         };

//         public void Dispose()
//         {
//            customer  = null;
//         }

//         // [Fact]
//         // public void CanChangeId()
//         // {
//         //     //Arrange
//         //     var expected = new Guid("D1D9BEA1-2E36-4D6A-9D85-0B97419609C9");
//         //     //Act
//         //     var customer = new Customer();

//         //     customer.CustomerId = expected;

//         //     Assert.Equal(expected, customer.CustomerId);
//         // }

//         // [Fact]
//         // public void CanChangeLastName()
//         // {
//         //     //Arrange
//         //     var customer = new Customer();
//         //     //Act
//         //     customer.LastName = "Data Structures And Algotithms";

//         //     //Assert
//         //     Assert.Equal("Data Structures And Algotithms", customer.LastName);
//         // }

//         // [Fact]
//         // public void CanChangeUsername()
//         // {
//         //     //Arrange
//         //     //Act
//         //     customer.Username = "User1";

//         //     //Assert
//         //     Assert.Equal("User1", customer.Username);
//         // }
//     }
// }
    