using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlueBook.Data.Interfaces;
using BlueBook.Data.Model;
using BlueBooks.Common;
using BlueBooks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _autorRepository;

        public BookController(IBookRepository bookRepository, 
            IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _autorRepository = authorRepository;
        }

        [Route("create")]
        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] BookRequestModel bookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
               // bookRequest.Authors = _bookRepository.GetAll();
                
            }

            if (_bookRepository.GetAll().Where(x => x.Title == bookRequest.title 
                && x.AuthorId == bookRequest.authorID).Any())
            {
                return Content("The Book Title is in Database Already!");
            }
            else {
                _bookRepository.Create(bookRequest.toEntity());
                return Ok(bookRequest);
            }

        }

        [Route("Book")]
        [Authorize]
        public IActionResult Delete(int id, int? authorId)
        {
            var book = _bookRepository.GetById(id);

            _bookRepository.Delete(book);

            return Ok(book);
        }

        [Route("update")]
        [Authorize]
        public IActionResult Update(BookRequestModel bookRequest)
        {
          
            Book book = _bookRepository.FindWithAuthor(a => a.BookId == bookRequest.bookId).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            book.Title = bookRequest.title;
            book.AuthorId = bookRequest.authorID;
            book.CategoryId = bookRequest.categoryId;
            _bookRepository.Update(book);

            return Ok();


            
        }

        [Route("GetBooks")]
        [Authorize]
        public IActionResult GetBooks(int? bookId)
        {
            var books = new List<Book>();
            if (bookId == null)
            {
                books = _bookRepository.GetAllBooks().ToList();
            }
            else
            {
                books = _bookRepository.GetAllBooks().Where(x => x.BookId == bookId).ToList();
            }
            if (books.Count > 0)
                return Ok(books.Select(x => x.toModel()));
            return NotFound();
        }



    }
}