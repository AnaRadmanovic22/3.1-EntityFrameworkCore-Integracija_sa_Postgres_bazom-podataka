using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using OpenQA.Selenium;

namespace BookstoreApplication.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Book>> GetAllWithIncludesAsync() {
            return await _repository.GetAllWithIncludesAsync();
        }
        public async Task<Book> GetByIdWithIncludesAsync(int id)  { 
            var book = await _repository.GetByIdWithIncludesAsync(id);
            if (book == null) { throw new NotFoundException(id);}
        }
        public async Task<Book> AddAsync(Book book){return await _repository.AddAsync(book); }
        public async Task<Book?> UpdateAsync(Book book){return await _repository.UpdateAsync(book); }
        public async Task<bool> DeleteAsync(int id) {return await _repository.DeleteAsync(id); }
    }
}
