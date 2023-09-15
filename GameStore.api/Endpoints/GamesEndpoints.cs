﻿using GameStore.api.Models.Entities;
using GameStore.api.Models.Persistence;

namespace GameStore.api.Endpoints;

public static class GamesEndpoints
{
    private const string GetGameEndpoint = "GetGames";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var mapGroup = routes.MapGroup("/games")
            .WithParameterValidation();

        mapGroup.MapGet("/", GameRespository.GetGames);

        mapGroup.MapGet("/{id}", (int id) =>
            {
                var game = GameRespository.GetGame(id);
                if (game is null) return Results.NotFound();
                return Results.Ok(game);
            })
            .WithName(GetGameEndpoint);

        mapGroup.MapPost("/", (Game game) =>
        {
            try
            {
                var createdGame = GameRespository.CreateGame(game);
                return Results.CreatedAtRoute(GetGameEndpoint, new { id = createdGame.Id }, createdGame);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        mapGroup.MapPut("/{id}", (int Id, Game game) =>
        {
            try
            {
                GameRespository.UpdateGame(Id, game);
                return Results.Ok(new { message = "Game Id: {0}, was successful updated" });
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        mapGroup.MapDelete("/{id}", (int id) =>
        {
            try
            {
                GameRespository.DeleteGame(id);
                return Results.Ok(new { message = "Game Id: {0}, was successful deleted" });
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });
        return mapGroup;
    }
}