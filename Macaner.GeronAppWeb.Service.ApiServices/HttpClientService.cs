using Macaner.GeronAppWeb.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Macaner.GeronAppWeb.Service.ApiServices
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public HttpClientService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        private async Task AddAuthorizationHeader()
        {
            var token = await _authService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            await AddAuthorizationHeader();
            return await _httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T content)
        {
            await AddAuthorizationHeader();
            return await _httpClient.PostAsJsonAsync(url, content);
        }
    }
}
