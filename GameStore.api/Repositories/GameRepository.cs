using GameStore.api.Data;
using GameStore.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameStoreContext? _context;

    public GameRepository(GameStoreContext? context)
    {
        _context = context;
    }

    public Game? GetGame(int id)
    {
        return _context?.Games.Find(id);
    }

    public IEnumerable<Game> GetGames()
    {
        return _context?.Games.AsNoTracking().ToList() ?? Enumerable.Empty<Game>();
    }

    public Game CreateGame(Game game)
    {
        var validate = _context?.Games.FirstOrDefault(g => g.Name == game.Name) is not null;
        if (validate) throw new Exception($"Game with name {game.Name} already exists.");

        _context?.Games.Add(game);
        _context?.SaveChanges();
        return game;
    }

    public void UpdateGame(int Id, Game game)
    {
        var gameToUpdate = _context?.Games.FirstOrDefault(g => g.Id == Id) ??
                           throw new Exception($"Game id: {Id}, not found.");
        _context?.Update(game);
        _context?.SaveChanges();
    }

    public void DeleteGame(int id)
    {
        var game = _context?.Games.FirstOrDefault(g => g.Id == id) ?? throw new Exception($"Game id: {id}, not found.");
        _context?.Games.Remove(game);
        _context?.SaveChanges();
    }
}