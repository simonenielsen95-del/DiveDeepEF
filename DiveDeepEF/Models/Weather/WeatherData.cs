namespace DiveDeepEF.Models.Weather
{
    public class WeatherData
    {
        public DateTime Time { get; set; }
        public double? AirTemperature { get; set; }
        public double? Precipitation { get; set; }
        public int? WeatherCode { get; set; }
        public double? WindSpeed10m { get; set; }
        public double? SeaSurfaceTemperature { get; set; }
        public double? WaveHeight { get; set; }
    }
}
