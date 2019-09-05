using BlueBook.Data.Interfaces;
using BlueBook.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueBook.Data.Repository
{

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlueBookDBContext context) : base(context) { }

        public override void Delete(Category entity)
        {
            // https://github.com/aspnet/EntityFrameworkCore/issues/3924
            // EF Core 2 doesnt support Cascade on delete for in Memory Database

            var booksToRemove = _context.Books.Where(b => b.Category == entity);

            base.Delete(entity);

            _context.Books.RemoveRange(booksToRemove);

            Save();
        }

    }
}

 
