using BookstoreApplication.Data;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublishersRepository publishersRepository;

        public PublishersController(BookstoreContext context)
        {
            publishersRepository = new PublishersRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Publisher>>> GetAll()
        {
            return Ok(await publishersRepository.GetAllAsync());
        }

        // GET api/publishers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> GetOne(int id)
        {
            Publisher? publisher = await publishersRepository.GetByIdAsync(id);
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
            Publisher createdPublisher = await publishersRepository.AddAsync(publisher);
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
            Publisher? updatedPublisher = await publishersRepository.UpdateAsync(publisher);
            if (updatedPublisher == null) {
                return NotFound();
            }
            return Ok(publisher);
        }

        // DELETE api/publishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Publisher publisher = await publishersRepository.GetByIdAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            await publishersRepository.DeleteAsync(publisher.Id);
            return NoContent();
        }
    }
}
