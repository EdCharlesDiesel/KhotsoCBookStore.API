﻿using DDD.DomainLayer;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarPeaceAdminHubDB.Models;

namespace StarPeaceAdminHubDB.Repositories
{
    public class BookEventRepository : IBookEventRepository
    {
        private MainDbContext context;
        public BookEventRepository(MainDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<IBookEvent>> GetFirstN(int n)
        {
            return await context.BookEvents
                .OrderBy(m => m.Id)
                .Take(n)
                .ToListAsync();
        }

        public IBookEvent New(BookEventType type, int id, long oldVersion, long? newVersion=null, string title=null)
        {
            var model = new BookEvent
            {
                Type = type,
                BookId = id,
                OldVersion = oldVersion,
                NewVersion = newVersion,
                Title = title
            };
            context.BookEvents.Add(model);
            return model;
        }
    }
}