using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Domain.Entities;
namespace Gestion.Infrastructure.Infrastructure
{
    public interface IProviderRepository
    {

        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider> GetByIdAsync(string id);
        Task AddAsync(Provider provider);
        Task UpdateAsync(string id, Provider provider);
        Task DeleteAsync(string id);
    }
}
