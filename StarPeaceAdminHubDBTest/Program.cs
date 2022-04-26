// using System;

// namespace StarPeaceAdminHubDBTest
// {
//     public static class Program
//     {
//         public static void Main()
//         {
//             Console.WriteLine("program start: populate database, press a key to continue");
//             Console.ReadKey();
//             // First, we must create an instance of our DbContext subclass
//             // with an appropriate connection string. We can use the same
//             // LibraryDesignTimeDbContextFactory class that's used by the design tools
//             // to get it:
//             // var context = new LibraryDesignTimeDbContextFactory()
//             //     .CreateDbContext();
            
//             #region Create Publisher
//             // var firstPublisher = new Publisher
//             // {
//             //     PublisherName = "Packt",
//             //     EmailAddress ="Packt@customerpackt.com",
//             //     PhoneNumber = 120225522,
//             // };
//             // context.Publishers.Add(firstPublisher);
//             // context.SaveChanges();
//             // Console.WriteLine(
//             //     "DB populated: first publisher id is " +
//             //     firstPublisher.PublisherId);
//             // Console.ReadKey();
//             // #endregion

//             // #region Create Book
//             // var firstBook = new Book
//             // {
//             //     ISBN = "00XX777",
//             //     Title = "Software Architecture with C# 9 and .NET 5",
//             //     CoverFileName = "Default Cover",
//             //     Description = "Architecting software solutions using microservices /,DevOps, and design patterns for Azure",
//             //     RetailPrice = 1250.00M,
//             //     Cost = 750.00M,
//             //     PublisheredDate = new DateTime(2016, 05, 05),
//             //     PublisherId =  firstPublisher.PublisherId,
//             //     Categories = new List<Category>()
//             //                         {
//             //                             new Category
//             //                             {
//             //                                 CategoryName = "Programming"
//             //                             },
//             //                             new Category
//             //                             {
//             //                                 CategoryName = "C#"
//             //                             }
//             //                         }
//             // };
//             // context.Books.Add(firstBook);
//             // context.SaveChanges();
//             // Console.WriteLine(
//             //     "DB populated: first book id is " +
//             //     firstBook.BookId);
//             // Console.ReadKey();
//             // #endregion

            
//             // #region Create Customer
//             // var firstCustomer = new Customer
//             // {
//             //     FirstName = "Charles",
//             //     LastName ="Mokhethi",
//             //     DateOfBirth = new DateTime(1988,08,05),
//             //     EmailAddress= "Mokhetkc@hotmail.com",
//             //     Address ="25482B Zone 8",
//             //     City = "Meadowlands",
//             //     Postal = 1852,
//             //     Province = "Gauteng",
//             //     Username ="EdCharles",
//             //     Orders = new List<Order>(),
//             //     ProductSubscriptions= new List<ProductSubscription>(),
//             //     WishLists =new List<WishList>()
//             // };
//             // context.Customers.Add(firstCustomer);
//             // context.SaveChanges();
//             // Console.WriteLine("DB populated: first customer id is " +
//             //     firstCustomer.CustomerId);
//             // Console.ReadKey();
//             // #endregion
            
//             // #region Create Order
//             // var firstOrder = new Order
//             // {
//             //     OrderDate = new DateTime(2022,05,05),
//             //     ShipDate = new DateTime(2022,05,06),
//             //     CartTotal = 33.22M,
//             //     ShipAddress = firstCustomer.Address,
//             //     OrderItems = new List<OrderItem>()
//             //     {
//             //         new OrderItem
//             //         {
//             //             BookId = firstBook.BookId,
//             //             Quantity =1 
//             //         },
//             //         new OrderItem
//             //         {
//             //             BookId = firstBook.BookId,
//             //             Quantity =2  
//             //         },
//             //         new OrderItem
//             //         {
//             //             BookId = firstBook.BookId,
//             //             Quantity =1 
//             //         }                      
//             //     }
//             // };

//             // context.Orders.Add(firstOrder);
//             // context.SaveChanges();
//             // Console.WriteLine(
//             //     "DB populated: first order id is " +
//             //     firstOrder.OrderId);
//             // Console.ReadKey();
//             #endregion


//             #region Factory Sample
//             ProcessCharging(PaymentServiceFactory.ServicesAvailable.Botswana,
//             "gabriel@sample.com", 178.90f, EnumChargingOptions.CreditCard);
//             ProcessCharging(PaymentServiceFactory.ServicesAvailable.Lesotho,
//             "francesco@sample.com", 188.70f, EnumChargingOptions.
//             DebitCard);
//             Console.ReadKey();

            

//             #region Update
//             // If entities included with the Include method themselves contain a nested collection
//             // we would like to include, we can use ThenInclude as shown here:
//             // var toModify = context.Books
//             //     .Where(m => m.Title == "Florence")
//             //     .Include(m => m.Categories)
//             //     .FirstOrDefault();

//             // toModify.Description = 
//             //                 "Florence is a famous historical Italian town";
//             // foreach (var package in toModify.Categories)
//             //                 package.Price = package.Price * 1.1m;
//             // // all the changes that are performed ona DbCo ntext instance to the database
//             // context.SaveChanges();

//             // var verifyChanges= context.Books
//             //         .Where(m => m.Title == "Florence")
//             //         .FirstOrDefault();

//             // Console.WriteLine(
//             //     "New Florence description: " +
//             //     verifyChanges.Description);
//             // Console.ReadKey();

//             #endregion

//             #region Create with Dto
//             // var period = new DateTime(2019, 8, 10);
//             // var list = context.Categories
//             //     .Where(m => period >= m.StartValidityDate
//             //     && period <= m.EndValidityDate)
//             //     .Select(m => new BooksListDTO
//             //     {
//             //         StartValidityDate=m.StartValidityDate,
//             //         EndValidityDate=m.EndValidityDate,
//             //         Name=m.Name,
//             //         DurationInDays=m.DurationInDays,
//             //         Id=m.CategoryId,
//             //         Price=m.Price,
//             //         DestinationName =m.Name,
//             //         DestinationId = m.BookId
//             //     })

//             //     // This is where ef executes the query
//             //     .ToList();
//             // foreach (var result in list)
//             //     Console.WriteLine(result.ToString());
//             // Console.ReadKey();
//             #endregion
//         }

//         private static void ProcessCharging(PaymentServiceFactory.ServicesAvailable serviceToCharge,
//         string emailToCharge, float moneyToCharge,
//         EnumChargingOptions optionToCharge)
//         {
//             PaymentServiceFactory factory = new PaymentServiceFactory();
//             var service = factory.Create(serviceToCharge);
//             service.EmailToCharge = emailToCharge;
//             service.MoneyToCharge = moneyToCharge;
//             service.OptionToCharge = optionToCharge;
//             service.ProcessCharging();
//         }
//         #endregion        
//     }
// }