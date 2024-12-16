using SkillTest.UI.Models;
using SkillTest.UI.ProxyContracts;
using System.Text;
using System.Text.Json;

namespace SkillTest.UI.Proxies
{
    public class PeopleServiceProxy : IPeopleServiceProxy
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public PeopleServiceProxy(string apiUrl)
        {
            _apiUrl = apiUrl;
            _httpClient = new HttpClient();
        }

        // Get all people
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Person>>(jsonData);
            }
            return new List<Person>();
        }

        // Get a person by id
        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Person>(jsonData);
            }
            return null;
        }

        // Create a new person
        public async Task<bool> CreatePersonAsync(Person person)
        {
            var json = JsonSerializer.Serialize(person);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_apiUrl, content);
            return response.IsSuccessStatusCode;
        }

        // Update an existing person
        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var json = JsonSerializer.Serialize(person);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(_apiUrl, content);
            return response.IsSuccessStatusCode;
        }

        // Delete a person by id
        public async Task<bool> DeletePersonAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
