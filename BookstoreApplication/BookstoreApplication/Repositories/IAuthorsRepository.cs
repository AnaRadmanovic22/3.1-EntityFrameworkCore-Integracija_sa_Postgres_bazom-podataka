using BookstoreApplication.Models;

namespace BookstoreApplication.Repositories
{
    public interface IAuthorsRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task<Author?> UpdateAsync(Author author);
        Task<bool> DeleteAsync(int id);
    }
}
