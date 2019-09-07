using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [Route("create")]
        [HttpPost]
        [Authorize]
        public IActionResult Create(AuthorRequestModel authorRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            if (_authorRepository.GetAll().Where(x => x.Name == authorRequest.AuthorName).Any())
            {
                return Content("this author already exists on Database!");
            }
            else
            {
                var author = new Author()
                {
                    Name = authorRequest.AuthorName
                };

                _authorRepository.Create(author);
                return Ok(authorRequest);
            }


        }

        [Route("delete")]
        [Authorize]
        public IActionResult Delete(int id, int? bookId)
        {
            var author = _authorRepository.GetById(id);

            _authorRepository.Delete(author);

            return Ok(author);
        }

        [Route("update")]
        [Authorize]
        public IActionResult Update(AuthorRequestModel authorRequest)
        {

            Author author = _authorRepository.Find(a => a.AuthorId == authorRequest.AuthorID).FirstOrDefault();

            if (author == null)
            {
                return NotFound();
            }

            author.Name = authorRequest.AuthorName;
            _authorRepository.Update(author);

            return Ok(author);



        }

        [Route("GetAuthors")]
        [Authorize]
        public IActionResult GetAuthors(int? authorId)
        {
            var authors = new List<Author>();
            if (authorId == 0)
            {
                authors = _authorRepository.GetAll().ToList();
            }
            else
            {
                authors = _authorRepository.GetAll().Where(x => x.AuthorId == authorId).ToList();
            }
            if (authors.Count > 0)
                return Ok(authors.Select(x => x.toModel()));
            return NotFound();
        }


    }
}