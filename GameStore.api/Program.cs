using GameStore.api.Data;
using GameStore.api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*
 ** As I said in the IGameRespository.cs file
 ** I could Abstract the GameRespository class in the IGameRespository interface
 ** And register the interface in the services to inject the class in the endpoints
 ** But since there is only Group of endpoints that use the GameRespository class
 ** And the usability of this service is so specific
 ** I decided to use GameRespository class directly in the endpoints using static methods
 ** This way I don't need to create a new instance of GameRespository class in each endpoint
 */

var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();