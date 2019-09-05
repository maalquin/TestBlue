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
                .Include(z => z.Category)
                .Where(predicate);
        }

      

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.Include(a => a.Author).Include(a => a.Category);
        }
    }
}
