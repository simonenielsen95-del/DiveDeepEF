using DiveDeepEF.Data;
using DiveDeepEF.Interfaces;
using DiveDeepEF.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DiveDeepEF.Models.Weather;

namespace DiveDeepEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DiveDeepEFContextConnection") ?? throw new InvalidOperationException("Connection string 'DiveDeepEFContextConnection' not found.");;

            builder.Services.AddDbContext<DiveDeepEFContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DiveDeepEFContext>();

            builder.Services.AddDbContext<DiveDeepEFContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IGeocode, GeocodeService>();
            builder.Services.AddScoped<IRecommendationService, RecommendationService>();

            builder.Services.AddHttpClient("WeatherForecastAPI", client =>
            {
                client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            });

            builder.Services.AddHttpClient("MarineAPI", client =>
            {
                client.BaseAddress = new Uri("https://marine-api.open-meteo.com/v1/");
            });

            builder.Services.AddHttpClient("GeocodingAPI", client =>
            {
                client.BaseAddress = new Uri("https://geocoding-api.open-meteo.com/v1/");
                client.DefaultRequestHeaders.Add("User-Agent", builder.Configuration["GEOCODE_API_REQUEST_HEADER"]);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
