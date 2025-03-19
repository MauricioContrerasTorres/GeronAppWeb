using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Shared.Common
{
    public class AuthService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IConfiguration _config;
        private readonly string TokenKey;

        public AuthService(ILocalStorageService localStorage, IConfiguration configuration)
        {
            _localStorage = localStorage;
            _config = configuration;
            var jwtSettings = _config.GetSection("JWT");            
            TokenKey = jwtSettings["SecretKey"];
        }

        public async Task SaveTokenAsync(string token)
        {
            await _localStorage.SetItemAsync(TokenKey, token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(TokenKey);
        }

        public async Task RemoveTokenAsync()
        {
            await _localStorage.RemoveItemAsync(TokenKey);
        }
    }
}