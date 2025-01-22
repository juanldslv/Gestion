using Gestion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Gestion.Infrastructure.Infrastructure
{
    public class ProviderRepository: IProviderRepository
    {
        private readonly IMongoCollection<Provider> _collection;
        public ProviderRepository(IMongoClient client, IConfiguration configuration)
        {
            var database = client.GetDatabase(configuration["ProviderStoreDatabase:DatabaseName"]);
            _collection = database.GetCollection<Provider>("Providers");
        }

        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Provider> GetByIdAsync(string id)
        {
            return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Provider provider)
        {
            await _collection.InsertOneAsync(provider);
        }

        public async Task UpdateAsync(string id, Provider provider)
        {
            await _collection.ReplaceOneAsync(p => p.Id == id, provider);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }

    }
}
