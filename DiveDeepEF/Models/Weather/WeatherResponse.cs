namespace DiveDeepEF.Models.Weather
{

        public class WeatherResponse
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public double GenerationtimeMs { get; set; }
            public int UtcOffsetSeconds { get; set; }
            public string Timezone { get; set; }
            public string TimezoneAbbreviation { get; set; }
            public double Elevation { get; set; }
            public HourlyUnits HourlyUnits { get; set; }
            public HourlyForecast Hourly { get; set; }
        }

        public class HourlyUnits
        {
            public string Time { get; set; }
            public string Temperature2m { get; set; }
            public string Precipitation { get; set; }
            public string Weathercode { get; set; }
            public string Windspeed10m { get; set; }
        }

        public class HourlyForecast
        {
            public List<string> Time { get; set; }
            public List<double?> Temperature_2m { get; set; }
            public List<double?> Precipitation { get; set; }
            public List<int?> Weathercode { get; set; }
            public List<double?> Windspeed_10m { get; set; }
        }

    }
