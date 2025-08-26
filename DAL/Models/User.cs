using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime JoinDate { get; set; }

    public string Role { get; set; } = null!;

    public virtual Developer? Developer { get; set; }

    public virtual Player? Player { get; set; }
}
