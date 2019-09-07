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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("GetCategories")]
        [HttpGet]
        [Authorize]
        public IActionResult GetCategories(int? categoryID)
        {
            var categories = new List<Category>();
            if (categoryID == 0)
            {
                categories = _categoryRepository.GetAll().ToList();
            }
            else
            {
                categories = _categoryRepository.GetAll().Where(x => x.Id == categoryID).ToList();
            }
            if (categories.Count > 0)
                return Ok(categories.Select(x => x.toModel()));
            return NotFound();
        }


        [Route("createCategory")]
        [HttpPost]
        [Authorize]
        public IActionResult createCategory([FromBody] CategoryCreateModel categoryCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                // bookRequest.Authors = _bookRepository.GetAll();

            }

            if (_categoryRepository.GetAll().Where(x => x.Categoryname == categoryCreate.categoryName).Any())
            {
                return Content("The Book Title is in Database Already!");
            }
            else
            {
                _categoryRepository.Create(categoryCreate.toEntity());
                return Ok(categoryCreate);
            }

        }
    }
}