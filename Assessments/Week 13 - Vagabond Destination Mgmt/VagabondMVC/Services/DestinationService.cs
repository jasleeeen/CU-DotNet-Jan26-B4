using System.Net.Http.Json;
using System.Text.Json;
using VagabondMVC.Models;

namespace VagabondMVC.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly HttpClient _httpClient;

        public DestinationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/destinations");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<IEnumerable<Destination>>(content, options);
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/destinations/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<Destination>(content, options);
        }

        public async Task CreateAsync(Destination destination)
        {
            var response = await _httpClient.PostAsJsonAsync("api/destinations", destination);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int id, Destination destination)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/destinations/{id}", destination);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/destinations/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}