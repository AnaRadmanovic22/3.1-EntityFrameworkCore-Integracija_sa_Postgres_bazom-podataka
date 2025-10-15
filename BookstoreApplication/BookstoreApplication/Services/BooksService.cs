using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Exceptions;

namespace BookstoreApplication.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<BooksService> _logger;

        public BooksService(IBooksRepository repository, IMapper mapper, ILogger<BooksService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<BookDto>> GetAllWithIncludesAsync()
        {
            var books = await _repository.GetAllWithIncludesAsync();
            return _mapper.Map<List<BookDto>>(books);
        }
        public async Task<BookDetailsDto> GetByIdWithIncludesAsync(int id)
        {
            _logger.LogInformation($"Fetching book with id {id}");

            var book = await _repository.GetByIdWithIncludesAsync(id);
            if (book == null) {
                _logger.LogError($"Book with id {id} not found");
                throw new NotFoundException(id);
            }
            return _mapper.Map<BookDetailsDto>(book);
        }
        public async Task<Book> AddAsync(Book book)
        {
            _logger.LogInformation($"Adding new book: {book.Title}");
            return await _repository.AddAsync(book); 
        }
        public async Task<Book?> UpdateAsync(Book book)
        {
            var existing = await _repository.GetByIdWithIncludesAsync(book.Id);
            if (existing == null)
                throw new NotFoundException(book.Id);

            return await _repository.UpdateAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdWithIncludesAsync(id);
            if (existing == null)
                throw new NotFoundException(id);

            return await _repository.DeleteAsync(id);
        }
    }
}
