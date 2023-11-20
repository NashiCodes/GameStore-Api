using GameStore.api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider services)
    {
        using var scpoe = services.CreateScope();
        var dbcontext = scpoe.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbcontext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration config)
    {
        var connString = config.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString)
            .AddScoped<IGameRepository, GameRepository>();

        return services;
    }
}