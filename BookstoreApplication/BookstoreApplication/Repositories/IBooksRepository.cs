using BookstoreApplication.Models;

namespace BookstoreApplication.Repositories
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetAllWithIncludesAsync();
        Task<Book> GetByIdWithIncludesAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book?> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}
