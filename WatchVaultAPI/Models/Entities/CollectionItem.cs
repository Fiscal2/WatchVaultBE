namespace WatchVaultAPI.Models.Entities;

public class CollectionItem
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int WatchId { get; set; }
    public Watch Watch { get; set; } = null!;

    public decimal PurchasePrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string? Notes { get; set; }
    public string? Condition { get; set; }
}