using Microsoft.AspNetCore.Builder;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Gestion.Domain.Entities;
using FluentAssertions;
using GestionApi.Controllers;


namespace Gestion.IntegrationTest
{
    public class ProvidersControllerIntegrationTests : IClassFixture<ProvidersController>
    {
        private readonly ProvidersController _providersController;
        public ProvidersControllerIntegrationTests(ProvidersController providersController)
        {
            _providersController = providersController;

        }
        [Fact]
        public async Task Get_ReturnsSuccessStatusCode()
        {

            // Arrange
            var provider = new Provider
            {
                Id="24",
                NIT = "123456789",
                Name = "Proveedor Ejemplo",
                Address = "Calle Falsa 123",
                City = "Ciudad Ejemplo",
                Department = "Departamento Ejemplo",
                Email = "proveedor@ejemplo.com",
                IsActive = true,
                CreatedAt = DateTime.Now,
                ContactName = "Juan Pérez",
                ContactEmail = "juan.perez@ejemplo.com"
            };
            // Assert
            var result =await _providersController.Add(provider);
            result.Should().Be(System.Net.HttpStatusCode.Created);
            result.Should().NotBeNull();

        }

    }
}
