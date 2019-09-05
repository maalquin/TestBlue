using BlueBook.Data.Interfaces;
using BlueBook.Data.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace BlueBook.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BlueBookDBContext context) : base(context) {}

        public IEnumerable<Author> GetAllWithBooks()
        {
            return _context.Authors.Include(a => a.Books);
        }

        public Author GetWithBooks(int id)
        {
            return _context.Authors.Where(a => a.AuthorId == id).Include(a => a.Books).FirstOrDefault();
        }

        public override void Delete(Author entity)
        {
            // https://github.com/aspnet/EntityFrameworkCore/issues/3924
            // EF Core 2 doesnt support Cascade on delete for in Memory Database

            var booksToRemove = _context.Books.Where(b => b.Author == entity);

            base.Delete(entity);

            _context.Books.RemoveRange(booksToRemove);

            Save();
        }
    }
}
