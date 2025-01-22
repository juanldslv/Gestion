using Gestion.Domain.Entities;
using Gestion.Infrastructure.Infrastructure;
using GestionApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;


namespace Gestion.Test
{
    public class ProvidersServiceTest
    {
        private readonly Mock<IProviderRepository> _mock;
        private readonly ProviderService _service;

        public ProvidersServiceTest() { 
            _mock = new Mock<IProviderRepository>();
            _service = new ProviderService(_mock.Object);
        }
        [Test]
        public async Task GetAllProveedoresAsync_ReturnsAllProveedores()
        {
            // Arrange
            var providers = new List<Provider>
        {
            new Provider { Id = "321312", NIT = "123456" },
            new Provider { Id = "2222222", NIT = "654321" }
        };

            // Configurar el mock para devolver la lista de proveedores
            _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(providers);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

    }
}
