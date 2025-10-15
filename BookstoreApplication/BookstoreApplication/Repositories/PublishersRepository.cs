using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly BookstoreContext _context;

        public PublishersRepository(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher?> UpdateAsync(Publisher publisher)
        {
            if (!_context.Publishers.Any(p => p.Id == publisher.Id))
            {
                return null;
            }

            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Publisher? publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return false;
            }

            _context.Publishers.Remove(publisher);

            List<Book> booksToRemove = await _context.Books
                .Where(b => b.PublisherId == id)
                .ToListAsync();
            _context.Books.RemoveRange(booksToRemove);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
