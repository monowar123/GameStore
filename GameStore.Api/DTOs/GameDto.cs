namespace GameStore.Api.DTOs;

public record class GameDto(
    int Id,
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);


