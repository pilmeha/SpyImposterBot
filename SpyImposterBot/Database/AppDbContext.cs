using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace SpyImposterBot.Database
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<WordPack> WordPacks => Set<WordPack>();
        public DbSet<Word> Words => Set<Word>();
        public DbSet<GameSession> GameSessions => Set<GameSession>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameSession>(entity =>
            {
                entity.ToTable("game_sessions");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedBy).HasColumnName("created_by");
                entity.Property(e => e.PackId).HasColumnName("pack_id");
                entity.Property(e => e.GameMode).HasColumnName("game_mode");
                entity.Property(e => e.PlayersData).HasColumnName("players_data");
                entity.Property(e => e.CurrentPlayerIndex).HasColumnName("current_player_index");
                entity.Property(e => e.Status).HasConversion<string>().HasColumnName("status");
            });

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Word>().ToTable("words");
            modelBuilder.Entity<WordPack>().ToTable("word_packs");

            modelBuilder.Entity<User>()
                .HasIndex(x => x.TelegramId)
                .IsUnique();

            modelBuilder.Entity<Word>()
                .Property(x => x.Value)
                .HasColumnName("word");

            modelBuilder.Entity<GameSession>()
                .Property(x => x.PlayersData)
                .HasColumnType("jsonb");
        }

    }
}
