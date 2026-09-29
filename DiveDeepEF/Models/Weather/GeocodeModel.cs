namespace Weather_website.Models;

 public class GeocodeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

    }

public class GeocodeWrapper
{
    public IEnumerable<GeocodeModel> results { get; set; }
}
