using Gestion.Domain.Entities;

namespace GestionApi.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider> GetByIdAsync(string id);
        Task AddAsync(Provider provider);
        Task UpdateAsync(string id, Provider provider);
        Task DeleteAsync(string id);
    }
}
