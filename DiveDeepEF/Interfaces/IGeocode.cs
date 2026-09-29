namespace Weather_website.Services
{
    public interface IGeocode
    {
        Task<List<double>> FetchCoordinatesForDesiredCity(string city);
        Task<List<double>> FetchCoordinatesForDesiredPostalCode(int PostalCode);
        Task<string> ResolveCityFromIp(string ip);

    }
}
