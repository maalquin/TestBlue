using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBook.Data.Interfaces;
using BlueBook.Data.Model;
using BlueBooks.Common;
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
            if (categories == null)
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
    }
}