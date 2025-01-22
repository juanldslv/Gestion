using Gestion.Domain.Entities;
using Gestion.Infrastructure.Infrastructure;

namespace GestionApi.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _repository;

        public ProviderService(IProviderRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            
            return await _repository.GetAllAsync();
        }

        public async Task<Provider> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Provider provider)
        {
            await _repository.AddAsync(provider);
        }

        public async Task UpdateAsync(string id, Provider provider)
        {
            await _repository.UpdateAsync(id, provider);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
