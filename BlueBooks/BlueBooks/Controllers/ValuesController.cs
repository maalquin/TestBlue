

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BlueBook.Data.Interfaces;
using BlueBook.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlueBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public ValuesController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
          
            var author = _authorRepository.GetAllWithBooks();
            return Ok(author);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
