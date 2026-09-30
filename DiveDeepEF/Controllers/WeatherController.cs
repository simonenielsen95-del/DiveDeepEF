using DiveDeepEF.Interfaces;
using DiveDeepEF.Models.Weather;
using DiveDeepEF.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepEF.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IRecommendationService _recommendationService;
        private readonly IGeocode _geocodingHTTPService;
        private readonly IWeatherService _weatherService;


        public WeatherController(
            IRecommendationService recommendationService,
            IGeocode geocodingHTTPService,
            IWeatherService weatherDataHTTPService)
        {
            _recommendationService = recommendationService;
            _geocodingHTTPService = geocodingHTTPService;
            _weatherService = weatherDataHTTPService;
        }

        public async Task<IActionResult> Index(string? location = null)
        {
            WeatherData? weather = null;
            string suitRecommandation = null;
            List<string>? reasons = null;
            string? selectedLocation = null;

            if (string.IsNullOrWhiteSpace(location))
                location = await TryGetUserLocation();

            if (!string.IsNullOrWhiteSpace(location))
            {
                selectedLocation = location;

                var coords = double.TryParse(location, out var postalCode)
                    ? await _geocodingHTTPService.FetchCoordinatesForDesiredPostalCode((int)postalCode)
                    : await _geocodingHTTPService.FetchCoordinatesForDesiredCity(location);

                if (coords != null && coords.Count == 2)
                {
                    weather = await _weatherService.FindCurrentForecast(coords[0], coords[1]);
                    var rec = await _recommendationService.GetRecommendation(weather);
                    suitRecommandation = rec.SuitRecommendation;
                    reasons = rec.Reasons;
                }
                else
                {
                    ViewBag.CityName = location;
                }
            }

            var vm = new WeatherViewModel
            {
                WeatherData = weather,
                SuitRecommendation = suitRecommandation,
                RecommendationReasons = reasons,
                SelectedLocation = selectedLocation
            };
            return View(vm);
        }


        private async Task<string?> TryGetUserLocation()
        {
            try
            {
                var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (string.IsNullOrWhiteSpace(ipAddress)) return null;
                if (ipAddress.StartsWith("127") || ipAddress == "::1") return "Copenhagen";

                var city = await _geocodingHTTPService.ResolveCityFromIp(ipAddress);
                return string.IsNullOrWhiteSpace(city) ? null : city;
            }
            catch
            {
                return null;
            }
        }
    }
}
