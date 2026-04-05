using Microsoft.EntityFrameworkCore;
using WatchVaultAPI.Data;
using WatchVaultAPI.Interfaces;
using WatchVaultAPI.Models.Entities;
using WatchVaultAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWatchService, WatchService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Watches.Any())
    {
        db.Watches.AddRange(
            new Watch
            {
                Brand = "Rolex",
                Model = "Submariner",
                ReferenceNumber = "126610LN",
                RetailPrice = 10250m,
                ImageUrl = "https://example.com/submariner.jpg",
                Movement = "Automatic",
                YearOfProduction = "2020 - Present",
                CaseMaterial = "Oystersteel",
                CaseDiameter = "41 mm",
                Description = "Classic Rolex dive watch."
            },
            new Watch
            {
                Brand = "Omega",
                Model = "Speedmaster Professional",
                ReferenceNumber = "310.30.42.50.01.001",
                RetailPrice = 8000m,
                ImageUrl = "https://example.com/speedmaster.jpg",
                Movement = "Manual",
                YearOfProduction = "2021 - Present",
                CaseMaterial = "Steel",
                CaseDiameter = "42 mm",
                Description = "The Moonwatch."
            }
        );

        db.SaveChanges();
    }
}

app.Run();
