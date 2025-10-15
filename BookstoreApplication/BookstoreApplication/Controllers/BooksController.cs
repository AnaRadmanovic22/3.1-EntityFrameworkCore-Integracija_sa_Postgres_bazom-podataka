using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            return Ok(await _booksService.GetAllWithIncludesAsync());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetOne(int id)
        {
            Book? book = await _booksService.GetByIdWithIncludesAsync(id);
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
            Book createdBook = await _booksService.AddAsync(book);
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

            Book? updatedBook = await _booksService.UpdateAsync(book);
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
            Book book = await _booksService.GetByIdWithIncludesAsync(id);
            if (book == null) { 
                return NotFound();
            }
            await _booksService.DeleteAsync(book.Id);
            return NoContent();
        }
    }
}
