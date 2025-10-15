using BookstoreApplication.Models;

namespace BookstoreApplication.Repositories
{
    public interface IPublishersRepository
    {
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);
        Task<Publisher> AddAsync(Publisher publisher);
        Task<Publisher?> UpdateAsync(Publisher publisher);
        Task<bool> DeleteAsync(int id);
    }
}
