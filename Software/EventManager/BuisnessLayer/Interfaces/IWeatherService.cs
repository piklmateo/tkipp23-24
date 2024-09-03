using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BuisnessLayer.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherAsync(string city);
        Task<JObject> GetWeatherAsync(string city, DateTime date);
        Task<string> GetCoordinatesAsync(string city);
    }

    public class WeatherInfo
    {
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
    }
}
