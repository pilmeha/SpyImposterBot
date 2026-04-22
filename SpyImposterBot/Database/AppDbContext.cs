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

            modelBuilder.Entity<WordPack>().HasData(
                new WordPack { Id = 1, Name = "Классика", IsPublic = true },
                new WordPack { Id = 2, Name = "Мемы", IsPublic = true }
            );

            modelBuilder.Entity<Word>().HasData(
                new Word { Id = 1, PackId = 1, Value = "Париж" },
                new Word { Id = 2, PackId = 1, Value = "Самолет" },
                new Word { Id = 3, PackId = 1, Value = "Школа" },
                new Word { Id = 4, PackId = 1, Value = "Космос" },
                new Word { Id = 5, PackId = 1, Value = "Компьютер" },

                new Word { Id = 6, PackId = 2, Value = "Ждун" },
                new Word { Id = 7, PackId = 2, Value = "Чел хорош" },
                new Word { Id = 8, PackId = 2, Value = "Кринж" }
                );
        }

    }
}
