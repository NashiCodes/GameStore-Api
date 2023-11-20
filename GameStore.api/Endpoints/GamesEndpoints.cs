using GameStore.api.Entities;
using GameStore.api.Repositories;

namespace GameStore.api.Endpoints;

public static class GamesEndpoints
{
    private const string GetGameEndpoint = "GetGames";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var mapGroup = routes.MapGroup("/games")
            .WithParameterValidation();

        mapGroup.MapGet("/", (IGameRepository repository) => repository.GetGames().Select(game => game.AsDto()));

        mapGroup.MapGet("/{id}", (int id, IGameRepository repository) =>
            {
                var game = repository.GetGame(id);
                if (game is null) return Results.NotFound();
                return Results.Ok(game.AsDto());
            })
            .WithName(GetGameEndpoint);

        mapGroup.MapPost("/", (CreateGameDto game, IGameRepository repository) =>
        {
            try
            {
                var createdGame = repository.CreateGame(game.AsEntity());
                return Results.CreatedAtRoute(GetGameEndpoint, new { id = createdGame.Id }, createdGame);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        mapGroup.MapPut("/{id}", (int Id, UpdateGameDto game, IGameRepository repository) =>
        {
            try
            {
                repository.UpdateGame(Id, game.AsEntity());

                return Results.Ok(new { message = $"Game Id:{Id}, was successful updated" });
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        mapGroup.MapDelete("/{Id}", (int Id, IGameRepository repository) =>
        {
            try
            {
                repository.DeleteGame(Id);
                return Results.Ok(new { message = $"Game Id:{Id}, was successful updated" });
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });
        return mapGroup;
    }
}