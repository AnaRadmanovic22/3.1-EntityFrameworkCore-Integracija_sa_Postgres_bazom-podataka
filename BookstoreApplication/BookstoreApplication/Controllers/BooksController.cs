using BookstoreApplication.DTOs;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Models;
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
        public async Task<ActionResult<List<BookDto>>> GetAll()
        {
            var books = await _booksService.GetAllWithIncludesAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDto>> GetOne(int id)
        {
            var book = await _booksService.GetByIdWithIncludesAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            var createdBook = await _booksService.AddAsync(book);
            return Created(string.Empty, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, Book book)
        {
            if (id != book.Id)
                throw new BadRequestException("Book ID mismatch."); 

            var updatedBook = await _booksService.UpdateAsync(book);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _booksService.DeleteAsync(id);
            return NoContent();
        }
    }
}