namespace DiveDeepEF.Models.Weather
{
    public class MarineResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GenerationtimeMs { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string Timezone { get; set; }
        public string TimezoneAbbreviation { get; set; }
        public double Elevation { get; set; }
        public MarineHourlyUnits HourlyUnits { get; set; }
        public MarineHourlyData Hourly { get; set; }
    }

    public class MarineHourlyUnits
    {
        public string Time { get; set; }
        public string Wave_Height { get; set; }
        public string Sea_Surface_Temperature { get; set; }
    }

    public class MarineHourlyData
    {
        public List<string> Time { get; set; }
        public List<double?> Wave_Height { get; set; }
        public List<double?> Sea_Surface_Temperature { get; set; }
    }
}
