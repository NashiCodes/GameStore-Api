#region

using GameStore.api.Entities;

#endregion

List<Game> games = new() {
    new Game {
        Id = 1,
        Name = "The Last of Us Part II",
        Genre = "Action-adventure",
        Price = 59.99m,
        ReleaseDate = new DateTime(2020, 6, 19),
        ImageUri = "https://upload.wikimedia.org/wikipedia/en/4/4f/TLOU2_box_art.jpg"
    },
    new Game {
        Id = 2,
        Name = "The Witcher 3: Wild Hunt",
        Genre = "Action role-playing",
        Price = 39.99m,
        ReleaseDate = new DateTime(2015, 5, 19),
        ImageUri = "https://upload.wikimedia.org/wikipedia/en/0/0c/Witcher_3_cover_art.jpg"
    },
    new Game {
        Id = 3,
        Name = "Red Dead Redemption 2",
        Genre = "Action-adventure",
        Price = 59.99m,
        ReleaseDate = new DateTime(2018, 10, 26),
        ImageUri = "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg"
    },
    new Game {
        Id = 4,
        Name = "Grand Theft Auto V",
        Genre = "Action-adventure",
        Price = 29.99m,
        ReleaseDate = new DateTime(2013, 9, 17),
        ImageUri = "https://upload.wikimedia.org/wikipedia/en/a/a5/Grand_Theft_Auto_V.png"
    },
    new Game {
        Id = 5,
        Name = "The Elder Scrolls V: Skyrim",
        Genre = "Action role-playing",
        Price = 39.99m,
        ReleaseDate = new DateTime(2011, 11, 11),
        ImageUri = "https://upload.wikimedia.org/wikipedia/en/1/15/The_Elder_Scrolls_V_Skyrim_cover.png"
    }
};
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string getGamesEndpoints = "GetGames";


app.MapGet("/games", () => games);
app.MapGet("/games/{id:int}", (int id) => {
        var game = games.Find(g => g.Id == id);
        return game is null ? Results.NotFound(new { message = $"Game with id {id} not found." }) : Results.Ok(game);
    })
    .WithName(getGamesEndpoints);
app.MapPost("/games", (Game game) => {
    var validate = games.Find(g => g.Name == game.Name) is not null;
    if (validate) return Results.BadRequest(new { message = $"Game with name {game.Name} already exists." });

    game.Id = games.Max(g => g.Id) + 1;
    games.Add(game);
    return Results.CreatedAtRoute(getGamesEndpoints, new { id = game.Id }, game);
});

app.Run();