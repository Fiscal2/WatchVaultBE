using WatchVaultAPI.Models.Dtos;

namespace WatchVaultAPI.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}