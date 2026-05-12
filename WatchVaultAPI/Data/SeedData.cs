using WatchVaultAPI.Models.Entities;

namespace WatchVaultAPI.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext db)
    {
        db.Database.EnsureCreated();

        if (db.Watches.Any())
        {
            return;
        }

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
                Brand = "Rolex",
                Model = "Datejust 41",
                ReferenceNumber = "126334",
                RetailPrice = 10800m,
                ImageUrl = "https://example.com/datejust41.jpg",
                Movement = "Automatic",
                YearOfProduction = "2017 - Present",
                CaseMaterial = "Oystersteel and White Gold",
                CaseDiameter = "41 mm",
                Description = "Versatile Rolex dress-sport watch."
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
            },
            new Watch
            {
                Brand = "Omega",
                Model = "Seamaster Diver 300M",
                ReferenceNumber = "210.30.42.20.01.001",
                RetailPrice = 5900m,
                ImageUrl = "https://example.com/seamaster300m.jpg",
                Movement = "Automatic",
                YearOfProduction = "2018 - Present",
                CaseMaterial = "Steel",
                CaseDiameter = "42 mm",
                Description = "Modern Omega dive watch."
            },
            new Watch
            {
                Brand = "Tudor",
                Model = "Black Bay 58",
                ReferenceNumber = "79030N",
                RetailPrice = 4175m,
                ImageUrl = "https://example.com/blackbay58.jpg",
                Movement = "Automatic",
                YearOfProduction = "2018 - Present",
                CaseMaterial = "Steel",
                CaseDiameter = "39 mm",
                Description = "Vintage-inspired Tudor diver."
            },
            new Watch
            {
                Brand = "Cartier",
                Model = "Santos Medium",
                ReferenceNumber = "WSSA0029",
                RetailPrice = 7050m,
                ImageUrl = "https://example.com/santos.jpg",
                Movement = "Automatic",
                YearOfProduction = "2018 - Present",
                CaseMaterial = "Steel",
                CaseDiameter = "35.1 mm",
                Description = "Iconic integrated-bracelet Cartier watch."
            }
        );

        db.SaveChanges();
    }
}