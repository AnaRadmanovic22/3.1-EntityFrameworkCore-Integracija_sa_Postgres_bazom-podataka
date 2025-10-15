using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;

        public BooksService(IBooksRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetAllWithIncludesAsync() { return await _repository.GetAllWithIncludesAsync(); }
        public async Task<Book> GetByIdWithIncludesAsync(int id)  { return await _repository.GetByIdWithIncludesAsync(id); }
        public async Task<Book> AddAsync(Book book){return await _repository.AddAsync(book); }
        public async Task<Book?> UpdateAsync(Book book){return await _repository.UpdateAsync(book); }
        public async Task<bool> DeleteAsync(int id) {return await _repository.DeleteAsync(id); }
    }
}
