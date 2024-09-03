using BuisnessLayer;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DataAccessLayer.Iznimke;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager
{
    ///<author>Toni Leo Modrić Dragičević</author>
    public partial class FrmEventDetailsUser : Form
    {
        private readonly Event events;
        private WeatherService _weatherService;

        public FrmEventDetailsUser(Event selectedEvent)
        {
            InitializeComponent();
            events = selectedEvent;
            _weatherService = new WeatherService(new FakeHttpClient());
            helpProvider1.HelpNamespace = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources", "EventManagerPrirucnik.pdf");
        }

        private async void FrmEventDetailsUser_Load(object sender, EventArgs e)
        {
            await LoadPicAsync();
            LoadSelectedEvent();
            LoadWeather();
        }

        private async void LoadWeather()
        {
            string city = txtVenueName.Text;

            string dateForm = txtEventDate.Text;
            string timeForm = txtStartTime.Text;

            string time12HourFormat = "";

            if (DateTime.TryParseExact(timeForm, "HH:mm:ss", null, DateTimeStyles.None, out DateTime parsedTime))
            {
                time12HourFormat = parsedTime.ToString("hh:mm:ss tt");
            }
            else
            {
                MessageBox.Show("Invalid time format");
            }

            string combinedDate = dateForm + " " + time12HourFormat;
            DateTime date = DateTime.Parse(combinedDate);

            try
            {
                var weatherData = await _weatherService.GetWeatherAsync(city, date);

                txtTemperature.Text = $"Temperature: {weatherData["main"]["temp"]} °C";
                txtDescription.Text = $"Description: {weatherData["weather"][0]["description"]}";
                TxtRain.Text = $"Rain: {(weatherData["rain"]?["3h"] != null ? weatherData["rain"]["3h"] + " mm" : "None")}";
                txtHumidity.Text = $"Humidity: {weatherData["main"]["humidity"]}%";
            }
            catch (WeatherException ex)
            {
                MessageBox.Show($"Error fetching weather data: {ex.Message}");
            }
        }

        private void LoadSelectedEvent()
        {
            txtEventName.Text = events.Name;
            txtStartTime.Text = events.StartTime.ToString();
            txtEventDate.Text = events.EventDate.ToShortDateString();
            txtVenueName.Text = events.Venue.Name;
            txtCategory.Text = events.EventCategory.Name;
            txtOrganizer.Text = events.Organizer.Name;
            txtCategory.Text = events.EventCategory.Name;
        }

        private async Task LoadPicAsync()
        {
            var url = events.imgUrl;

            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                    byte[] data = await httpClient.GetByteArrayAsync(url);

                    using (MemoryStream memoryStream = new MemoryStream(data))
                    using (Image image = Image.FromStream(memoryStream))
                    {
                        picEvent.Image = new Bitmap(image);
                    }
                }
            }
            catch (PictureException ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
    }
}
