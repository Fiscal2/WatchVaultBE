namespace WatchVaultAPI.Models.Entities;

public class Watch
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string? ReferenceNumber { get; set; }
    public decimal? RetailPrice { get; set; }
    public string? ImageUrl { get; set; }
    public string? Movement { get; set; }
    public string? YearOfProduction { get; set; }
    public string? CaseMaterial { get; set; }
    public string? CaseDiameter { get; set; }
    public string? Description { get; set; }

    public List<CollectionItem> CollectionItems { get; set; } = new();
}