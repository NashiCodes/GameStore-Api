namespace GameStore.api.Entities;

public static class EntityExtensions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUri
        );
    }

    public static Game AsEntity(this CreateGameDto game)
    {
        return new Game
        {
            Id = game.Id,
            Name = game.Name,
            Genre = game.Genre,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            ImageUri = game.ImageUri
        };
    }

    public static Game AsEntity(this UpdateGameDto game)
    {
        return new Game
        {
            Id = game.Id,
            Name = game.Name,
            Genre = game.Genre,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            ImageUri = game.ImageUri
        };
    }
}