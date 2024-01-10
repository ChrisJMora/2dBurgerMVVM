using _2dBurgerMobileApp.Domain.Models;
using _2dBurgerMobileApp.Domain.Models.Responses;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _2dBurgerMobileApp.Services.DbServices
{
    public class BaseDbService : IBaseDbService
    {
        private readonly HttpClient _client = new();
        private HttpResponseMessage _response = new ();
        private readonly string _string_url = "https://2dburgerwebapi20240109171851.azurewebsites.net/api/";

        public async Task<EntityCollectionResponse<T>?> ListAsync<T>(string endpoint) where T : IEntity
        {
            try
            {
                _response = await _client.GetAsync(_string_url + endpoint);
                if (!_response.IsSuccessStatusCode)
                {
                    throw new Exception(await _response.Content.ReadAsStringAsync());
                }
                return await _response.Content.ReadFromJsonAsync<EntityCollectionResponse<T>>();
            }
            catch (Exception ex)
            {
                return new EntityCollectionResponse<T>(ex.Message);
            }
        }

        public async Task<EntityResponse<T>?> FindAsync<T>(string endpoint) where T : IEntity
        {
            try
            {
                _response = await _client.GetAsync(_string_url + endpoint);
                if (!_response.IsSuccessStatusCode)
                {
                    throw new Exception(await _response.Content.ReadAsStringAsync());
                }
                return await _response.Content.ReadFromJsonAsync<EntityResponse<T>>();
            }
            catch (Exception ex)
            {
                return new EntityResponse<T>(ex.Message);
            }
        }

        public async Task<EntityResponse<T>?> AddAsync<T>(string endpoint, T entity) where T : IEntity
        {
            try
            {
                var json = JsonSerializer.Serialize(entity);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                _response = await _client.PostAsync(_string_url + endpoint, content);

                if (!_response.IsSuccessStatusCode)
                {
                    throw new Exception(await _response.Content.ReadAsStringAsync());
                }

                return await _response.Content.ReadFromJsonAsync<EntityResponse<T>>();
            }
            catch (Exception ex)
            {
                return new EntityResponse<T>(ex.Message);
            }
        }

    }
}
