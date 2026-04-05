using Microsoft.EntityFrameworkCore;
using WatchVaultAPI.Data;
using WatchVaultAPI.Interfaces;
using WatchVaultAPI.Models.Dtos;

namespace WatchVaultAPI.Services;

public class WatchService : IWatchService
{
    private readonly AppDbContext _context;

    public WatchService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<WatchDto>> GetAllAsync()
    {
        return await _context.Watches
            .Select(w => new WatchDto
            {
                Id = w.Id,
                Brand = w.Brand,
                Model = w.Model,
                ReferenceNumber = w.ReferenceNumber,
                RetailPrice = w.RetailPrice,
                ImageUrl = w.ImageUrl,
                Movement = w.Movement,
                YearOfProduction = w.YearOfProduction,
                CaseMaterial = w.CaseMaterial,
                CaseDiameter = w.CaseDiameter,
                Description = w.Description
            })
            .ToListAsync();
    }
}