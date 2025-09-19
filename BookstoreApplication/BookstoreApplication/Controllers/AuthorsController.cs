using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsRepository authorsRepository;

        public AuthorsController(BookstoreContext context)
        {
            authorsRepository = new AuthorsRepository(context);
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            return Ok(await authorsRepository.GetAllAsync());
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetOne(int id)
        {
            Author author = await authorsRepository.GetByIdAsync(id);
            if (author == null) {
                return NotFound();
            }
            return Ok(author);
        }

        // POST api/authors
        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author author)
        {
            Author createdAuthor = await authorsRepository.AddAsync(author);
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

              Author? updatedAuthor = await authorsRepository.UpdateAsync(author);
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
            Author author = await authorsRepository.GetByIdAsync(id);
            if (author == null) {
                return NotFound();
            }

            await authorsRepository.DeleteAsync(author.Id);
            return NoContent();

        }
    }
}
