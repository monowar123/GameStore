using System;
using GameStore.Api.DTOs;
using MinimalApis.Extensions;

namespace GameStore.Api.EndPoints;

public static class GamesEndPoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = new List<GameDto>
    {
        new(1, "Street Fighter 2", "Fighting", 19.99M, new DateOnly(1992,7,15)),
        new(2, "Final Fantasy", "Roleplaying", 59.99M, new DateOnly(2010,9,30)),
        new(3, "FIFA 23", "Sports", 69.99M, new DateOnly(2022,9,27))
    };

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/games")
                    .WithParameterValidation();

        //GET /games
        group.MapGet("/", () => games);

        //GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        //POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {
            var game = new GameDto(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.price,
                newGame.ReleaseDate
                );
            games.Add(game);

            //return game;
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        //PUT /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var game = games.Find(game => game.Id == id);
            if (game == null) return Results.NotFound();

            var updated = game with
            {
                Name = updatedGame.Name,
                Genre = updatedGame.Genre,
                price = updatedGame.price,
                ReleaseDate = updatedGame.ReleaseDate
            };

            games[games.IndexOf(game)] = updated;

            return Results.NoContent();
        });

        //DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            var game = games.Find(game => game.Id == id);
            if (game == null) return Results.NotFound();

            games.Remove(game);

            return Results.NoContent();
        });

        return group;
    }
}
