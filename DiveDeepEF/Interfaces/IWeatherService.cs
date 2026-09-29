using DiveDeepEF.Models.Weather;

namespace DiveDeepEF.Interfaces

{
    public interface IWeatherService
    {
        Task<WeatherData> FindCurrentForecast(double latitude, double longtitude);
    }
}
