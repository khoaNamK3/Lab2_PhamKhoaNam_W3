using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class GameHubContext : DbContext
{
    public GameHubContext()
    {
    }

    public GameHubContext(DbContextOptions<GameHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Developer> Developers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameCategory> GameCategories { get; set; }

    public virtual DbSet<GamePlayer> GamePlayers { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>(entity =>
        {
            entity.Property(e => e.DeveloperId).ValueGeneratedNever();

            entity.HasOne(d => d.DeveloperNavigation).WithOne(p => p.Developer).HasForeignKey<Developer>(d => d.DeveloperId);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Games_CategoryId");

            entity.HasIndex(e => e.DeveloperId, "IX_Games_DeveloperId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Games).HasForeignKey(d => d.CategoryId);

            entity.HasOne(d => d.Developer).WithMany(p => p.Games).HasForeignKey(d => d.DeveloperId);
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
        });

        modelBuilder.Entity<GamePlayer>(entity =>
        {
            entity.HasKey(e => e.PlayerGameId);

            entity.HasIndex(e => e.GameId, "IX_GamePlayers_GameId");

            entity.HasIndex(e => e.PlayerId, "IX_GamePlayers_PlayerId");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePlayers).HasForeignKey(d => d.GameId);

            entity.HasOne(d => d.Player).WithMany(p => p.GamePlayers).HasForeignKey(d => d.PlayerId);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Players_UserId")
                .IsUnique()
                .HasFilter("([UserId] IS NOT NULL)");

            entity.HasOne(d => d.User).WithOne(p => p.Player).HasForeignKey<Player>(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
