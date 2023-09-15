using GameStore.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();