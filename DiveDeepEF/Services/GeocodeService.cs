using DiveDeepEF.Models.Weather;
using DiveDeepEF.Interfaces;
using System.Globalization;

namespace DiveDeepEF.Services
{


    public class GeocodeService : IGeocode
    {
        private readonly IHttpClientFactory _httpClient;

        public GeocodeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<double>> FetchCoordinatesForDesiredCity(string city)
        {

            var client = _httpClient.CreateClient();

            client.BaseAddress = new Uri("https://geocoding-api.open-meteo.com/v1/");
            
            var infoList = await client.GetFromJsonAsync<GeocodeWrapper>(
                $"{client.BaseAddress}search?name={city}&format=json"
            );
            
            if (infoList == null || infoList.results.Count() == 0)
            { 
                return null;
            }

            var firstResult = infoList.results.First();

            var coordinates = new List<double>
                {
                    firstResult.latitude,
                    firstResult.longitude
                };

            return coordinates;
        }


        public async Task<string> ResolveCityFromIp(string ip)
        {
            try
            {
                var client = _httpClient.CreateClient();
                var result = await client.GetFromJsonAsync<GeocodeIP>($"http://ip-api.com/json/{ip}?fields=city");
                return result?.City;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<double>> FetchCoordinatesForDesiredPostalCode(int PostalCode)
        {
            try
            {
                var client = _httpClient.CreateClient("GeocodingAPI");

                var infoList = await client.GetFromJsonAsync<List<GeocodeModel>>(
                    $"{client.BaseAddress}search?q={PostalCode}&format=json&countrycodes=dk"
                );

                if (infoList == null || infoList.Count == 0) return null;

                var firstResult = infoList[0];

                var coordinates = new List<double>
                {
                    firstResult.latitude,
                    firstResult.longitude
                };

                return coordinates;

            }
            catch (Exception ex)
            {
                //TODO: handle any errors properly
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        

    }
}