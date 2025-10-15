using BookstoreApplication.Models;
using BookstoreApplication.DTOs;

namespace BookstoreApplication.Services
{
    public interface IBooksService
    {
        Task<List<BookDto>> GetAllWithIncludesAsync();
        Task<BookDetailsDto> GetByIdWithIncludesAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book?> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}
