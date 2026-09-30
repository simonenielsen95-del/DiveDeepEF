using DiveDeepEF.Data;
using DiveDeepEF.Interfaces;
using DiveDeepEF.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Database
builder.Services.AddDbContext<DiveDeepEFContext>(options =>
    options.UseSqlServer(connectionString));

// Identity med roller
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
        options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DiveDeepEFContext>();

// Domæne-services
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IGeocode, GeocodeService>();
builder.Services.AddScoped<IRecommendationService, RecommendationService>();

// HttpClient-fabrikker
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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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