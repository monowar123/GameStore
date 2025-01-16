using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDtos> games = [
    new(1, "Street Fighter 2", "Fighting", 19.99M, new DateOnly(1992,7,15)),
    new(2, "Final Fantasy", "Roleplaying", 59.99M, new DateOnly(2010,9,30)),
    new(3, "FIFA 23", "Sports", 69.99M, new DateOnly(2022,9,27))
];

//GET /games
app.MapGet("games", () => games);

//GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
.WithName(GetGameEndpointName);


//POST /games
app.MapPost("games", (CreateGameDtos game) => {
    var newGame = new GameDtos(games.Count + 1, game.Name, game.Genre, game.price, game.ReleaseDate);
    games.Add(newGame);

    return newGame;
    //return Results.CreatedAtRoute(GetGameEndpointName, new { id = newGame.Id }, newGame);
});

//app.MapGet("/", () => "Hello World!");

app.Run();