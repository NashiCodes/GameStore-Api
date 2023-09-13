namespace GameStore.api.Entities;

public class GameRespository
{
    private static readonly HashSet<Game> Games = new() {
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
        }
    };

    public static Game? GetGame(int id) {
        return Games.FirstOrDefault(g => g.Id == id);
    }

    public static HashSet<Game> GetGames() {
        return Games;
    }

    public static Game CreateGame(Game game) {
        var validate = Games.FirstOrDefault(g => g.Name == game.Name) is not null;
        if (validate) throw new Exception($"Game with name {game.Name} already exists.");

        game.Id = Games.Max(g => g.Id) + 1;
        Games.Add(game);
        return game;
    }

    public static Game UpdateGame(int Id, Game game) {
        var gameToUpdate = Games.FirstOrDefault(g => g.Id == Id);
        if (gameToUpdate is null) throw new Exception($"Game with id {game.Id} not found.");

        gameToUpdate.Name = game.Name;
        gameToUpdate.Genre = game.Genre;
        gameToUpdate.Price = game.Price;
        gameToUpdate.ReleaseDate = game.ReleaseDate;
        gameToUpdate.ImageUri = game.ImageUri;
        return gameToUpdate;
    }

    public static void DeleteGame(int id) {
        var game = Games.FirstOrDefault(g => g.Id == id);
        if (game is null) throw new Exception($"Game with id {id} not found.");

        Games.Remove(game);
    }
}