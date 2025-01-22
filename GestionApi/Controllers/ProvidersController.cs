using Gestion.Domain.Entities;
using GestionApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _service;
        private readonly IConfiguration _configuration;
        public ProvidersController(IProviderService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var providers = await _service.GetAllAsync();
            return Ok(providers);
        }
        [HttpGet("GetToken")]
        public async Task<IActionResult> GetToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, "Providers") },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(tokenString);
        }

        [Authorize]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(string id)
        {
            var provider = await _service.GetByIdAsync(id);
            if (provider == null)
                return NotFound();

            return Ok(provider);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Provider provider)
        {
                await _service.AddAsync(provider);
                return CreatedAtAction(nameof(GetById), new { id = provider.Id }, provider);
            
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Provider provider)
        {
            await _service.UpdateAsync(id, provider);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
