using WatchVaultAPI.Models.Entities;

namespace WatchVaultAPI.Interfaces;

public interface ITokenService
{
    (string Token, DateTime ExpiresAtUtc) CreateToken(User user);
}