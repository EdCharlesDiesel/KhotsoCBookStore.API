using DDD.DomainLayer;
using StarPeaceAdminHubDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.Aggregates
{
    public interface IBookTitle : IEntity<int>
    {
        public string ISBN { get; set; } // nvarchar(50), not null

        public DateTime PublishedDate { get; set; } // smalldatetime, not null

        int TitleId { get; }

        void FullUpdate(IBookTitleFullEditDTO o);
    }
}
