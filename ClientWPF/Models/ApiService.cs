using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assembly.WPF.Models
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5062/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> FetchDataFromApi(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                return $"Error: {response.ReasonPhrase}";
            }
        }

        public async Task<HttpResponseMessage> GetEquipmentData()
        {
            return await _httpClient.GetAsync("Equipment");
        }

        public async Task<HttpResponseMessage> GetTimeSlotsData()
        {
            return await _httpClient.GetAsync("TimeSlot");
        }

        public async Task<HttpResponseMessage> CreateReservation(Reservation reservation)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(reservation), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("Reservation", jsonContent);
        }
    }
}
