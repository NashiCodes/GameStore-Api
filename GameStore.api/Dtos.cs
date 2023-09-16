using System.ComponentModel.DataAnnotations;

namespace GameStore.api;

public record GameDto(
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto(
    int Id,
    [Required]
    [StringLength(50, MinimumLength = 3)]
    string Name,
    [Required]
    [StringLength(20, MinimumLength = 3)]
    string Genre,
    [Range(1, 500)] decimal Price,
    DateTime ReleaseDate,
    [Url] string ImageUri
);

public record UpdateGameDto(
    int Id,
    [Required]
    [StringLength(50, MinimumLength = 3)]
    string Name,
    [Required]
    [StringLength(20, MinimumLength = 3)]
    string Genre,
    [Range(1, 500)] decimal Price,
    DateTime ReleaseDate,
    [Url] string ImageUri
);