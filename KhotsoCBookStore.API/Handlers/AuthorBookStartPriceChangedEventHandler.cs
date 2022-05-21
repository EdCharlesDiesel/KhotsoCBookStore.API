// using DDD.ApplicationLayer;
// using AuthorsManagementDomain.Aggregates;
// using AuthorsManagementDomain.Events;
// using AuthorsManagementDomain.IRepositories;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace AuthorsManagement.Handlers
// {
//     public class AuthorPriceChangedEventHandler :
//         IEventHandler<AuthorPriceChangedEvent>
//     {
//         private readonly IAuthorEventRepository repo;
//         public AuthorPriceChangedEventHandler(IAuthorEventRepository repo)
//         {
//             this.repo = repo;
//         }
//         public Task HandleAsync(AuthorBookStartPriceChangedEventHandler ev)
//         {
//             repo.New(AuthorEventType.CostChanged, ev.AuthorId, ev.OldVersion, ev.NewVersion, ev.NewPrice);
//             return Task.CompletedTask;
//         }
//     }
// }
