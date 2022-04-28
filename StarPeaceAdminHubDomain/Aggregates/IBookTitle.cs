using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBookTitle : IEntity<int>
    {
        public string ISBN { get; set; }

        public DateTime PublishedDate { get; set; }

        int TitleId { get; }

        void FullUpdate(IBookTitleFullEditDTO o);
    }
}
