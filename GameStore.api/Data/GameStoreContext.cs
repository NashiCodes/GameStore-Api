using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GameStore.api.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("GameIds")
            .StartsAt(1)
            .IncrementsBy(1);

        modelBuilder.Entity<Game>()
            .Property(game => game.Id)
            .HasDefaultValueSql("NEXT VALUE FOR GameIds");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}