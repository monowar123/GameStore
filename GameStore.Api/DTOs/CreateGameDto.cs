namespace GameStore.Api.DTOs;

public record class CreateGameDto(
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);
