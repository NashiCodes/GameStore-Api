using GameStore.api.Models.Entities;
using GameStore.api.Models.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

const string GetGameEndpoint = "GetGames";

var mapGroup = app.MapGroup("/games");

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

app.Run();