﻿using System.ComponentModel.DataAnnotations;

namespace GameStore.api.Entities;

public class Game
{
    [Key][MaxLength(100)] public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Name { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public required string Genre { get; set; }

    [Range(1, 500)] public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }

    [Url] public required string ImageUri { get; set; }
}