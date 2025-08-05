using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClienteAPI
{
    public class JsonPlaceholderService
    {

        private readonly HttpClient _httpClient;

        //Ignorar mayusculas y minusculas
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>?> GetTodosUsuariosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("users");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Usuario>>(responseBody, _options);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nError de petición: {e.Message}");
                return null;
            }
        }

        public async Task<Usuario?> GetUsuarioPorIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"users/{id}");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Usuario>(responseBody, _options);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nError de petición: {e.Message}");
                return null;
            }
        }
    }
}
