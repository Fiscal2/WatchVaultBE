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

    public async Task<List<WatchDto>> GetAllAsync(string? search = null, string? brand = null)
    {
        var query = _context.Watches.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(w =>
                w.Brand.Contains(search) ||
                w.Model.Contains(search) ||
                (w.ReferenceNumber != null && w.ReferenceNumber.Contains(search)));
        }

        if (!string.IsNullOrWhiteSpace(brand))
        {
            var normalizedBrand = brand.Trim().ToLower();

            query = query.Where(w =>
                w.Brand.ToLower() == normalizedBrand);
        }

        return await query
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

    public async Task<WatchDto?> GetByIdAsync(int id)
    {
        return await _context.Watches
            .Where(w => w.Id == id)
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
            .FirstOrDefaultAsync();
    }
}