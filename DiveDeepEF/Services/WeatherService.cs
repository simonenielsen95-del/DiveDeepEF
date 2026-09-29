using System.Globalization;
using System.Net;
using DiveDeepEF.Models.Weather;
using DiveDeepEF.Interfaces;
using DiveDeepEF.ViewModels;


namespace DiveDeepEF.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherData> FindCurrentForecast(double latitude, double longtitude)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("WeatherForecastAPI");
                
                var clientMarine = _httpClientFactory.CreateClient("MarineAPI");

                var forecast = await client.GetFromJsonAsync<WeatherResponse>(
                    $"{client.BaseAddress}forecast?latitude={latitude.ToString("G", CultureInfo.InvariantCulture)}&longitude={longtitude.ToString("G", CultureInfo.InvariantCulture)}&hourly=temperature_2m,precipitation,weathercode,windspeed_10m&timezone=GMT&wind_speed_unit=ms");
                
                var marine = await clientMarine.GetFromJsonAsync<MarineResponse>($"{clientMarine.BaseAddress}marine?latitude={latitude.ToString("G", CultureInfo.InvariantCulture)}&longitude={longtitude.ToString("G", CultureInfo.InvariantCulture)}&hourly=wave_height,sea_surface_temperature&timezone=GMT");
                
                var now = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:00");

                var index = forecast.Hourly.Time.FindIndex(t => t == now);

                return new WeatherData
                {
                    Time = DateTime.Parse(now),
                    AirTemperature = forecast.Hourly.Temperature_2m[index],
                    Precipitation = forecast.Hourly.Precipitation[index],
                    WeatherCode = forecast.Hourly.Weathercode[index],
                    WindSpeed10m = forecast.Hourly.Windspeed_10m[index],
                    SeaSurfaceTemperature = marine.Hourly.Sea_Surface_Temperature[index],
                    WaveHeight = marine.Hourly.Wave_Height[index]
                };
            }
            catch (HttpRequestException ex)
            {
                var responseMessage = ex.Message;
                Console.WriteLine($"Error with API: {responseMessage}");
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("The requested endpoint could not be found.");
                }
                return null;
            }
        }
    }
}
