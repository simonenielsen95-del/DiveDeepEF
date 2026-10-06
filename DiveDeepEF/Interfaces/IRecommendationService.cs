using DiveDeepEF.Models.Weather;
using DiveDeepEF.Services;
namespace DiveDeepEF.Interfaces
{
    public interface IRecommendationService
    {
        Task<RecommendationResult> GetRecommendation(WeatherData weather);
    }
}