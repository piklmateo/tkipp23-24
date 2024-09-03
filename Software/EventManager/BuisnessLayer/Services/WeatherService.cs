using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using Newtonsoft.Json.Linq;

namespace BuisnessLayer.Services
{
    public class WeatherService
    {
        private readonly IHttpClient _httpClient;

        private const string ApiKey = "25bc7ca5406a2ed440ba2d8f014fecf2";
        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/forecast";
        private const string GeoCodingUrl = "http://api.openweathermap.org/geo/1.0/direct";

        public WeatherService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(double, double)> GetCoordinatesAsync(string city)
        {
            string apiUrl = $"{GeoCodingUrl}?q={city}&appid={ApiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JArray json = JArray.Parse(responseBody);

                if (json.Count == 0)
                {
                    throw new WeatherException("City not found.");
                }

                double lat = json[0]["lat"].Value<double>();
                double lon = json[0]["lon"].Value<double>();

                return (lat, lon);
            }
        }

        public async Task<JObject> GetWeatherAsync(string city, DateTime date)
        {
            (double lat, double lon) = await GetCoordinatesAsync(city);

            string apiUrl = $"{ApiUrl}?lat={lat}&lon={lon}&appid={ApiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(responseBody);

                var forecastForDate = weatherData["list"]
                    .FirstOrDefault(f => DateTimeOffset.FromUnixTimeSeconds(f["dt"].Value<long>()).Date == date.Date);

                if (forecastForDate == null)
                {
                    throw new WeatherException("No forecast data available for the specified date.");
                }

                return (JObject)forecastForDate;
            }
        }
    }
}
