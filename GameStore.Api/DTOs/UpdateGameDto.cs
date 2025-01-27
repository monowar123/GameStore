namespace GameStore.Api.DTOs;

public record class UpdateGameDto(
    string Name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);