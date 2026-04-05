using Microsoft.EntityFrameworkCore;
using WatchVaultAPI.Models.Entities;

namespace WatchVaultAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Watch> Watches => Set<Watch>();
    public DbSet<CollectionItem> CollectionItems => Set<CollectionItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<CollectionItem>()
            .HasOne(ci => ci.User)
            .WithMany(u => u.CollectionItems)
            .HasForeignKey(ci => ci.UserId);

        modelBuilder.Entity<CollectionItem>()
            .HasOne(ci => ci.Watch)
            .WithMany(w => w.CollectionItems)
            .HasForeignKey(ci => ci.WatchId);
    }
}