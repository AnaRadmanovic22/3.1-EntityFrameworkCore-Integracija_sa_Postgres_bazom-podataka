using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublishersService _publishersService;

        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> GetAll()
        {
            return Ok(await _publishersService.GetAllAsync());
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetOne(int id)
        {
            Publisher? publisher = await _publishersService.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        // POST api/publishers
        [HttpPost]
        public async Task<ActionResult<Publisher>> Post(Publisher publisher)
        {
            Publisher createdPublisher = await _publishersService.AddAsync(publisher);
            return Created(string.Empty, createdPublisher);
        }

        // PUT api/publishers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Publisher>> Put(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }
            Publisher? updatedPublisher = await _publishersService.UpdateAsync(publisher);
            if (updatedPublisher == null) {
                return NotFound();
            }
            return Ok(publisher);
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Publisher publisher = await _publishersService.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            await _publishersService.DeleteAsync(publisher.Id);
            return NoContent();
        }
    }
}
