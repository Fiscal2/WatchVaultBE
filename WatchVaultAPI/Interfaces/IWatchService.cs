using WatchVaultAPI.Models.Dtos;

namespace WatchVaultAPI.Interfaces;

public interface IWatchService
{
    Task<List<WatchDto>> GetAllAsync();
}