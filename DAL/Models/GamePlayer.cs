using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class GamePlayer
{
    public int PlayerGameId { get; set; }

    public int PlayerId { get; set; }

    public int GameId { get; set; }

    public DateTime DateRegisterGame { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
