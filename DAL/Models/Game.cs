using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public partial class Game
{
    public int GameId { get; set; }

    [Required]
    [MinLength(4)]
    [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$",
    ErrorMessage = "Incorect Input")]
    public string Title { get; set; } = null!;
    [Required]
    [Range(31, double.MaxValue, ErrorMessage = "Incorect Input")]
    public decimal Price { get; set; }

    [Required]
    public DateOnly? ReleaseDate { get; set; }

    [Required]
    public int? DeveloperId { get; set; }

    [Required]
    public int? CategoryId { get; set; }

    [ValidateNever]
    public virtual GameCategory? Category { get; set; }
    [ValidateNever]
    public virtual Developer? Developer { get; set; }

    public virtual ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
}
