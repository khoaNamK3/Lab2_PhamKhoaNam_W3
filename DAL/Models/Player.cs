using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();

    public virtual User? User { get; set; }
}
