using GameStore.api.Entities;

namespace GameStore.api.Repositories;

public interface IGameRepository
{
    Game CreateGame(Game game);
    Game? GetGame(int id);
    IEnumerable<Game> GetGames();
    void UpdateGame(int Id, Game game);
    void DeleteGame(int id);
}