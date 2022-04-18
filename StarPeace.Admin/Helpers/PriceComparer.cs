using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Repositories;

namespace StarPeace.Admin.Helpers
{
    public class PriceComparer
    {
        public List<Book> Compare(string isbn)
        {
            ServiceAClient clientA = new ServiceAClient();
            Book bookA = clientA.SearchBook(isbn);

            ServiceBClient clientB = new ServiceBClient();
            Book bookB = clientB.SearchBook(isbn);

            List<Book> books = new List<Book>();
            books.Add(bookA);
            books.Add(bookB);

            books.Sort(delegate (Book b1, Book b2)
            {
                return b1.Price.CompareTo(b2.Price);
            });

            return books;
        }
    }
}
