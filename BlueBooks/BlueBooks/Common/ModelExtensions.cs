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
        public static Book toEntity(this BookRequestModel bookRequest)
        {
            return new Book()
            {
                CategoryId = bookRequest.categoryId,
                Title = bookRequest.title,
                AuthorId = bookRequest.authorID,
                BookId = bookRequest.bookId
            };
        }
        public static Category toEntity(this CategoryCreateModel categoryCreate)
        {
            return new Category()
            {
                Categoryname = categoryCreate.categoryName,
                Id = categoryCreate.categoryID.Value
            };
        }


    }
}
