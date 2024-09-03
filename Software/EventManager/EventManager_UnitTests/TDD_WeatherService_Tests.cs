using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DataAccessLayer.Iznimke;
using FakeItEasy;
using Newtonsoft.Json.Linq;

namespace EventManager_UnitTests
{
    public class TDD_WeatherService_Tests
    {
        [Fact]
        public async Task GetCoordinatesAsync_GivenNonexistentCity_ThrowsArgumentException()
        {
            // Arrange
            var fakeHttpClient = A.Fake<IHttpClient>();
            var service = new WeatherService(fakeHttpClient);
            var cityName = "NonexistentCity";

            var fakeResponse = new HttpResponseMessage
            {
                Content = new StringContent("[]"),
                StatusCode = HttpStatusCode.OK
            };

            A.CallTo(() => fakeHttpClient.GetAsync(A<string>.Ignored)).Returns(fakeResponse);

            // Act and Assert
            await Assert.ThrowsAsync<WeatherException>(() => service.GetCoordinatesAsync(cityName));
        }

        [Fact]
        public async Task GetCoordinatesAsync_GivenLondonCoordinates_ReturnsLondonCoordinates()
        {
            // Arrange
            var fakeHttpClient = A.Fake<IHttpClient>();
            var service = new WeatherService(fakeHttpClient);

            A.CallTo(() => fakeHttpClient.GetAsync(A<string>._))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{\"lat\": 51.51, \"lon\": -0.13}]")
                }));

            // Act
            var (lat, lon) = await service.GetCoordinatesAsync("London");

            // Assert
            Assert.Equal(51.51, lat, 2);
            Assert.Equal(-0.13, lon, 2);
        }

        [Fact]
        public async Task GetWeatherAsync_GivenCoordinateOfLondon_ReturnsWeatherDataFromLondon()
        {
            // Arrange
            var fakeHttpClient = A.Fake<IHttpClient>();
            var service = new WeatherService(fakeHttpClient);

            A.CallTo(() => fakeHttpClient.GetAsync(A<string>._))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{\"lat\": 51.51, \"lon\": -0.13}]")
                }));

            A.CallTo(() => fakeHttpClient.GetAsync(A<string>._))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"list\": [{\"dt\": 1654320000, \"temperature\": 20}]}")
                }));

            // Act
            var weatherData = await service.GetWeatherAsync("London", DateTime.UtcNow.Date);

            // Assert
            Assert.NotNull(weatherData);
        }

        [Fact]
        public async Task GetWeatherAsync_GivenCityNotFound_ThrowsArgumentException()
        {
            // Arrange
            var fakeHttpClient = A.Fake<IHttpClient>();
            var service = new WeatherService(fakeHttpClient);

            // Act
            A.CallTo(() => fakeHttpClient.GetAsync(A<string>._))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("City not found.")
                }));

            // Assert
            await Assert.ThrowsAsync<WeatherException>(() => service.GetWeatherAsync("NonExistentCity", DateTime.UtcNow.Date));
        }

        [Fact]
        public async Task GetWeatherAsync_GivenCityAndDateAreValid_ReturnValidWeatherData()
        {
            // Arrange
            var weatherService = A.Fake<IWeatherService>();
            var date = DateTime.UtcNow.AddDays(1);
            var expectedWeatherData = JObject.Parse(@"{
                'main': { 'temp': 20 },
                'weather': [{ 'description': 'Cloudy' }]
            }");
            A.CallTo(() => weatherService.GetWeatherAsync(A<string>._, date))
                .Returns(Task.FromResult(expectedWeatherData));

            // Act
            var result = await weatherService.GetWeatherAsync("Zagreb", date);

            // Assert
            Assert.Equal(expectedWeatherData, result);
        }

        [Fact]
        public async Task GetWeatherAsync_GivenCityWhereItDoesntRain_ReturnNullRain()
        {
            // Arrange
            var fakeHttpClientWrapper = A.Fake<IHttpClient>();
            var weatherService = new WeatherService(fakeHttpClientWrapper);
            var city = "Egypt";
            var date = DateTime.UtcNow.AddDays(1);

            // Act
            var result = await weatherService.GetWeatherAsync(city, date);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result["main"]);
            Assert.Null(result["rain"]);
        }
    }
}
