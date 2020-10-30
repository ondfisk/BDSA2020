using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lecture09.App.Services
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _client;

        public RestClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string resource)
        {
            var json = await _client.GetStringAsync(resource);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        public async Task<T> GetAsync<T>(string resource)
        {
            var json = await _client.GetStringAsync(resource);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<Uri> PostAsync<T>(string resource, T item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(resource, content);

            return response.Headers.Location;
        }

        public async Task<bool> PutAsync<T>(string resource, T item)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(resource, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string resource)
        {
            var response = await _client.DeleteAsync(resource);

            return response.IsSuccessStatusCode;
        }
    }
}
