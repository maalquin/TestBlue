using BlueBook.Data.Model;
using BlueBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBooks.Common
{
    public static class ModelExtensions
    {
        public static BookResponseModel toModel(this Book book)
        {
            return new BookResponseModel
            {
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                BookId = book.BookId,
                Title = book.Title,
                author = book.Author.toModel(),
                category = book.Category.toModel()
                
            };
        }

        public static AuthorResponseModel toModel(this Author author)
        {
            return new AuthorResponseModel
            {
                AuthorID = author.AuthorId,
                AuthorName = author.Name
            };
        }

        public static CategoryResponseModel toModel(this Category category)
        { 
            return new CategoryResponseModel
            { 
                CategoryId = category.Id,
                CategoryName = category.Categoryname
            };
        }


    }
}
