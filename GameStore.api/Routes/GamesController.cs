#region

using GameStore.api.Entities;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace GameStore.api.Routes;

[ Route("games") ]
public class GamesController : Controller
{
    [ HttpGet("/games") ]
    public IActionResult GetGames() {
        return Ok(GameRespository.GetGames());
    }

    [ HttpGet("{id:int}") ]
    public IActionResult GetGame(int id) {
        var game = GameRespository.GetGame(id);
        return game is null ? NotFound(new { message = $"Game with id {id} not found." }) : Ok(game);
    }

    [ HttpPost ]
    public IActionResult CreateGame(Game game) {
        try {
            return Ok(GameRespository.CreateGame(game));
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }

    [ HttpPut("{id:int}") ]
    public IActionResult UpdateGame(int id, Game game) {
        try {
            return Ok(GameRespository.UpdateGame(id, game));
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }

    [ HttpDelete("{id:int}") ]
    public IActionResult DeleteGame(int id) {
        try {
            GameRespository.DeleteGame(id);
            return Ok();
        }
        catch (Exception e) {
            return BadRequest(new { message = e.Message });
        }
    }
}