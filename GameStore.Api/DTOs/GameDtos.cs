namespace GameStore.Api.DTOs;

public record class GameDtos(
    int Id,
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);


