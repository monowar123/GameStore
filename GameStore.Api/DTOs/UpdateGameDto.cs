using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Genre,
    [Range(1,100)] decimal price,
    DateOnly ReleaseDate
);