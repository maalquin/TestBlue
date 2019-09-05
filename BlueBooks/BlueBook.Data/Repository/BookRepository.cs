using BlueBook.Data.Interfaces;
using BlueBook.Data.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlueBook.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BlueBookDBContext context) : base(context) { }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books.Include(a => a.Author);
        }
    }
}
