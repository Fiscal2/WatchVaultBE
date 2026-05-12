using WatchVaultAPI.Models.Dtos;

namespace WatchVaultAPI.Interfaces;

public interface IWatchService
{
    Task<List<WatchDto>> GetAllAsync(string? search = null, string? brand = null);
    Task<WatchDto?> GetByIdAsync(int id);
}