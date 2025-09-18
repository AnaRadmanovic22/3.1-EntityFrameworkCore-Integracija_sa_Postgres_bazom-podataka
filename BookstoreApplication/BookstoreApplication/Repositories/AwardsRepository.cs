using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AwardsRepository
    {
        private readonly BookstoreContext _context;

        public AwardsRepository(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<List<Award>> GetAllAsync()
        {
            return await _context.Awards.ToListAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _context.Awards.FindAsync(id);
        }

        public async Task<Award> AddAsync(Award award)
        {
            _context.Awards.Add(award);
            await _context.SaveChangesAsync();
            return award;
        }

        public async Task<Award?> UpdateAsync(Award award)
        {
            if (!_context.Awards.Any(a => a.Id == award.Id))
            {
                return null;
            }

            _context.Awards.Update(award);
            await _context.SaveChangesAsync();
            return award;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Award? award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return false;
            }

            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
