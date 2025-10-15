using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService) {
            _authorsService = authorsService;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            return Ok(await _authorsService.GetAllAsync());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetOne(int id)
        {
            Author author = await _authorsService.GetByIdAsync(id);
            if (author == null) {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author author)
        {
            Author createdAuthor = await _authorsService.AddAsync(author);
            return Created(string.Empty, createdAuthor);

        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Author>> Put(int id, Author author)
        {
              if(id != author.Id)
              {
                    return BadRequest();
              }

              Author? updatedAuthor = await _authorsService.UpdateAsync(author);
            if (updatedAuthor == null)
            {
                return NotFound();
            }
              return Ok(updatedAuthor);
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Author author = await _authorsService.GetByIdAsync(id);
            if (author == null) {
                return NotFound();
            }

            await _authorsService.DeleteAsync(author.Id);
            return NoContent();

        }
    }
}
