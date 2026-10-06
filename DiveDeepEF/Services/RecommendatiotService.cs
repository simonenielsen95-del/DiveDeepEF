using DiveDeepEF.Interfaces;
using DiveDeepEF.Models.Weather;


namespace DiveDeepEF.Services
{
    public class RecommendationResult
    {
        public double? WindSpeed { get; set; }
        public double? WaveHeight { get; set; }
        public double? Precipitation { get; set; }
        public bool IsThunderstorm { get; set; }
        public double? WaterTemperature { get; set; }
        public bool IsSuitable { get; set; }
        public List<string> Reasons { get; set; } = new();
        public string SuitRecommendation { get; set; } = string.Empty;
    }

    public class RecommendationService : IRecommendationService
    {

        public async Task<RecommendationResult> GetRecommendation(WeatherData weather)
        {
            var result = new RecommendationResult
            {
                WindSpeed = weather.WindSpeed10m,
                WaveHeight = weather.WaveHeight,
                Precipitation = weather.Precipitation,
                WaterTemperature = weather.SeaSurfaceTemperature,
                IsThunderstorm = IsThunderstormFromCode(weather.WeatherCode)
            };

            bool safe = true;

            if (result.IsThunderstorm)
            {
                safe = false;
                result.Reasons.Add("Tordenvejr: Livsfarligt - al dykning frarådes");
            }
            else 
            {
                result.Reasons.Add("Der er ikke noget Tordenvejr i øjeblikket");
            }

            if (result.WindSpeed.HasValue && result.WindSpeed.Value >= 8)
            {
                safe = false;
                result.Reasons.Add($"Vindhastighed {result.WindSpeed} m/s er for høj. (Vi Anbefaler at det er under 8 m/s)");
            }

            if (result.WaveHeight.HasValue && result.WaveHeight >= 1.5)
            {
                safe = false;
                result.Reasons.Add($"Bølgehøjde {result.WaveHeight} m er for høj (Vi anbefaler en bølgehøjde på under 1,5 m).");
            }

            if (result.Precipitation.HasValue && result.Precipitation.Value >= 2)
            {
                safe = false;
                result.Reasons.Add($"Nedbør {result.Precipitation} mm/t er for høj (skal være < 2 mm/t).");
            }

            result.IsSuitable = safe;


            if (result.WaterTemperature.HasValue)
            {
                var temp = result.WaterTemperature.Value;

                result.SuitRecommendation = temp switch
                {
                    > 24 => "Våddragt (3mm)",
                    > 18 and <= 24 => "Våddragt (5mm)",
                    > 10 and <= 18 => "Våddragt (7mm)",
                    _ => "Tørdragt"
                };
            }

            else
            {
                result.SuitRecommendation = "Ingen oplysninger om vandtemperatur";
                result.Reasons.Add("Ingen oplysninger om vandtemperatur for lokationen.");
            }


            return result;
        }
        private bool IsThunderstormFromCode(int? code)
        {
            if (!code.HasValue) return false;

            var thunderstormCodes = new HashSet<int> { 95, 96, 99 };
            return thunderstormCodes.Contains(code.Value);
        }
    }
}