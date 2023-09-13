var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// const string getGamesEndpoints = "GetGames";

app.MapControllers();

// app.MapGet("/games/{id:int}", (int id) => {
//         var game = games.Find(g => g.Id == id);
//         return game is null ? Results.NotFound(new { message = $"Game with id {id} not found." }) : Results.Ok(game);
//     })
//     .WithName(getGamesEndpoints);
//
// app.MapPost("/games", (Game game) => {
//     var validate = games.Find(g => g.Name == game.Name) is not null;
//     if (validate) return Results.BadRequest(new { message = $"Game with name {game.Name} already exists." });
//
//     game.Id = games.Max(g => g.Id) + 1;
//     games.Add(game);
//     return Results.CreatedAtRoute(getGamesEndpoints, new { id = game.Id }, game);
// });
//
// app.MapPut("/games/{id:int}", (int id, Game updatedGame) => {
//     var existingGame = games.Find(g => g.Id == id);
//     if (existingGame is null) return Results.NotFound(new { message = $"Game with id {id} not found." });
//
//     existingGame.Name = updatedGame.Name;
//     existingGame.Genre = updatedGame.Genre;
//     existingGame.Price = updatedGame.Price;
//     existingGame.ReleaseDate = updatedGame.ReleaseDate;
//     existingGame.ImageUri = updatedGame.ImageUri;
//
//     return Results.NoContent();
// });
//
// app.MapDelete("/games/{id:int}", (int id) => {
//     var game = games.Find(g => g.Id == id);
//     if (game is null) return Results.NotFound(new { message = $"Game with id {id} not found." });
//
//     games.Remove(game);
//     return Results.NoContent();
// });

app.Run();