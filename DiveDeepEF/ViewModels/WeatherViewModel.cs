using DiveDeepEF.Models.Weather;
namespace DiveDeepEF.ViewModels
{
    public class WeatherViewModel
    {
        public string? SelectedLocation { get; set; }
        public WeatherData? WeatherData { get; set; }
        public List<string>? RecommendationReasons { get; set; } = new();
        public string SuitRecommendation { get; set; }
    }
}