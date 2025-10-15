using BookstoreApplication.Models;
using BookstoreApplication.Repositories;


namespace BookstoreApplication.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly IPublishersRepository _repository;

        public PublishersService(IPublishersRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            return await _repository.AddAsync(publisher);
        }

        public async Task<Publisher?> UpdateAsync(Publisher publisher)
        {
            return await _repository.UpdateAsync(publisher);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
