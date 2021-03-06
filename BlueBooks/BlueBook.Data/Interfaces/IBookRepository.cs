﻿using BlueBook.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBook.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);
       
    }
}
