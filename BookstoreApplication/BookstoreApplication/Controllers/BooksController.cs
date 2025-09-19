using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksRepository booksRepository;

        public BooksController(BookstoreContext context)
        {
            booksRepository = new BooksRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            return Ok(await booksRepository.GetAllWithIncludesAsync());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetOne(int id)
        {
            Book? book = await booksRepository.GetByIdWithIncludesAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            Book createdBook = await booksRepository.AddAsync(book);
            return Created(string.Empty, createdBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            Book? updatedBook = await booksRepository.UpdateAsync(book);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return Ok(updatedBook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await booksRepository.GetByIdWithIncludesAsync(id);
            if (book == null) { 
                return NotFound();
            }
            await booksRepository.DeleteAsync(book.Id);
            return NoContent();
        }
    }
}
